using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlCenterBottom.flpCenterBottom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlCenterBottom
{
    public class PanelCenterBottomSC
    {
        private static PanelCenterBottomSC _instance;
        public static PanelCenterBottomSC Instance
        {
            get
            {
                if (_instance == null) _instance = new PanelCenterBottomSC();
                return PanelCenterBottomSC._instance;
            }

            set { PanelCenterBottomSC._instance = value; }
        }
        protected FlowLayoutPanelCenterBottomSC _FlowLayoutPanelCenterBottomSC;
        public FlowLayoutPanelCenterBottomSC FlowLayoutPanelCenterBottomSC => _FlowLayoutPanelCenterBottomSC;

        private PanelCenterBottomSC()
        {
            this._FlowLayoutPanelCenterBottomSC = new FlowLayoutPanelCenterBottomSC();
        }

        public virtual void ShowAllDataAfterOpenForm()
        {

        }
    }

}
