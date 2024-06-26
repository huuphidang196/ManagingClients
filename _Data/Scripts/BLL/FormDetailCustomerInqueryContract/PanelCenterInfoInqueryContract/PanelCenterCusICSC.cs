﻿using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlInqueryContract;
using ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract.pnlOrderPurchasing;
using ManagingClients._Data.Scripts.BLL.Scene_Manage_Customer.PanelCenterInfoInqueryContract.pnlCustomerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.BLL.FormDetailCustomerInqueryContract.PanelCenterInfoInqueryContract
{
    public class PanelCenterCusICSC
    {
        private static PanelCenterCusICSC _instance;
        public static PanelCenterCusICSC Instance
        {
            get
            {
                if (_instance == null) _instance = new PanelCenterCusICSC();
                return PanelCenterCusICSC._instance;
            }

             set { PanelCenterCusICSC._instance = value; }
        }

        protected PanelCustomerInfo _PanelCustomerInfo;
        public PanelCustomerInfo PanelCustomerInfo => _PanelCustomerInfo;

        protected PanelOrderPurchasingCustomerSC _PanelOrderPurchasingCustomerSC;
        public PanelOrderPurchasingCustomerSC PanelOrderPurchasingCustomerSC => _PanelOrderPurchasingCustomerSC;
        
        private PanelCenterCusICSC()
        {
            this._PanelCustomerInfo = new PanelCustomerInfo();
            this._PanelOrderPurchasingCustomerSC = new PanelOrderPurchasingCustomerSC();

        }

        public virtual void ShowAllInformationAfterOpen()
        {
            
        }

      
    }
}
