using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace RadialDigitsExample
{
    public class BitClickerDesigner : ControlDesigner
    {
        private DesignerActionListCollection _actionLists;

        #region Overrides of ComponentDesigner

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionLists == null)
                {
                    _actionLists = new DesignerActionListCollection
                                   {
                                       new BitClickerActionList(this.Component)
                                   };
                }
                return _actionLists;
            }
        }

        #endregion
    }
}