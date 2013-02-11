﻿using System.Linq;
using System.Net;
using LarrysList.Services.GlobalConfig;
using LarrysList.com.adyen.palliveRecurring;
using Recurring = LarrysList.com.adyen.palliveRecurring.Recurring;

namespace LarrysList.Services.PaymentService
{
    public class RecurringDetailsEndPoint
    {
        private readonly string adyenRecurringEndPoint;
        private readonly string adyenUser;
        private readonly string adyenPwd;
        private readonly string adyenMerchantAccount;
        public Recurring recurringService;


        public RecurringDetailsEndPoint()
        {

            adyenMerchantAccount = Globals.Instance.settings["AdyenMerchantAccount"];
            adyenRecurringEndPoint = Globals.Instance.settings["AdyenRecurringEndPoint"];
            adyenUser = Globals.Instance.settings["AdyenUser"];
            adyenPwd = Globals.Instance.settings["AdyenPwd"];
            recurringService = new Recurring
            {
                Credentials = new NetworkCredential(adyenUser, adyenPwd),
                Url = adyenRecurringEndPoint
            };
        }

        public string getRecurringDetail(string shopperRef)
        {
            var request = new RecurringDetailsRequest { merchantAccount = adyenMerchantAccount, shopperReference = shopperRef };

            var response = recurringService.listRecurringDetails(request);

            var details = from detail in response.details orderby detail.creationDate descending select detail;

            return details.First().recurringDetailReference;
        }


    }
}