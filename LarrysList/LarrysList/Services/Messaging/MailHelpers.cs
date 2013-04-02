using BurnPlus.Services.Messaging.Templates;
using LarrysList.Models;
using LarrysList.Services.GlobalConfig;

namespace LarrysList.Services.Messaging
{
    public static class MailHelpers
    {
        //feeder
        public static void sendPwdForgot(this Feeder feeder)
        {
            var messaging = new MessagingService();
            var resetUrl = getUrl(Globals.Instance.settings["WebHost"],
                                    Globals.Instance.settings["AdminPwdReset"], feeder.activationToken);

            var forgotPwdEmail = new ForgotPwdEmail(feeder.email, resetUrl, feeder.name);
            messaging.enqueueMessage(forgotPwdEmail);
        }


        public static void sendWelcomeEmail(this Feeder feeder)
        {
            var messaging = new MessagingService();

            var welcomeEmail = new WelcomeEmail(feeder.email, feeder.name);
            messaging.enqueueMessage(welcomeEmail);
        }

        //user
        public static void sendWelcomeEmailUser(this User user)
        {
            var messaging = new MessagingService();

            var welcomeEmail = new WelcomeEmailUser(user.email, user.name);
            messaging.enqueueMessage(welcomeEmail);
        }


        public static void sendPwdForgotUser(this User user)
        {
            var messaging = new MessagingService();
            var resetUrl = getUrl(Globals.Instance.settings["WebHost"],
                                    Globals.Instance.settings["UserPwdReset"], user.activationToken);

            var forgotPwdEmail = new ForgotPwdEmailUser(user.email, resetUrl, user.name);
            messaging.enqueueMessage(forgotPwdEmail);
        }

        //buyer
        public static void sendReceiptEmail(this Payment pay)
        {
            var messaging = new MessagingService();
            var forgotPwdEmail = new SendReceiptEmail(pay.paymentRef,(pay.amount/100).ToString(), pay.currency, pay.shopperEmail, pay.accountHolderName);
            messaging.enqueueMessage(forgotPwdEmail);
        }

        private static string getUrl(string host, string link, string token)
        {
            return string.Format("{0}{1}{2}{3}", "http://", host, link, token);
        }
    }


}