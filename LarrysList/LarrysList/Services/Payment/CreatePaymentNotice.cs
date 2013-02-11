using System;
using DBVC;
using LarrysList.Services.PaymentService;
using NLog;
using LarrysList.comadyenpaltest;
using Result = LarrysList.Result;



namespace LarryList.Services.PaymentService
{
    public static class CreatePaymentNotice
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private  static string paymentRef;

        public static void createSave(LarrysList.Models.Payment payment, PaymentResult paymentResult)
        {
            try
            {
                paymentRef = payment.paymentRef;
                save(buildPaymentNotice(paymentResult));
            }
            catch (Exception exp)
            {
                log.Error(exp);
                throw;
            }
        }


        public static void save(PaymentNotice paymentNotice)
        {
            try
            {
                var orm = new Orm();
                var result = orm.execObject<Result>(paymentNotice, "api.user_add_payment_notice");
                if (result.errorMessage != null)
                    throw new DivideByZeroException();
            }
            catch (DivideByZeroException exp)
            {
                log.Error("Error saving payment notice to DB" + exp.Message);
                throw;
            }
        }
        
        private static PaymentNotice buildPaymentNotice(PaymentResult paymentresult)
        {
            var transResultCode = paymentresult.resultCode.Replace("Authorised", "AUTHORISATION").Replace("Refused", "REFUSED");
            var paymentNotice = new PaymentNotice
                                    {
                                        paymentRef = paymentRef,
                                        reason = paymentresult.refusalReason,
                                        transactionId = paymentresult.pspReference,
                                        type = transResultCode,
                                        success = true
                                    };

            return paymentNotice;
         }

      

    }
}