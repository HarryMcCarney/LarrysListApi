using System;
using System.Collections.Generic;
using System.Web.Mvc;

using LarryList.Services.PaymentService;

using LarrysList.Auth;
using LarrysList.Services.PaymentService;
using NLog;

namespace LarrysList.Controllers.Adyen
{
    public class NoticeController : Controller
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        public NoticeController()
        {
            log.Info("notice end point called");
        }


        //eventDate
        //reason
        //originalReference
        //merchantReference
        //currency
        //pspReference
        //merchantAccountCode
        //eventCode
        //value
        //operations
        //success
        //paymentMethod
        //live
        [BasicAuth]
        public string index(FormCollection formCollection)
        {
            string retString;
            if (formCollection["eventCode"] == "NOTIFICATIONTEST")
                return "[accepted]";
            try
            {
                var paymentNotice = createPaymentNotice(formCollection);
                CreatePaymentNotice.save(paymentNotice);
                retString = "[accepted]";
            }
            catch (Exception exp)
            {
                retString = "[Failed]";
                log.Error(exp);
            }
            return retString;
        }


        private static PaymentNotice createPaymentNotice(FormCollection formCollection)
        {
            log.Info(ToJSON(formCollection));
            var paymentNotice = new PaymentNotice();
            var paymentRef = formCollection["merchantReference"];
            paymentNotice.success = (formCollection["success"] == "true");
            paymentNotice.reason = formCollection["reason"];
            paymentNotice.paymentRef = paymentRef;
            paymentNotice.type = formCollection["eventCode"];
            paymentNotice.transactionId = (formCollection["eventCode"] == "AUTHORISATION") ? formCollection["pspReference"] : formCollection["originalReference"];
            return paymentNotice;

        }

        private static string ToJSON(System.Web.Mvc.FormCollection collection)
        {
            var list = new Dictionary<string, string>();
            foreach (string key in collection.Keys)
            {
                list.Add(key, collection[key]);
            }
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);
        }
    }
}
