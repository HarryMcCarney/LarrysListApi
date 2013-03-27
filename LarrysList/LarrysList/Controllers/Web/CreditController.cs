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
using LarrysList.Services.Messaging;

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
                        type =  adyenResult.authResult.Replace("AUTHORISED", "AUTHORISATION").Replace("Refused", "REFUSED"),
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

                if (result.PaymentStatus.success)
                {

                   //pay.paymentRef, pay.amount, pay.currency, pay.shopperEmail, pay.accountHolderName
                    var paramPayment = new Payment { paymentRef = adyenResult.merchantReference };
                    result.Payment = orm.execObject<Result>(paramPayment, "api.user_payment_get").Payment;

                    result.Payment.sendReceiptEmail();
                }
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
