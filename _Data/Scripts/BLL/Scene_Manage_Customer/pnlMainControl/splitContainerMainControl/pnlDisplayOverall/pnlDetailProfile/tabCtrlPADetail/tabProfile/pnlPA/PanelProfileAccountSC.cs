using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.splitContainerMainControl.pnlDisplayOverall.pnlDetailProfile.tabCtrlPADetail.tabProfile.pnlPA
{
    public class PanelProfileAccountSC
    {
        protected Panel _PanelProfileAccount;
        public Panel PanelProfileAccount => _PanelProfileAccount;

        protected Label _lblNameLogIn;
        protected Label _lblPersonDepartment;
        protected Label _lblPersonPosition;
        protected Label _lblLevelAcess;

        protected TextBox _txtNameRealistic;
        protected TextBox _txtPassWordAccount;
        protected TextBox _txtEmailAccount;

        protected TextBox _txtAddressAccount;

        protected ComboBox _cboDayDate;
        protected ComboBox _cboMonthDate;
        protected ComboBox _cboYearDate;

        public PanelProfileAccountSC()
        {
            this._PanelProfileAccount = frmMain_Control.Instance.pnlProfileAccount;

            this._lblNameLogIn = frmMain_Control.Instance.lblNameLogIn;
            this._lblPersonDepartment = frmMain_Control.Instance.lblPersonDepartment;
            this._lblPersonPosition = frmMain_Control.Instance.lblPersonPosition;
            this._lblLevelAcess = frmMain_Control.Instance.lblLevelAcess;

            this._txtNameRealistic = frmMain_Control.Instance.txtNameRealistic;
            this._txtPassWordAccount = frmMain_Control.Instance.txtPassWordAccount;
            this._txtEmailAccount = frmMain_Control.Instance.txtEmailAccount;
            this._txtAddressAccount = frmMain_Control.Instance.txtAddressAccount;

            this._cboDayDate = frmMain_Control.Instance.cboDayDate;
            this._cboMonthDate = frmMain_Control.Instance.cboMonthDate;
            this._cboYearDate = frmMain_Control.Instance.cboYearDate;
        }

        public override string ToString()
        {
            return this._txtNameRealistic.Text;
        }
    }
}
