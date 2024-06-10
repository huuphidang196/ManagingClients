using ManagingClients._Data.Scripts.DAO.FormMerchandise;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Data;

namespace ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforEquip.flpDetailEquip.flpElementOfEquip
{
    public class FlowLayoutPanelElementsOfEquipSC
    {
        protected ElementUnitsInquery _ElementUnitsInquery;

        protected TextBox _txtArticalNo;
        protected TextBox _txtNameElement;
        protected TextBox _txtCountElements;
        protected TextBox _txtPricePerOneElement;
        protected TextBox _txtArticalDesign;

        protected Label _lblTotalPriceElements;

        protected Button _btnAdd_Element;
        protected Button _btnEdit_Element;
        protected Button _btnDelete_Element;

        protected Guna2DataGridView _dgvListElements;
        public FlowLayoutPanelElementsOfEquipSC()
        {
            this._ElementUnitsInquery = new ElementUnitsInquery();
            this._txtArticalNo = frmMerchandise.Instance.txtArticalNo;
            this._txtNameElement = frmMerchandise.Instance.txtNameElement;
            this._txtCountElements = frmMerchandise.Instance.txtCountElements;
            this._txtPricePerOneElement = frmMerchandise.Instance.txtPricePerOneElement;
            this._txtPricePerOneElement.Leave += new EventHandler(this.AddEventTextBoxLevel);

            this._txtArticalDesign = frmMerchandise.Instance.txtArticalDesign;

            this._lblTotalPriceElements = frmMerchandise.Instance.lblTotalPriceElements;

            this._btnAdd_Element = frmMerchandise.Instance.btnAddElement;
            this._btnAdd_Element.Click += new EventHandler(this.AddEventAddElement);

            this._btnEdit_Element = frmMerchandise.Instance.btnEditElement;
            this._btnDelete_Element = frmMerchandise.Instance.btnDeleteElement;

            this._dgvListElements = frmMerchandise.Instance.dgvListElements;
            this._dgvListElements.MultiSelect = false;
            this._dgvListElements.CellDoubleClick += DataGridView_CellDoubleClick;
            // Giả sử dataGridView1 đã được thêm vào form
            this. _dgvListElements.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);

        }

        #region Add_Eventss
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện double-click tại đây
            if (e.RowIndex < 0) return;

            DataGridViewRow row_Selected = this._dgvListElements.Rows[e.RowIndex];
            int id_Element_Equip = int.Parse(row_Selected.Cells[0].Value.ToString());
            this._ElementUnitsInquery = DetailElementUnitsInqueryDataProvider.Instance.GetElementUnitsInqueryByIDElementUnitsInquery(id_Element_Equip);

            if (this._ElementUnitsInquery == null)
            {
                MessageBox.Show("Vui lòng chọn lại Thành phần cần kiểm tra");
                return;
            }

