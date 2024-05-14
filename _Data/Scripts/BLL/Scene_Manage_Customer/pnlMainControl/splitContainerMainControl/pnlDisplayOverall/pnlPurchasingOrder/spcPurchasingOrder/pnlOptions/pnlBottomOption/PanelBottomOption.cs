using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlOptions.pnlBottomOption
{
    public class PanelBottomOption
    {
        protected PanelOptionsSC _PanelOptionsSC;

        protected ComboBox _cboPeriodOptions;
        public ComboBox cboPeriodOptions => _cboPeriodOptions;

        protected ComboBox _cboSortOptions;
        public ComboBox cboSortOptions => _cboSortOptions;

        protected DateTimePicker _dtpFromTimeOptions;
        public DateTimePicker dtpFromTimeOptions => _dtpFromTimeOptions;

        protected DateTimePicker _dtpToTimeOptions;
        public DateTimePicker cboToTimeOptions => _dtpToTimeOptions;

        public PanelBottomOption(PanelOptionsSC panelOptionsSC)
        {
            this._PanelOptionsSC = panelOptionsSC;

            this._cboPeriodOptions = frmMain_Control.Instance.cboPeriodOptions;
            this._cboSortOptions = frmMain_Control.Instance.cboSortOptions;

            this._dtpFromTimeOptions = frmMain_Control.Instance.dtpFromTimeOptions;
            this._dtpFromTimeOptions.Format = DateTimePickerFormat.Custom;
            this._dtpFromTimeOptions.CustomFormat = "dd/MM/yyyy"; // Đặt định dạng ngày tháng

            this._dtpToTimeOptions = frmMain_Control.Instance.dtpToTimeOptions;
            this._dtpToTimeOptions.Format = DateTimePickerFormat.Custom;
            this._dtpToTimeOptions.CustomFormat = "dd/MM/yyyy";

            this.IniitializeDataBegin();
        }

        protected virtual void IniitializeDataBegin()
        {
            List<string> durationDescriptions = Enum.GetValues(typeof(DurationTime))
           .Cast<DurationTime>()
           .Skip(1) // Bỏ qua giá trị đầu tiên
           .Select(duration => TransferEnumString.TransferDurationTimeToString(duration))
           .ToList();

            // Hiển thị kết quả
            durationDescriptions.ForEach(Console.WriteLine);
            this._cboPeriodOptions.Items.AddRange(durationDescriptions.ToArray());
            this._cboPeriodOptions.SelectedIndex = 0;
            this._cboPeriodOptions.SelectedIndex = 0;

            // Lấy tất cả các giá trị của enum SortingMethod
            List<string> sortingDescriptions = Enum.GetValues(typeof(SortingMethod))
            .Cast<SortingMethod>()
            .Skip(1) // Bỏ qua giá trị đầu tiên
            .Select(method => TransferEnumString.TransferSortingMethodToString(method))
            .ToList();

            // Hiển thị kết quả
            sortingDescriptions.ForEach(Console.WriteLine);
            this._cboSortOptions.Items.AddRange(sortingDescriptions.ToArray());
            this._cboSortOptions.SelectedIndex = 0;
        }

        public virtual void SortListDataGridViewBySorting()
        {
            // Lấy chỉ số được chọn trong ComboBox
            int selectedIndex = this._cboSortOptions.SelectedIndex;

            // Tính giá trị của enum tương ứng với chỉ số + 1
            SortingMethod selectedMethod = (SortingMethod)(selectedIndex + 1);
            this._PanelOptionsSC.SplitContainerOrderSC.PanelBottomDisplayOrderSC.
                TabControlPOSC.TabControlDSKHSC.SortObjectByCondition(selectedMethod);

        }
    }
}
