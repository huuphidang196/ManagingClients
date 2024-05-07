using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall.pnlDetailProfile.tabCtrlPADetail.tabProfile.pnlPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall.pnlDetailProfile.tabCtrlPADetail
{
    public class TabControlProfileDetailSC
    {
        protected TabControl _TabControlProfileAccount;
        public TabControl TabControlProfileAccount => _TabControlProfileAccount;

        //Child
        protected PanelProfileAccountSC _PanelProfileAccountSC;
        public PanelProfileAccountSC PanelProfileAccountSC => _PanelProfileAccountSC;
        
        public TabControlProfileDetailSC()
        {
            this._TabControlProfileAccount = frmMain_Control.Instance.tabCtrlPADetail;
            this._PanelProfileAccountSC = new PanelProfileAccountSC();
        }

    }
}
