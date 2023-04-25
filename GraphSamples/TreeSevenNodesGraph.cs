namespace EchoAlgorithm.GraphSamples
{
    public class TreeSevenNodesGraph : IGraph
    {
        public string Description { get; }
        public GraphModel Graph { get; }

        public TreeSevenNodesGraph()
        {
            Description = "Дерево из семи вершин";

            Graph = new GraphModel();
            Graph.AddEdge("0", "1");
            Graph.AddEdge("0", "2");
            Graph.AddEdge("1", "3");
            Graph.AddEdge("1", "4");
            Graph.AddEdge("2", "5");
            Graph.AddEdge("2", "6");

            Graph.NodeSet["0"].IsInitiator = true;
            
            Graph.NodeSet["0"].MarkAsActive();
        }
    }
}