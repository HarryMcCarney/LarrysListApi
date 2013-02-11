using System.Net;
using LarrysList.Services.GlobalConfig;

namespace LarrysList.Services.PaymentService
{
    public class PaymentEndPoint
    {
        private string adyenRecurringEndPoint;
        private string adyenEndPoint;
        private string adyenUser;
        private string adyenPwd;
        public LarrysList.comadyenpaltest.Payment paymentService;
       

        public PaymentEndPoint()
        {
        
            //adyenRecurringEndPoint = Globals.Instance.settings["AdyenRecurringEndPoint"];
            adyenEndPoint = Globals.Instance.settings["AdyenEndPoint"];
            adyenUser = Globals.Instance.settings["AdyenUser"];
            adyenPwd = Globals.Instance.settings["AdyenPwd"];
            paymentService = new LarrysList.comadyenpaltest.Payment { Url = adyenEndPoint };
            paymentService.Credentials = new NetworkCredential(adyenUser, adyenPwd);
          
    
            
        }

    }
}