namespace EchoAlgorithm.GraphSamples
{
    public class FourNodesFullGraph : IGraph
    {
        public string Description { get; }
        public GraphModel Graph { get; }

        public FourNodesFullGraph()
        {
            Description = "Полный граф из четырех вершин";
            
            Graph = new GraphModel();
            Graph.AddEdge("0", "3");
            Graph.AddEdge("3", "2");
            Graph.AddEdge("2", "0");
            Graph.AddEdge("2", "1");
            Graph.AddEdge("1", "3");
            Graph.AddEdge("1", "0");
            
            Graph.NodeSet["0"].IsInitiator = true;
            
            Graph.NodeSet["0"].MarkAsActive();
        }
    }
}