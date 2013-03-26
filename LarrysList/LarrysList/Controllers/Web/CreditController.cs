using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LarryList.Services.PaymentService;
using LarrysList.Models;
using LarrysList.Services.PaymentService;
using LarrysList.comadyenpaltest;
using Payment = LarrysList.Models.Payment;

namespace LarrysList.Controllers.Web
{
    public class CreditController : BaseController
    {
        public string buy(Payment payment)
        {
            try
            {
                result = orm.execObject<Result>(payment, "api.user_payment_create");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
            }

        public string paymentResult(AdyenResult adyenResult)
        {
            try
            {
                //here we map the fields
                var paymentNotice = new PaymentNotice
                    {
                        success = true,
                        paymentRef = adyenResult.merchantReference,
                        type =  adyenResult.authResult.Replace("Authorised", "AUTHORISATION").Replace("Refused", "REFUSED"),
                        transactionId = adyenResult.pspReference
                    };


                //then we create thepayment notice
                CreatePaymentNotice.save(paymentNotice);

                //then we result a payment status
                result.PaymentStatus = new PaymentStatus
                    {
                        paymentRef = adyenResult.merchantReference,
                        success = (adyenResult.authResult == "AUTHORISED"),


                    };
             }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }



        public string spend(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_credit_spend");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }
    }

  
}
