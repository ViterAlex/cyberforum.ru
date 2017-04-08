using System.Windows;

namespace AdjacencyMatrix.ViewModels
{
    internal class GraphViewModel<TGraphModel> : ViewModelBase
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(
            "Model", typeof(TGraphModel), typeof(GraphViewModel<TGraphModel>), new PropertyMetadata(default(TGraphModel)));

        public TGraphModel Model
        {
            get
            {
                return (TGraphModel) GetValue(ModelProperty);
            }
            set
            {
                SetValue(ModelProperty, value);
            }
        }
    }
}