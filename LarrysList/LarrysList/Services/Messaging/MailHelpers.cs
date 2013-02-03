using BurnPlus.Services.Messaging.Templates;
using LarrysList.Models;
using LarrysList.Services.GlobalConfig;

namespace LarrysList.Services.Messaging
{
    public static class MailHelpers
    {

        public static void sendPwdForgot(this Feeder feeder)
        {
            var messaging = new MessagingService();
            var resetUrl = getUrl(Globals.Instance.settings["WebHost"],
                                    Globals.Instance.settings["UserPwdReset"], feeder.activationToken);

            var forgotPwdEmail = new ForgotPwdEmail(feeder.email, resetUrl, feeder.name);
            messaging.enqueueMessage(forgotPwdEmail);
        }

        private static string getUrl(string host, string link, string token)
        {
            return string.Format("{0}{1}{2}{3}", "http://", host, link, token);
        }

    }

   
}