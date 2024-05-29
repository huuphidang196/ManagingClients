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

        public static Action EventShowAllDataOnLoad;

        private PanelTopMerchandiseSC()
        {
            this._PanelSystemInforInquerySC = new PanelSystemInforInquerySC();
        }
        public virtual void ShowAllValueOnScene()
        {
            EventShowAllDataOnLoad?.Invoke();
        }
    }
}
