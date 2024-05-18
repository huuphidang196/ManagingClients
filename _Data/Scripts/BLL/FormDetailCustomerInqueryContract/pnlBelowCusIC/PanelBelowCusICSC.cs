using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlBelow.TabCtrlnqueryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlBelowCusIC
{
    public class PanelBelowCusICSC
    {
        private static PanelBelowCusICSC _instance;
        public static PanelBelowCusICSC Instance
        {
            get
            {
                if (_instance == null) _instance = new PanelBelowCusICSC();
                return PanelBelowCusICSC._instance;
            }

            private set { PanelBelowCusICSC._instance = value; }
        }
        protected TabCtrlInqueryContractSC _TabCtrlInqueryContractSC;
        public TabCtrlInqueryContractSC TabCtrlInqueryContractSC => _TabCtrlInqueryContractSC;

        private PanelBelowCusICSC()
        {
            this._TabCtrlInqueryContractSC = new TabCtrlInqueryContractSC();
        }

        public virtual void ShowAllInformationAfterOpen()
        {
            this._TabCtrlInqueryContractSC.TabPageInqueryCustomerSC.ShowDataListViewAfterFormDetailCustomerLoad();
        }
    }
}