            this.SetContentControlByInquery(this._ElementUnitsInquery);
           
        }
        protected virtual void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Đảm bảo rằng DataGridView có ít nhất một cột
            if (_dgvListElements.Columns.Count < 0) return;
            //recify column name
            this._dgvListElements.Columns["ID_Element_Units_Inquery"].HeaderText = "Mã TP";

            this._dgvListElements.Columns["Artical_Number_Element_Inquery"].HeaderText = "Artical No.";

            this._dgvListElements.Columns["Count_Element"].HeaderText = "Số lượng";

            this._dgvListElements.Columns["Origin_Price_MR_Per_One"].HeaderText = "Giá mỗi thành phần";

            this._dgvListElements.Columns["Artical_Design_Element"].HeaderText = "Thiết kế thiết bị";


            // Tiếp tục cho tất cả các cột cần đổi tên
            foreach (DataGridViewColumn column in this._dgvListElements.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }
        protected virtual void AddEventTextBoxLevel(object sender, EventArgs e)
        {
            float count_Elements = float.Parse(this._txtCountElements.Text);
            float price_per_Elements = float.Parse(this._txtPricePerOneElement.Text);

            this._lblTotalPriceElements.Text = (count_Elements * price_per_Elements).ToString();
        }

        protected virtual void AddEventAddElement(object sender, EventArgs e)
        {
            //Insert
            this._ElementUnitsInquery = this.GetElementUnitsInqueryByAssembleAllControl();

            if (this._ElementUnitsInquery.ID_Units_Device_Inquery == 0)
            {
                MessageBox.Show("Vui lòng thêm hoặc lựa chọn Thiết Bị trước");

                return;
            }

            bool saveSuccess = DetailElementUnitsInqueryDataProvider.Instance.InsertElementUnitsInquery(this._ElementUnitsInquery);
            string str_Result = saveSuccess ? "Thêm Thiết Bị thành công! " : "Thêm thất bại";
            MessageBox.Show(str_Result);

            if (!saveSuccess)
            {
                this._ElementUnitsInquery = new ElementUnitsInquery();
                return;
            }

            this._ElementUnitsInquery.ID_Element_Units_Inquery = DetailElementUnitsInqueryDataProvider.Instance.GetMaxIDElementUnitsInquery();
            //Clear Data Element
            this.ClearContentOfControl();
            //Update Data GridView

        }
        #endregion

        #region Internal_Function
        protected virtual void ClearContentOfControl()
        {
            this._ElementUnitsInquery = new ElementUnitsInquery();

            this.SetContentControlByInquery(this._ElementUnitsInquery);

            //Listview selected = 0
        }

        protected virtual void SetContentControlByInquery(ElementUnitsInquery elementUnitsInquery)
        {
            this._ElementUnitsInquery = elementUnitsInquery;

            this._txtArticalNo.Text = elementUnitsInquery.Artical_Number_Element_Inquery;
            this._txtNameElement.Text = elementUnitsInquery.Name_Element;
            this._txtCountElements.Text = elementUnitsInquery.Count_Element.ToString();
            this._txtPricePerOneElement.Text = elementUnitsInquery.Origin_Price_MR_Per_One.ToString();
            this._txtArticalDesign.Text = elementUnitsInquery.Artical_Design_Element;
        }
        protected virtual ElementUnitsInquery GetElementUnitsInqueryByAssembleAllControl()
        {
            ElementUnitsInquery elementUnitsInquery = new ElementUnitsInquery();

            elementUnitsInquery.ID_Element_Units_Inquery = this._ElementUnitsInquery.ID_Element_Units_Inquery;

            elementUnitsInquery.ID_Units_Device_Inquery = PanelTopMerchandiseSC.Instance.PanelInforEquipSC.FlowLayoutPanelDetailEquip.UnitsDeviceInquery.ID_Units_Device_Inquery;
            elementUnitsInquery.Artical_Number_Element_Inquery = this._txtArticalNo.Text;
            elementUnitsInquery.Name_Element = this._txtNameElement.Text;
            elementUnitsInquery.Count_Element = int.Parse(this._txtCountElements.Text);
            elementUnitsInquery.Origin_Price_MR_Per_One = decimal.Parse(this._txtPricePerOneElement.Text);
            elementUnitsInquery.Artical_Design_Element = this._txtArticalDesign.Text;

            return elementUnitsInquery;
        }

        #endregion

        #region Reference_OutSide
        public virtual void ShowAllListElementsOfEquip()
        {
            int id_Unit = PanelTopMerchandiseSC.Instance.PanelInforEquipSC.FlowLayoutPanelDetailEquip.UnitsDeviceInquery.ID_Units_Device_Inquery;

            if (id_Unit == 0) return;

            List<ElementUnitsInquery> listElementUnitsInquery = DetailElementUnitsInqueryDataProvider.Instance.GetListElementUnitsInqueryByIDUnitDevice(id_Unit);

            this._dgvListElements.DataSource = listElementUnitsInquery;

        }
        #endregion 
    }
}
