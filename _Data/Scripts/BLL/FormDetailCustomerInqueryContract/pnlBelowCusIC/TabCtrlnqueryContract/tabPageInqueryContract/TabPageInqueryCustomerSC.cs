using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer;
using ManagingClients._Data.Scripts.DAO.FormDetailCustomerIC;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlBelow.tabCtrlInqueryContract
{
    public class TabPageInqueryCustomerSC
    {
        protected ListView _lsvOrdersCustomer;

        protected CustomerOrder _CustomerOrder_Selected;
        public CustomerOrder CustomerOrder_Selected => _CustomerOrder_Selected;

        public static Action<CustomerOrder> EventShowDataICOfOrder;
        public TabPageInqueryCustomerSC()
        {
            this._CustomerOrder_Selected = new CustomerOrder();

            this._lsvOrdersCustomer = FrmDetailCustomer.Instance.lsvOrdersCustomer;
            this._lsvOrdersCustomer.MultiSelect = false;
            this._lsvOrdersCustomer.FullRowSelect = true;
            this._lsvOrdersCustomer.SelectedIndexChanged += new EventHandler(ListViewCustomerOrder);


        }

        #region Add_Events

        #endregion
        public virtual void ShowAndSetSelectedItem()
        {
            this.ShowDataListViewAfterFormDetailCustomerLoad();

            if (this._lsvOrdersCustomer.Items.Count == 0) return;

            this._lsvOrdersCustomer.Items[0].Selected = true;
            this._lsvOrdersCustomer.Items[0].Focused = true;
           
        }
        public virtual void ShowDataListViewAfterFormDetailCustomerLoad()
        {
            this._lsvOrdersCustomer.Items.Clear();

            CustomerGSES customerGSES = FrmDetailCustomer.Instance.CustomerGSES;

            List<CustomerOrder> customerOrders = CustomerOrderDataProvider.Instance.GetListCustomerOrderOfCustomerByIDCustomer(customerGSES.ID_Customer);

            if (customerOrders.Count == 0) return;

            //Sort form max -> min
            customerOrders.Sort((x, y) => y.ID_Customer_Order.CompareTo(x.ID_Customer_Order));
            if (customerOrders.Count == 0) return;

            foreach (CustomerOrder order in customerOrders)
            {
                ListViewItem item = new ListViewItem(order.ID_Customer_Order.ToString("D2"));
                item.SubItems.Add(order.Name_Order.ToString());
                item.SubItems.Add(TransferEnumString.TransferStatusOrderToString(order.Status_Order));
                item.SubItems.Add(TransferEnumString.TransferPostionToString(order.Level_Pos_Access_Order));
                item.SubItems.Add(TransferEnumString.TransferLevelAccessToString(order.Level_Access_Order));

                this._lsvOrdersCustomer.Items.Add(item);
            }
        }

        public virtual void AddNewInquery()
        {
            if (this._lsvOrdersCustomer.SelectedItems.Count == 0) return;

            this._lsvOrdersCustomer.SelectedItems[0].Selected = false;
        }

        public virtual void ListViewCustomerOrder(object sender, EventArgs e)
        {
            this._CustomerOrder_Selected = this.GetCustomerOrderFromItemSelected();
            //Notify
            EventShowDataICOfOrder?.Invoke(this._CustomerOrder_Selected);
        }

        public virtual CustomerOrder GetCustomerOrderFromItemSelected()
        {
            CustomerOrder customerOrder = new CustomerOrder();
            customerOrder.Name_Log_In = FrmMain_Control.Instance.ProfileAccount.Name_Log_In;
            customerOrder.ID_Customer = FrmDetailCustomer.Instance.CustomerGSES.ID_Customer;

            if (this._lsvOrdersCustomer.SelectedItems.Count == 0) return customerOrder;

            ListViewItem item = this._lsvOrdersCustomer.SelectedItems[0];

            customerOrder.ID_Customer_Order = int.Parse(item.SubItems[0].Text);
            customerOrder.Name_Order = item.SubItems[1].Text;
            customerOrder.Status_Order = TransferEnumString.TransferStringToStatusOrder(item.SubItems[2].Text);
            customerOrder.Level_Pos_Access_Order = TransferEnumString.TransferStringToPosition(item.SubItems[3].Text);
            customerOrder.Level_Access_Order = TransferEnumString.TransferStringToLevelAccess(item.SubItems[4].Text);


            return customerOrder;
        }


    }
}
