using QuickGraph;

namespace AdjacencyMatrix.Models
{
    /// <summary>
    /// Класс двунаправленного графа с заданными вершинами и рёбрами
    /// </summary>
    public class GraphModel : BidirectionalGraph<GraphVertex, GraphEdge>
    {
        public GraphModel() { }

        public GraphModel(bool allowParallelEdges)
            : base(allowParallelEdges) { }

        public GraphModel(bool allowParallelEdges, int vertexCapacity)
            : base(allowParallelEdges, vertexCapacity) { }
    }
}
