namespace Client.ApplicationStates
{
    public class RequestState
    {
        public Action? RequestAction { get; set; }
        public bool ShowRequest { get; set; }
        public void RequestClicked()
        {
            ResetAllRequests();
            ShowRequest = true;
            RequestAction?.Invoke();
        }

        private void ResetAllRequests()
        {
            ShowRequest = false;
        }
    }
}
