﻿using ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforEquip.flpDetailEquip.flpElementOfEquip;
using ManagingClients._Data.Scripts.DAO.FormMerchandise;
using ManagingClients._Data.Scripts.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforEquip.flpDetailEquip
{
    public class FlowLayoutPanelDetailEquip
    {
        protected UnitsDeviceInquery _UnitsDeviceInquery;
        public UnitsDeviceInquery UnitsDeviceInquery => _UnitsDeviceInquery;

        protected FlowLayoutPanelElementsOfEquipSC _FlowLayoutPanelElementsOfEquipSC;
        public FlowLayoutPanelElementsOfEquipSC FlowLayoutPanelElementsOfEquipSC => _FlowLayoutPanelElementsOfEquipSC;

        protected TextBox _txtNameEquipmentUnit;
        protected TextBox _txtCountSetEquipmentUnit;
        protected TextBox _txtPercentVATEquip;
        protected TextBox _txtCostDeliveryVN;
        protected TextBox _txtCostDeliveryCus;
        protected TextBox _txtPercentBenefitDelivery;

        protected TextBox _txtPercentBenefitEquip;
        protected TextBox _txtFinalValueEquip;

        protected Label _lblValueVATEquip;
        protected Label _lblValueEquipCaculated;

        protected Button _btnCalculatePrice;
        protected Button _btnAddEquip;
        protected Button _btnEditEquip;
        protected Button _btnDeleteEquip;


        protected Guna2DataGridView _dtgAllEquipOfInquery;

        public FlowLayoutPanelDetailEquip()
        {
            this._UnitsDeviceInquery = new UnitsDeviceInquery();

            this._FlowLayoutPanelElementsOfEquipSC = new FlowLayoutPanelElementsOfEquipSC();

            this._txtNameEquipmentUnit = frmMerchandise.Instance.txtNameEquipmentUnit;
            this._txtCountSetEquipmentUnit = frmMerchandise.Instance.txtCountSetEquipmentUnit;
            this._txtPercentVATEquip = frmMerchandise.Instance.txtPercentVATEquip;
            this._txtCostDeliveryVN = frmMerchandise.Instance.txtCostDeliveryVN;
            this._txtCostDeliveryCus = frmMerchandise.Instance.txtCostDeliveryCus;
            this._txtPercentBenefitDelivery = frmMerchandise.Instance.txtPercentBenefitDelivery;
            this._txtPercentBenefitEquip = frmMerchandise.Instance.txtPercentBenefitEquip;
            this._txtFinalValueEquip = frmMerchandise.Instance.txtFinalValueEquip;

            this._lblValueVATEquip = frmMerchandise.Instance.lblValueVATEquip;
            this._lblValueEquipCaculated = frmMerchandise.Instance.lblValueCaculatedEquip;

            this._btnCalculatePrice = frmMerchandise.Instance.btnCalculatePrice;
            this._btnCalculatePrice.Click += new EventHandler(this.AddEventButtonCalculatePrice);

            this._btnAddEquip = frmMerchandise.Instance.btnAddEquip;
            this._btnAddEquip.Click += new EventHandler(this.AddEventAddEquip);

            this._btnEditEquip = frmMerchandise.Instance.btnEditEquip;
            this._btnDeleteEquip = frmMerchandise.Instance.btnDeleteEquip;


            this._dtgAllEquipOfInquery = frmMerchandise.Instance.dtgAllEquipOfInquery;
            this.ShowAllListEquipments();
            this._dtgAllEquipOfInquery.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.RecifyNameColumnOfEquip);
            this._dtgAllEquipOfInquery.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this._dtgAllEquipOfInquery.CellDoubleClick += DataGridView_CellDoubleClick;
            this._dtgAllEquipOfInquery.MultiSelect = false;
            this._dtgAllEquipOfInquery.SelectionChanged += new EventHandler(this.AddEventSelectedEquipChange);
       
        
        }

        #region Add_Events
        protected virtual void AddEventButtonCalculatePrice(object sender, EventArgs e)
        {
            this.SetContentCalulatePrice();
        }
        protected virtual void AddEventAddEquip(object sender, EventArgs e)
        {
            //Insert
            this._UnitsDeviceInquery = this.GetUnitsDeviceInqueryByAssembleAllControl();

            bool saveSuccess = DetailUnitsDeviceInqueryDataProvider.Instance.InsertUnitsDeviceInquery(this._UnitsDeviceInquery);
            string str_Result = saveSuccess ? "Thêm Thiết Bị thành công! " : "Thêm thất bại";
            MessageBox.Show(str_Result);

            if (!saveSuccess)
            {
                this._UnitsDeviceInquery = new UnitsDeviceInquery();
                return;
            }

            this._UnitsDeviceInquery.ID_Units_Device_Inquery = DetailUnitsDeviceInqueryDataProvider.Instance.GetMaxIDUnitsDeviceInquery();
            this._UnitsDeviceInquery.ID_Inquery_Quotation = frmMerchandise.Instance.InqueryQuotation.ID_Inquery_Quotation;

            //Update Data GridView
            this.ShowAllListEquipments();
            //Show All Element of Equip
            this._FlowLayoutPanelElementsOfEquipSC.ShowAllListElementsOfEquip();
        }
        protected virtual void RecifyNameColumnOfEquip(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_dtgAllEquipOfInquery.Columns.Count < 0) return;
            //recify column name
            this._dtgAllEquipOfInquery.Columns["ID_Units_Device_Inquery"].HeaderText = "STT";

            this._dtgAllEquipOfInquery.Columns["Name_Units_Device_Inquery"].HeaderText = "Tên bộ Thiết bị";

            this._dtgAllEquipOfInquery.Columns["Count_Set_Units_Device_Inquery"].HeaderText = "Số lượng (Bộ)";

            this._dtgAllEquipOfInquery.Columns["Percent_VAT_Units_Device_Inquery"].Visible = false;

            this._dtgAllEquipOfInquery.Columns["Cost_Delivery_To_VN"].Visible = false;

            this._dtgAllEquipOfInquery.Columns["Percent_Benefit_Cost_Delivery_To_Cus"].Visible = false;

            this._dtgAllEquipOfInquery.Columns["Percent_Benefit_Cost_Units_Inquery"].HeaderText = "Phần trăm lãi TB";

            this._dtgAllEquipOfInquery.Columns["Final_Value_Units_Device_Inquery"].HeaderText = "Giá cuối của TB";

            this._dtgAllEquipOfInquery.Columns["ID_Inquery_Quotation"].Visible = false;

            // Tiếp tục cho tất cả các cột cần đổi tên
            foreach (DataGridViewColumn column in this._dtgAllEquipOfInquery.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        protected virtual void AddEventSelectedEquipChange(object sender, EventArgs e)
        {
            if (this._dtgAllEquipOfInquery.SelectedRows[0].Index < 0)
            {
                this._UnitsDeviceInquery = new UnitsDeviceInquery();
                return;
            }

            DataGridViewRow selectedRow = this._dtgAllEquipOfInquery.SelectedRows[0];

            this._UnitsDeviceInquery.ID_Units_Device_Inquery = int.Parse(selectedRow.Cells["ID_Units_Device_Inquery"].Value.ToString());
            this._UnitsDeviceInquery.Name_Units_Device_Inquery = selectedRow.Cells["Name_Units_Device_Inquery"].Value.ToString();
            this._UnitsDeviceInquery.Count_Set_Units_Device_Inquery = int.Parse(selectedRow.Cells["Count_Set_Units_Device_Inquery"].Value.ToString());
            this._UnitsDeviceInquery.Percent_VAT_Units_Device_Inquery = decimal.Parse(selectedRow.Cells["Percent_VAT_Units_Device_Inquery"].Value.ToString());
            this._UnitsDeviceInquery.Cost_Delivery_To_VN = decimal.Parse(selectedRow.Cells["Cost_Delivery_To_VN"].Value.ToString());
            this._UnitsDeviceInquery.Percent_Benefit_Cost_Delivery_To_Cus = decimal.Parse(selectedRow.Cells["Percent_Benefit_Cost_Delivery_To_Cus"].Value.ToString());
            this._UnitsDeviceInquery.Percent_Benefit_Cost_Units_Inquery = decimal.Parse(selectedRow.Cells["Percent_Benefit_Cost_Units_Inquery"].Value.ToString());
            this._UnitsDeviceInquery.Final_Value_Units_Device_Inquery = decimal.Parse(selectedRow.Cells["Final_Value_Units_Device_Inquery"].Value.ToString());
            this._UnitsDeviceInquery.ID_Inquery_Quotation = int.Parse(selectedRow.Cells["ID_Inquery_Quotation"].Value.ToString());

        }

        protected virtual void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện double-click tại đây
            if (e.RowIndex < 0) return;

            DataGridViewRow row_Selected = this._dtgAllEquipOfInquery.Rows[e.RowIndex];
            int id_Unit_Inquery = int.Parse(row_Selected.Cells[0].Value.ToString());
            this._UnitsDeviceInquery = DetailUnitsDeviceInqueryDataProvider.Instance.GetUnitsDeviceInqueryByIDUnitsDevice(id_Unit_Inquery);

            if (this._UnitsDeviceInquery == null)
            {
                MessageBox.Show("Vui lòng chọn lại Thiêt bị cần kiểm tra");
                return;
            }

            //Show All Element of Equip
            this._FlowLayoutPanelElementsOfEquipSC.ShowAllListElementsOfEquip();
        }
        #endregion

        #region Internal_Function
        protected virtual void ClearAllDataEquipOfInquery()
        {
            this._txtNameEquipmentUnit.Text = "";
            this._txtCountSetEquipmentUnit.Text = "0";
            this._txtPercentVATEquip.Text = "10";
            this._txtCostDeliveryVN.Text = "";
            this._txtCostDeliveryCus.Text = "";
            this._txtPercentBenefitDelivery.Text = "50";
            this._txtPercentBenefitEquip.Text = "50";
            this._txtFinalValueEquip.Text = "";

            this._lblValueVATEquip.Text = "0";
            this._lblValueEquipCaculated.Text = "0";
        }
        protected virtual void SetContentAllDataOnInquery()
        {
            this._txtNameEquipmentUnit.Text = this._UnitsDeviceInquery.Name_Units_Device_Inquery;
            this._txtCountSetEquipmentUnit.Text = this._UnitsDeviceInquery.Count_Set_Units_Device_Inquery.ToString();
            this._txtPercentVATEquip.Text = this._UnitsDeviceInquery.Percent_VAT_Units_Device_Inquery.ToString();
            this._txtCostDeliveryVN.Text = this._UnitsDeviceInquery.Cost_Delivery_To_VN.ToString();
            this._txtCostDeliveryCus.Text = this._UnitsDeviceInquery.Cost_Delivery_To_Customer.ToString();
            this._txtPercentBenefitDelivery.Text = this._UnitsDeviceInquery.Percent_Benefit_Cost_Delivery_To_Cus.ToString();
            this._txtPercentBenefitEquip.Text = this._UnitsDeviceInquery.Percent_Benefit_Cost_Units_Inquery.ToString();
            this._txtFinalValueEquip.Text = this._UnitsDeviceInquery.Final_Value_Units_Device_Inquery.ToString();

            this.SetContentCalulatePrice();

            this._btnAddEquip = frmMerchandise.Instance.btnAddEquip;
            this._btnEditEquip = frmMerchandise.Instance.btnEditEquip;
            this._btnDeleteEquip = frmMerchandise.Instance.btnDeleteEquip;
        }

        protected virtual void SetContentCalulatePrice()
        {
            this._lblValueEquipCaculated.Text = this.GetValueEquipCaculated().ToString();
            this._lblValueVATEquip.Text = this.GetValueVATEquip().ToString();
            this._txtFinalValueEquip.Text = this.GetValueFinalAllSet().ToString();
        }
        protected virtual decimal GetValueEquipCaculated()
        {
            List<ElementUnitsInquery> listElementUnitsInquery = DetailElementUnitsInqueryDataProvider.Instance.GetListElementUnitsInqueryByIDUnitDevice(this._UnitsDeviceInquery.ID_Units_Device_Inquery);
            decimal total_Ori_Value_Element = 0;
            //giá gốc
            foreach (ElementUnitsInquery item in listElementUnitsInquery)
            {
                decimal valueElement = item.Origin_Price_MR_Per_One * item.Count_Element;
                total_Ori_Value_Element += valueElement;
            }
            decimal cost_One_Set_NO_VCKH = (total_Ori_Value_Element + this._UnitsDeviceInquery.Cost_Delivery_To_VN) * (1 + this._UnitsDeviceInquery.Percent_Benefit_Cost_Units_Inquery / 100);
            decimal cost_delivery_Cus = +this._UnitsDeviceInquery.Cost_Delivery_To_Customer * (1 + this._UnitsDeviceInquery.Percent_Benefit_Cost_Delivery_To_Cus / 100);

            decimal Cost_One_Set = (cost_One_Set_NO_VCKH + cost_delivery_Cus);

            return Cost_One_Set;
        }
        protected virtual decimal GetValueVATEquip()
        {
            decimal cost_Caculated = decimal.Parse(this._lblValueEquipCaculated.Text);
            decimal VAT = this._UnitsDeviceInquery.Percent_VAT_Units_Device_Inquery * cost_Caculated;
            return VAT;
        }
        protected virtual decimal GetValueFinalAllSet()
        {
            decimal cost_Caculated = decimal.Parse(this._lblValueEquipCaculated.Text);
            decimal VAT = this._UnitsDeviceInquery.Percent_VAT_Units_Device_Inquery * cost_Caculated;
            return VAT + cost_Caculated;
        }

        protected virtual UnitsDeviceInquery GetUnitsDeviceInqueryByAssembleAllControl()

        {
            UnitsDeviceInquery unitsDeviceInquery = new UnitsDeviceInquery();

            unitsDeviceInquery.ID_Units_Device_Inquery = this._UnitsDeviceInquery.ID_Units_Device_Inquery;

            unitsDeviceInquery.ID_Inquery_Quotation = this._UnitsDeviceInquery.ID_Inquery_Quotation;
            unitsDeviceInquery.Name_Units_Device_Inquery = this._txtNameEquipmentUnit.Text;
            unitsDeviceInquery.Count_Set_Units_Device_Inquery = int.Parse(this._txtCountSetEquipmentUnit.Text);
            unitsDeviceInquery.Percent_VAT_Units_Device_Inquery = decimal.Parse(this._txtPercentVATEquip.Text);
            unitsDeviceInquery.Cost_Delivery_To_VN = decimal.Parse(this._txtCostDeliveryVN.Text);
            unitsDeviceInquery.Cost_Delivery_To_Customer = decimal.Parse(this._txtCostDeliveryCus.Text);
            unitsDeviceInquery.Percent_Benefit_Cost_Delivery_To_Cus = decimal.Parse(this._txtPercentBenefitDelivery.Text);
            unitsDeviceInquery.Percent_Benefit_Cost_Units_Inquery = decimal.Parse(this._txtPercentBenefitEquip.Text);
            unitsDeviceInquery.Final_Value_Units_Device_Inquery = decimal.Parse(this._txtFinalValueEquip.Text);

            return unitsDeviceInquery;
        }

        #endregion

        #region Reference_OutSide
        public virtual void ShowAllListEquipments()
        {
            int id_Inquery = frmMerchandise.Instance.InqueryQuotation.ID_Inquery_Quotation;

            if (id_Inquery == 0) return;

            List<UnitsDeviceInquery> listUnitsDeviceInquery = DetailUnitsDeviceInqueryDataProvider.Instance.GetListUnitsDeviceInqueryByIDInqueryQuotation(id_Inquery);

            this._dtgAllEquipOfInquery.DataSource = listUnitsDeviceInquery;

        }
        #endregion
    }
}

