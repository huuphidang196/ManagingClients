using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl
{
    public class PanelMainControl
    {
        private static PanelMainControl _instance;
        public static PanelMainControl Instance
        {
            get
            {
                if (_instance == null) _instance = new PanelMainControl();
                return PanelMainControl._instance;
            }

            private set { PanelMainControl._instance = value; }
        }

        protected Panel _pnlMainControl;
        public Panel pnlMainControl => _pnlMainControl;

        protected SplitContainerMainControl _SplitContainerMainControl;
        public SplitContainerMainControl SplitContainerMainControl => _SplitContainerMainControl;

        private PanelMainControl()
        {
            this._pnlMainControl = frmMain_Control.Instance.pnlMainControl;
            this._SplitContainerMainControl = new SplitContainerMainControl();

        }

    }
}
