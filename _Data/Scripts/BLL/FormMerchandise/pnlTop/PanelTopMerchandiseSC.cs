using ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforEquip;
using ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop.pnlInforSysInquery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingClients._Data.Scripts.BLL.FormMerchandise.pnlTop
{
    public class PanelTopMerchandiseSC
    {
        private static PanelTopMerchandiseSC _instance;
        public static PanelTopMerchandiseSC Instance
        {
            get
            {
                if (_instance == null) _instance = new PanelTopMerchandiseSC();
                return PanelTopMerchandiseSC._instance;
            }

            set { PanelTopMerchandiseSC._instance = value; }
        }

        protected PanelSystemInforInquerySC _PanelSystemInforInquerySC;
        public PanelSystemInforInquerySC PanelSystemInforInquerySC => _PanelSystemInforInquerySC;

        protected PanelInforEquipSC _PanelInforEquipSC;
        public PanelInforEquipSC PanelInforEquipSC => _PanelInforEquipSC;

        public static Action EventShowAllDataOnLoad;

        private PanelTopMerchandiseSC()
        {
            this._PanelSystemInforInquerySC = new PanelSystemInforInquerySC();
            this._PanelInforEquipSC = new PanelInforEquipSC();
        }
        public virtual void ShowAllValueOnScene()
        {
            EventShowAllDataOnLoad?.Invoke();
        }
    }
}
