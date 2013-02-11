using System;
using LarryList.Services.PaymentService;
using LarrysList.Services.GlobalConfig;
using LarrysList.comadyenpaltest;
using LarrysList.Models;
using NLog;
using Payment = LarrysList.Models.Payment;
using adyen = LarrysList.comadyenpaltest;




namespace LarrysList.Services.PaymentService
{

    public class ProcessPayment
    {

        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private PaymentStatus paymentStatus;
        private adyen.Payment paymentEndPoint;
        private Payment payment;

        public ProcessPayment(Payment _payment)
        {
            payment = _payment;
            paymentStatus = new PaymentStatus();
            paymentEndPoint = new PaymentEndPoint().paymentService;
        }

        public PaymentStatus pay()
        {

            validate();
            if (paymentStatus.success)
                makePayment();


            return paymentStatus;
        }


        private void makePayment()
        {
            try
            {
                var response = paymentEndPoint.authorise(buildPaymentRequest());
                payment.transactionId = response.pspReference;
                CreatePaymentNotice.createSave(payment, response);
                paymentStatus.success = (response.resultCode != "Refused");
                paymentStatus.message = (paymentStatus.success) ? "PAYMENT_SUCCESSFUL" : "PAYMENT_FAILED";
            }

            catch (Exception exp)
            {
                paymentStatus.success = false;
                paymentStatus.message = exp.Message;
                log.Error(exp);
            }

        }


        private void validate()
        {
            paymentStatus = PaymentValidator.validatePayment(payment);
        }

        private PaymentRequest buildPaymentRequest()
        {
            try
            {
                var request = new PaymentRequest
                    {
                        merchantAccount = Globals.Instance.settings["AdyenMerchantAccount"],
                        amount = new Amount {currency = payment.currency, value = payment.amount},
                        reference = payment.paymentRef
                    };
                    if (payment.useSavedDetails)
                    {
                        request.card = new Card {cvc = payment.cvs};
                        request.selectedRecurringDetailReference =
                            new RecurringDetailsEndPoint().getRecurringDetail(payment.shopperRef);
                    }
                    else
                    {
                        request.card = new Card
                            {
                                brand = payment.method.ToLower(),
                                cvc = payment.cvs,
                                expiryMonth = payment.expiryMonth,
                                expiryYear = payment.expiryYear,
                                holderName = payment.holder,
                                number = payment.number
                            };
                    }

                    request.recurring = new Recurring() {contract = "ONECLICK"};
                    request.shopperReference = payment.shopperRef;
                    request.shopperEmail = payment.shopperRef;

                    return request;
                }
            
            catch
                (Exception exp)
            {
                log.Error(exp);
                throw;
            }

        }


       


       
    }

    }
