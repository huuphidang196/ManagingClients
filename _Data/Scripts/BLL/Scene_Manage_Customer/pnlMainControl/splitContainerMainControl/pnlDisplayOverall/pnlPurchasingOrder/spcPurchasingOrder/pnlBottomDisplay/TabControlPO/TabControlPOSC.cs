using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlBottomDisplay.TabControlPO.TabControlPODSKH;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.pnlMainControl.splitContainerMainControl.pnlDisplayOverall.pnlPurchasingOrder.spcPurchasingOrder.pnlBottomDisplay
{
   public class TabControlPOSC
    {
        protected TabControl _tabControlPO;
        public TabControl TabControlPO => _tabControlPO;

        protected TabControlDSKHSC _TabControlDSKHSC;
        public TabControlDSKHSC TabControlDSKHSC => _TabControlDSKHSC;

        public TabControlPOSC()
        {
            this._tabControlPO = FrmMain_Control.Instance.tabControlPO;
            this._tabControlPO.DrawMode = TabDrawMode.OwnerDrawFixed;
            this._tabControlPO.DrawItem += new DrawItemEventHandler(YourTabControl_DrawItem);

            this._tabControlPO.SelectedIndex = 0;
            this._TabControlDSKHSC = new TabControlDSKHSC();

        }

        public virtual void ProcessTabControlPurchasingOrderSelectedChange()
        {
            switch (this._tabControlPO.SelectedIndex)
            {
                case 0:
                    this._TabControlDSKHSC.ShowAllListCustomer();
                    break;
                default:
                    break;
            }
        }

        private void YourTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);

            // Màu nền và màu chữ
            Color backColor = Color.LightSteelBlue;
            Color foreColor = Color.Black;

            // Vẽ nền
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            // Vẽ viền (tùy chọn)
            e.Graphics.DrawRectangle(Pens.Black, tabRect);

            // Vẽ text
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabControl.Font, tabRect, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
