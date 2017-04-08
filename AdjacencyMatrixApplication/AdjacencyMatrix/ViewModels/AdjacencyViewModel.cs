using System;
using System.Linq;
using System.Windows.Input;
using AdjacencyMatrix.Commands;
using AdjacencyMatrix.Models;

namespace AdjacencyMatrix.ViewModels
{
    internal class AdjacencyViewModel : GraphViewModel<GraphModel>
    {
        public int[,] AdjacencyMatrix { get; set; }

        private DelegateCommand _updateGraphCommand;

        public ICommand UpdateGraphCommand
        {
            get
            {
                if (_updateGraphCommand==null)
                {
                    _updateGraphCommand = new DelegateCommand(UpdateGraph);
                }
                return _updateGraphCommand;
            }
        }

        private void UpdateGraph()
        {
            Model = new GraphModel(true);
            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
                Model.AddVertex(new GraphVertex { Number = i });

            var vx = Model.Vertices.ToList();

            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                    if (AdjacencyMatrix[i, j] == 1)
                    {
                        if (Model.ContainsEdge(vx[j], vx[i]))
                        {
                            continue;
                        }
                        Model.AddEdge(new GraphEdge(vx[i], vx[j]));
                    }
        }

        public AdjacencyViewModel()
        {
            AdjacencyMatrix = new int[10, 10];
            var rnd = new Random();
            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                    if (i > j)
                    {
                        AdjacencyMatrix[i, j] = AdjacencyMatrix[j, i];
                    }
                    else if (i < j)
                    {
                        AdjacencyMatrix[i, j] = rnd.Next(2);
                    }
            OnPropertyChanged("AdjacencyMatrix");
        }
    }
}