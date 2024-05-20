using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.pnlBelowCusIC;
using ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
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
        //protected Button _btnDetailICForCus;

        protected Button _btnPrintICForCus;
        protected Button _btnHelpICForCus;
        protected Button _btnCloseICForCus;

        public FlowLayOutPanelUINegativeSC()
        {
            this._btnAddICForCus = FrmDetailCustomer.Instance.btnAddICForCus;
            this._btnAddICForCus.Click += new EventHandler(this.ButtonAddClick);

            this._btnEditICForCus = FrmDetailCustomer.Instance.btnEditICForCus;
            this._btnEditICForCus.Click += new EventHandler(this.ButtonEditClick);

            this._btnRemoveICForCus = FrmDetailCustomer.Instance.btnRemoveICForCus;
            this._btnRemoveICForCus.Click += new EventHandler(this.ButtonRemoveClick);

            this._btnPrintICForCus = FrmDetailCustomer.Instance.btnPrintICForCus;
            this._btnHelpICForCus = FrmDetailCustomer.Instance.btnHelpICForCus;

            this._btnCloseICForCus = FrmDetailCustomer.Instance.btnCloseICForCus;
            this._btnCloseICForCus.Click += new EventHandler(this.AddEventClickForButtonClose);

        }

        //btn Remove
        protected virtual void ButtonRemoveClick(object sender, EventArgs e)
        {
            //Delete Customer Order
            CustomerOrder customerOrder_Selected = PanelBelowCusICSC.Instance.TabCtrlInqueryContractSC.TabPageInqueryCustomerSC.CustomerOrder_Selected;

            if (customerOrder_Selected.ID_Customer_Order == 0)
            {
                MessageBox.Show("Vui lòng chọn Đơn Hàng muốn xóa trond Danh sách");
                return;
            }


            //Delete Inquery
            bool deletedInquery = CustomerOrderDataProvider.Instance.DeleteInqueryByIDCustomerOrder(customerOrder_Selected.ID_Customer_Order);
            //Contract
            bool deletedContract = CustomerOrderDataProvider.Instance.DeleteContractByIDCustomerOrder(customerOrder_Selected.ID_Customer_Order);

            bool deletedCusOrder = CustomerOrderDataProvider.Instance.DeleteCustomerOrderByID(customerOrder_Selected.ID_Customer_Order);

            string strContent = (!deletedCusOrder || !deletedInquery || !deletedContract) ? "Xóa Đơn Hàng Thất Bại" : "Xóa Đơn Hàng Thành Công";

            MessageBox.Show(strContent);

        }
        protected virtual void AddEventClickForButtonClose(object sender, EventArgs e)
        {
            FrmDetailCustomer.Instance.Close();
        }

        // Phương thức xử lý sự kiện click của button
        protected virtual void ButtonAddClick(object sender, EventArgs e)
        {
            // PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelInqueryContractSC.PanelInqueryCustomerSC.FlowLayoutPanelDetailInquerySC.CreatNewInqueryOfCustomer();
            PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.ButtonAddOrderCustomer();
            PanelBelowCusICSC.Instance.TabCtrlInqueryContractSC.TabPageInqueryCustomerSC.AddNewInquery();

        }

        // Phương thức xử lý sự kiện click của button
        protected virtual void ButtonEditClick(object sender, EventArgs e)
        {
            // PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.PanelInqueryContractSC.PanelInqueryCustomerSC.FlowLayoutPanelDetailInquerySC.CreatNewInqueryOfCustomer();
            PanelCenterCusICSC.Instance.PanelOrderPurchasingCustomerSC.AllowEditCustomerOrderAndContractInquery();

            //for Custommer Info
            PanelCenterCusICSC.Instance.PanelCustomerInfo.GroupBoxCustomerInfoSC.AllowEditAllControlOfCustomerOrder();

        }
    }
}
