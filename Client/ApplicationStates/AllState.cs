namespace Client.ApplicationStates
{
    public class AllState
    {
        public Action? Action { get; set; }

        public bool ShowPurchaseRequest { get; set; }
        public void PurchaseRequestClicked()
        {
            ResetAllOrders();
            ShowPurchaseRequest = true;
            Action?.Invoke();
        }

 
        public bool ShowOrderDelivery { get; set; }
        public void OrderDeliveryClicked()
        {
            ResetAllOrders();
            ShowOrderDelivery = true;
            Action?.Invoke();
        }


        public bool ShowPurchaseOrder { get; set; }
        public void PurchaseOrderClicked()
        {
            ResetAllOrders();
            ShowPurchaseOrder = true;
            Action?.Invoke();
        }

    
        public bool ShowOrderReceived { get; set; }
        public void OrderReceivedClicked()
        {
            ResetAllOrders();
            ShowOrderReceived = true;
            Action?.Invoke();
        }


        public bool ShowAccountingApproval { get; set; }
        public void AccountingApprovalClicked()
        {
            ResetAllOrders();
            ShowAccountingApproval = true;
            Action?.Invoke();
        }


        public bool ShowAccountingComplete { get; set; }
        public void AccountingCompleteClicked()
        {
            ResetAllOrders();
            ShowAccountingComplete = true;
            Action?.Invoke();
        }


        public bool ShowCoa { get; set; }
        public void CoaClicked()
        {
            ResetAllOrders();
            ShowCoa = true;
            Action?.Invoke();
        }


        public bool ShowInspection { get; set; }
        public void InspectionClicked()
        {
            ResetAllOrders();
            ShowInspection = true;
            Action?.Invoke();
        }

        public bool ShowUser { get; set; }
        public void UserClicked()
        {
            ResetAllOrders();
            ShowUser = true;
            Action?.Invoke();
        }

        private void ResetAllOrders()
        {
            ShowPurchaseRequest = false;
            ShowPurchaseOrder = false;
            ShowAccountingApproval = false;
            ShowAccountingComplete = false;
            ShowOrderDelivery = false;
            ShowOrderReceived = false;
            ShowCoa = false;
            ShowInspection = false;
            ShowUser = false;

        }
    }
}
