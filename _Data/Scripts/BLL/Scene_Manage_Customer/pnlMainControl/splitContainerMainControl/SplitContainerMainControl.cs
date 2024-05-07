using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl
{
    public class SplitContainerMainControl
    {
        protected SplitContainer _spltContainerMainControl;
        public SplitContainer spltContainerMainControl => _spltContainerMainControl;

        protected PanelDisplayOverallSC _PanelDisplayOverallSC;
        public PanelDisplayOverallSC PanelDisplayOverallSC => _PanelDisplayOverallSC;

        public SplitContainerMainControl()
        {
            this._spltContainerMainControl = frmMain_Control.Instance.splitContainerMainControl;
            this._PanelDisplayOverallSC = new PanelDisplayOverallSC();
        }
    }
}
