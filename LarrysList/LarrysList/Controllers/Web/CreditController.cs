using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LarrysList.Models;
using LarrysList.Services.PaymentService;

namespace LarrysList.Controllers.Web
{
    public class CreditController : BaseController
    {
        public string buy(Payment payment)
        {
            try
            {
                result.PaymentStatus = new Pay(payment, payment.userToken).makePayment();
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
