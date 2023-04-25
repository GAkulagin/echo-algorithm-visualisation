using System;
using System.Messaging;
using System.Net;
using System.Threading;

namespace EchoAlgorithm
{
    public class Worker
    {
        public delegate void LogHandler(string message);
        public delegate void AlgorithmHandler();

        public event LogHandler Logger;
        public event AlgorithmHandler AlgorithmFinished;
        
        private GraphNode node;
        private bool _continue = true;
        private Thread thread;
        private MessageQueue queue;
        
        private bool sentForward = false;
        private bool sentBack = false;
        
        private const int TIMEOUT = 2000;

        public Worker(GraphNode node)
        {
            this.node = node;
            
            string queuePath = GetQueuePath(node.Id);
            queue = MessageQueue.Exists(queuePath) ? new MessageQueue(queuePath) : MessageQueue.Create(queuePath);
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            
            thread = new Thread(ReceiveMessage);
        }

        public void Run()
        {
            thread?.Start();
        }

        public void Stop()
        {
            _continue = false;
            thread?.Abort();
            if (MessageQueue.Exists(queue.Path)) 
                MessageQueue.Delete(queue.Path);
        }

        private void ReceiveMessage()
        {
            while (_continue)
            {
                if (node.IsInitiator)
                {
                    if(!sentForward) Logger?.Invoke("Algorithm Started");
                    SendToAllReceivers();
                }

                if (!MessageQueue.Exists(queue.Path)) 
                    continue;
                
                if (queue.Peek() != null)
                {
                    Message responce = queue.Receive(TimeSpan.FromSeconds(10.0));
                    string message = (String)responce.Body;
                    node.MarkAsActive();

                    if (message == "u good?") 
                        SendToAllReceivers();
                    else if (message == "yeah")
                        node.ReceivedFrom[responce.Label] = true;

                    if(node.IsReceivedFromEveryone())
                    {
                        if(node.IsInitiator)
                        {
                            Logger?.Invoke("Algorithm finished.");
                            AlgorithmFinished?.Invoke();
                        }
                        else SendToAllSenders();
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void SendToAllReceivers()
        {
            if (sentForward || node.Receivers.Count == 0) 
                return;
            
            Thread.Sleep(TIMEOUT);
            foreach (var receiver in node.Receivers)
            {
                SendMessage(receiver, "u good?");
                
                Logger?.Invoke($"Process {node.Id} sent data to process {receiver.Id}.");
            }

            node.MarkAsUsed();
            sentForward = true;
        }

        private void SendToAllSenders()
        {
            if (sentBack) 
                return;
            
            Thread.Sleep(TIMEOUT);
            foreach (var receiver in node.Senders)
            {
                SendMessage(receiver, "yeah");
                
                Logger?.Invoke($"Process {node.Id} sent data to process {receiver.Id}.");
            }
            
            node.MarkAsUsed();
            sentBack = true;
        }

        private void SendMessage(GraphNode receiver, string message)
        {
            try
            {
                MessageQueue receivingQueue = new MessageQueue(GetQueuePath(receiver.Id));
                receivingQueue.Send(message, node.Id);
            }
            catch (Exception e)
            {
                Logger?.Invoke(e.Message);
            }
        }

        private string GetQueuePath(string nodeId)
        {
            return Dns.GetHostName() + $"\\private$\\Node_{nodeId}";
        }
    }
}