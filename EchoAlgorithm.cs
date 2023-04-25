using System.Collections.Generic;

namespace EchoAlgorithm
{
    public static class EchoAlgorithm
    {

        public static List<Worker> Workers { get; } = new List<Worker>();


        public static void CreateWorkersFromGraph(GraphModel graph)
        {
            foreach (var kvp in graph.NodeSet)
            {
                Worker worker = new Worker(kvp.Value);
                Workers.Add(worker);

                if (kvp.Value.IsInitiator) worker.AlgorithmFinished += Stop;
            }
        }

        public static void Run()
        {
            foreach (var worker in Workers)
            {
                worker.Run();
            }
        }

        public static void Stop()
        {
            foreach (var worker in Workers)
            {
                worker.Stop();
            }
        }
    }
}