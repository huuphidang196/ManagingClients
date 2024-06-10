using ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforEquip.flpDetailEquip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforEquip
{
    public class PanelInforEquipSC
    {
        protected FlowLayoutPanelDetailEquip _FlowLayoutPanelDetailEquip;
        public FlowLayoutPanelDetailEquip FlowLayoutPanelDetailEquip => _FlowLayoutPanelDetailEquip;

        public PanelInforEquipSC()
        {
            this._FlowLayoutPanelDetailEquip = new FlowLayoutPanelDetailEquip();
        }
    }
}
