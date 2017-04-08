using QuickGraph;

namespace AdjacencyMatrix.Models
{
    /// <summary>
    /// Класс описывающий рёбра графа.
    /// </summary>
    public class GraphEdge:Edge<GraphVertex>
    {
        public GraphEdge(GraphVertex source, GraphVertex target)
            : base(source, target)
        {
        }
    }
}
