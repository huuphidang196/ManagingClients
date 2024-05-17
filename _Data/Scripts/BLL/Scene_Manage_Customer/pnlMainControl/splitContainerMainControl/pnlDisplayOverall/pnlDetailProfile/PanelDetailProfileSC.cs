using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall.pnlDetailProfile.tabCtrlPADetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall.pnlDetailProfile
{
    public class PanelDetailProfileSC
    {
        protected Panel _pnlDetail_Profile;
        public Panel PanelDetail_Profile => _pnlDetail_Profile;

        protected TabControlProfileDetailSC _TabControlProfileDetailSC;
        public TabControlProfileDetailSC TabControlProfileDetailSC => _TabControlProfileDetailSC;

        public PanelDetailProfileSC()
        {
            this._pnlDetail_Profile = FrmMain_Control.Instance.pnlDetailProfile;
            this._TabControlProfileDetailSC = new TabControlProfileDetailSC();

        }
    }
}
