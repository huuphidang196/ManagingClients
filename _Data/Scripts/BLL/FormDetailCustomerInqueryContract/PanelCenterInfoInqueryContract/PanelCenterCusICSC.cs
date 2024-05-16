using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.PanelCenterInfoInqueryContract.pnlCustomerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract
{
    public class PanelCenterCusICSC
    {
        private static PanelCenterCusICSC _instance;
        public static PanelCenterCusICSC Instance
        {
            get
            {
                if (_instance == null) _instance = new PanelCenterCusICSC();
                return PanelCenterCusICSC._instance;
            }

            private set { PanelCenterCusICSC._instance = value; }
        }

        protected PanelCustomerInfo _PanelCustomerInfo;
        public PanelCustomerInfo PanelCustomerInfo => _PanelCustomerInfo;
        private PanelCenterCusICSC()
        {
            this._PanelCustomerInfo = new PanelCustomerInfo();
        }

        public virtual void ShowAllInformationAfterOpen()
        {

        }
    }
}
