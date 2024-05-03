using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.SplitDisplayFinderOverall.PanelDisplayOverall;

namespace ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.SplitDisplayFinderOverall
{
    public class SplitDisplayFinderOverall
    {
        protected Panel _pnlDisplay_Overall;
        public Panel PanelDisplay_Overall => _pnlDisplay_Overall;

        protected PanelDisplayOverallSC _PanelDisplayOverallSC = new PanelDisplayOverallSC();
        public PanelDisplayOverallSC PanelDisplayOverallSC => _PanelDisplayOverallSC;

        public SplitDisplayFinderOverall(Panel pnlDisplayOverall, Panel pnlDetailProfile, Panel pnlPurOrder)
        {
            //Panel Display Detail Profile
            this._pnlDisplay_Overall = pnlDisplayOverall;

            this._PanelDisplayOverallSC.SetAllPanelInSidePanelDisplayOverall(pnlDetailProfile, pnlPurOrder);
        }


    }
}
