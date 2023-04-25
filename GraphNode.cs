using System;
using System.Collections.Generic;
using Microsoft.Msagl.Drawing;

namespace EchoAlgorithm
{
    public class GraphNode
    {
        public delegate void NodeHandler();

        public event NodeHandler GraphPictureChanged;
        public string Id { get; }
        public NodeStatus Status { get; private set; }
        public List<GraphNode> Senders { get; } = new List<GraphNode>();
        public List<GraphNode> Receivers { get; } = new List<GraphNode>();
        public Dictionary<string, bool> ReceivedFrom = new Dictionary<string, bool>();
        public Node NodePicture { get; set; }
        public bool IsInitiator { get; set; }


        public GraphNode(string id)
        {
            Id = id;
        }
        

        public int CompareTo(object obj)
        {
            if (obj is GraphNode node) return String.Compare(Id, node.Id, StringComparison.Ordinal);
            else throw new ArgumentException("parameter must be a GraphNode object");
        }

        public string GetStatus()
        {
            string str = "";
            
            switch (Status)
            {
                case NodeStatus.Active:
                    str = "Active";
                    break;
                case NodeStatus.Used:
                    str = "Used";
                    break;
                case NodeStatus.Waiting:
                    str = "Waiting";
                    break;
            }

            return str;
        }

        public void MarkAsActive()
        {
            Status = NodeStatus.Active;
            NodePicture.Attr.FillColor = Color.Red;
            GraphPictureChanged?.Invoke();
        }

        public void MarkAsUsed()
        {
            Status = NodeStatus.Used;
            NodePicture.Attr.FillColor = Color.LightGray;
            GraphPictureChanged?.Invoke();
        }

        public void MarkAsWaiting()
        {
            Status = NodeStatus.Waiting;
            NodePicture.Attr.FillColor = Color.Green;
            GraphPictureChanged?.Invoke();
        }
        
        public bool IsReceivedFromEveryone()
        {
            bool result = true;

            foreach (var kvp in ReceivedFrom)
            {
                result = result && kvp.Value;
            }
            
            return result;
        }
    }
}