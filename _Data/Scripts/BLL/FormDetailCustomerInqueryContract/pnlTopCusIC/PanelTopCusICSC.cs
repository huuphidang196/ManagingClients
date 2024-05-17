using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlTop.flpUINegative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlTopCusIC
{
    public class PanelTopCusICSC
    {
        private static PanelTopCusICSC _instance;
        public static PanelTopCusICSC Instance
        {
            get
            {
                if (_instance == null) _instance = new PanelTopCusICSC();
                return PanelTopCusICSC._instance;
            }

            private set { PanelTopCusICSC._instance = value; }
        }

        protected Panel _pnlTopCus;
        public Panel PnlTopCusIC => _pnlTopCus;

        protected FlowLayOutPanelUINegativeSC _FlowLayOutPanelUINegativeSC;
        public FlowLayOutPanelUINegativeSC FlowLayOutPanelUINegativeSC => _FlowLayOutPanelUINegativeSC;

        private PanelTopCusICSC()
        {
            this._pnlTopCus = FrmDetailCustomer.Instance.pnlCustomerInfo;

            this._FlowLayOutPanelUINegativeSC = new FlowLayOutPanelUINegativeSC();
        }

        public virtual void ShowAllDataWhenBegin()
        {
            
        }

    }
}
