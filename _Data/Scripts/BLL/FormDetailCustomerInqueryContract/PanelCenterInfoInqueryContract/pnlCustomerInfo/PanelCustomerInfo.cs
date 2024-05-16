using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.PanelCenterInfoInqueryContract.pnlCustomerInfo.grbCustomerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.PanelCenterInfoInqueryContract.pnlCustomerInfo
{
    public class PanelCustomerInfo
    {
      
        protected Panel _pnlCustomerInfor;
        public Panel PnlCustomerInfor => _pnlCustomerInfor;

        protected GroupBoxCustomerInfoSC _GroupBoxCustomerInfoSC;
        public GroupBoxCustomerInfoSC GroupBoxCustomerInfoSC => _GroupBoxCustomerInfoSC;
        public PanelCustomerInfo()
        {
            this._pnlCustomerInfor = frmDetailCustomer.Instance.pnlCustomerInfo;

            this._GroupBoxCustomerInfoSC = new GroupBoxCustomerInfoSC();
        }

    }
}
