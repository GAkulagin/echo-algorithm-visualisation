using System.Collections.Generic;
using Microsoft.Msagl.Drawing;

namespace EchoAlgorithm
{
    public class GraphModel
    {
        
        public Dictionary<string, GraphNode> NodeSet { get; } = new Dictionary<string, GraphNode>();
        public Graph GraphPicture { get; }

        public GraphModel()
        {
            GraphPicture = new Graph("graph");
        }

        public void AddEdge(string sourceId, string targetId)
        {
            GraphPicture.AddEdge(sourceId, targetId);
            
            GraphNode sourceNode = GetOrCreateNode(sourceId);
            GraphNode targetNode = GetOrCreateNode(targetId);

            sourceNode.Receivers.Add(targetNode);
            targetNode.Senders.Add(sourceNode);
            if(!sourceNode.ReceivedFrom.ContainsKey(targetId)) 
                sourceNode.ReceivedFrom.Add(targetId, false);
        }

        private GraphNode GetOrCreateNode(string id)
        {
            GraphNode node;
            if (NodeSet.ContainsKey(id)) node = NodeSet[id];
            else
            {
                node = new GraphNode(id);
                node.NodePicture = GraphPicture.FindNode(node.Id);
                node.MarkAsWaiting();

                NodeSet.Add(node.Id, node);
            }

            return node;
        }
    }
}