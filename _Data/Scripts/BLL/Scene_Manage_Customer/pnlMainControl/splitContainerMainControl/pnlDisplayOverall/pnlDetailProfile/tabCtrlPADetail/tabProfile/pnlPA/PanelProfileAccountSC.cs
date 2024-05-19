using ManagingClients._Data.Scripts.DAO.Scene_Manage_Customer.pnlMainControl.pnlDisplayOverall.pnlDetailProfile;
using ManagingClients._Data.Scripts.DTO.Account;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        protected TextBox _txtEmailAccount;

        protected TextBox _txtAddressAccount;

        protected RadioButton _radNam;
        protected RadioButton _radNu;

        protected ComboBox _cboDayDate;
        protected ComboBox _cboMonthDate;
        protected ComboBox _cboYearDate;

        protected PictureBox _ptbAvatar;

        #region Initialize
        public PanelProfileAccountSC()
        {
            this._PanelProfileAccount = FrmMain_Control.Instance.pnlProfileAccount;


            this._lblNameLogIn = FrmMain_Control.Instance.lblNameLogIn;
            this._lblPersonDepartment = FrmMain_Control.Instance.lblPersonDepartment;
            this._lblPersonPosition = FrmMain_Control.Instance.lblPersonPosition;
            this._lblLevelAcess = FrmMain_Control.Instance.lblLevelAcess;

            this._txtNameRealistic = FrmMain_Control.Instance.txtNameRealistic;
            this._txtEmailAccount = FrmMain_Control.Instance.txtEmailAccount;
            this._txtAddressAccount = FrmMain_Control.Instance.txtAddressAccount;

            this._radNam = FrmMain_Control.Instance.radNam;
            this._radNu = FrmMain_Control.Instance.radNu;

            this._cboDayDate = FrmMain_Control.Instance.cboDayOfBirth;
            this._cboMonthDate = FrmMain_Control.Instance.cboMonthOfBirth;
            this._cboYearDate = FrmMain_Control.Instance.cboYearOfBirth;

            this._ptbAvatar = FrmMain_Control.Instance.ptbAvatar;

            this.SetDataToDisplay();
        }

        protected virtual void SetDataToDisplay()
        {
            ProfileAccount profileAccount = FrmMain_Control.Instance.ProfileAccount;

            this._lblNameLogIn.Text = profileAccount.Name_Log_In;

            this._lblPersonDepartment.Text = DetailProfileProvider.Instance.GetNameDepartment(profileAccount.ID_Department);

            this._lblPersonPosition.Text = profileAccount.GetNamePosition();
            this._lblLevelAcess.Text = profileAccount.Level_Access.ToString();

            this._txtNameRealistic.Text = profileAccount.Name_Realistic;
            this._txtEmailAccount.Text = profileAccount.Email_Account;
            this._txtAddressAccount.Text = profileAccount.Address_Home;

            this._radNam.Checked = (profileAccount.Sex_Account == Sex.MEN);

            this._cboDayDate.Text = profileAccount.Date_Of_Birth.Day.ToString();
            this._cboMonthDate.Text = profileAccount.Date_Of_Birth.Month.ToString();
            this._cboYearDate.Text = profileAccount.Date_Of_Birth.Year.ToString();

            this._ptbAvatar.Image = this.ByteArrayToImage(profileAccount.Picture_Avatar);

        }
        // Chuyển đổi mảng byte thành hình ảnh
        protected virtual Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion

        public virtual void ProcessEventButtonSelectAvatarClick()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            this._ptbAvatar.Image = Image.FromFile(openFileDialog.FileName);

        }

        public virtual void SaveDataProfileAccount()
        {
            ProfileAccount profileAccount = this.GetProfileAccountFromUI();

            bool saveSuccess = DetailProfileProvider.Instance.UpdateDataProfileAccount(profileAccount);

            string strLog = saveSuccess ? "Lưu thành công !" : "Lưu thất bại";

            MessageBox.Show(strLog);
        }

        protected virtual ProfileAccount GetProfileAccountFromUI()
        {
            ProfileAccount profileAccount = new ProfileAccount();

            profileAccount.Password = FrmMain_Control.Instance.ProfileAccount.Password;
            profileAccount.Name_Log_In = this._lblNameLogIn.Text;

            profileAccount.ID_Department = FrmMain_Control.Instance.ProfileAccount.ID_Department;

            profileAccount.Person_Position = FrmMain_Control.Instance.ProfileAccount.Person_Position;
            profileAccount.Level_Access = (LevelAccess)Enum.Parse(typeof(LevelAccess), this._lblLevelAcess.Text);

            profileAccount.Name_Realistic = this._txtNameRealistic.Text;
            profileAccount.Email_Account = this._txtEmailAccount.Text;
            profileAccount.Address_Home = this._txtAddressAccount.Text;

            profileAccount.Sex_Account = this._radNam.Checked ? Sex.MEN : Sex.WOMAN;

            // Kết hợp ngày, tháng, năm thành một chuỗi định dạng ngày tháng
            string dateOfBirthString = $"{this._cboYearDate.Text}/{ this._cboMonthDate.Text}/{this._cboDayDate.Text}";
            DateTime dayOfBirth = DateTime.Parse(dateOfBirthString);

            profileAccount.Date_Of_Birth = dayOfBirth;

            Image imgAVT = this._ptbAvatar.Image;
            profileAccount.Picture_Avatar = DetailProfileProvider.Instance.ImageToByteArray(imgAVT);

            return profileAccount;
        }

        public override string ToString()
        {
            return this._txtNameRealistic.Text;
        }
    }
}
