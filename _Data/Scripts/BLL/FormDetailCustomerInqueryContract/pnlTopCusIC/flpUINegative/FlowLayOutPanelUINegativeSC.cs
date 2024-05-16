﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlTop.flpUINegative
{
    public class FlowLayOutPanelUINegativeSC
    {
        protected Button _btnAddICForCus;
        protected Button _btnEditICForCus;
        protected Button _btnRemoveICForCus;
        protected Button _btnDetailICForCus;
        protected Button _btnSaveICForCus;
        protected Button _btnPrintICForCus;
        protected Button _btnHelpICForCus;
        protected Button _btnCloseICForCus;

        public FlowLayOutPanelUINegativeSC()
        {
            this._btnAddICForCus = frmDetailCustomer.Instance.btnAddICForCus;
            this._btnAddICForCus.Click += new EventHandler(this.ButtonAddClick);

            this._btnEditICForCus = frmDetailCustomer.Instance.btnEditICForCus;
            this._btnRemoveICForCus = frmDetailCustomer.Instance.btnRemoveICForCus;
            this._btnDetailICForCus = frmDetailCustomer.Instance.btnDetailICForCus;
            this._btnSaveICForCus = frmDetailCustomer.Instance.btnSaveICForCusSys;
            this._btnPrintICForCus = frmDetailCustomer.Instance.btnPrintICForCus;
            this._btnHelpICForCus = frmDetailCustomer.Instance.btnHelpICForCus;
            this._btnCloseICForCus = frmDetailCustomer.Instance.btnCloseICForCus;
        }

        // Phương thức xử lý sự kiện click của button
        protected virtual void ButtonAddClick(object sender, EventArgs e)
        {
            PanelCenterCusICSC.Instance.PanelInqueryContractSC.PanelInqueryCustomerSC.FlowLayoutPanelDetailInquerySC.CreatNewInqueryOfCustomer();
        }
    }
}