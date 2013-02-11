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
    }
}
