namespace EchoAlgorithm.GraphSamples
{
    public class FiveNodesGraphV1 : IGraph
    {
        public string Description { get; }
        public GraphModel Graph { get; }

        public FiveNodesGraphV1()
        {
            Description = "Граф из пяти вершин";

            Graph = new GraphModel();
            Graph.AddEdge("0", "1");
            Graph.AddEdge("0", "2");
            Graph.AddEdge("0", "3");
            Graph.AddEdge("3", "5");
            Graph.AddEdge("2", "5");
            Graph.AddEdge("1", "5");
            
            Graph.NodeSet["0"].IsInitiator = true;
            
            Graph.NodeSet["0"].MarkAsActive();
        }
    }
}