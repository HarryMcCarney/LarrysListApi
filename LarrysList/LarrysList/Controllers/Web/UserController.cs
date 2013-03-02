using System;
using LarrysList.Auth;
using LarrysList.Models;



namespace LarrysList.Controllers.Web
{
    public class UserController : BaseController
    {
        [AuthClient]
        public string signUp(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_email_signup");
                 if (result.dbMessage == null)
                {
                    //result.User.sendWelcomeEmail();
                }
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string login(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_login");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        [AuthClient]
        public string updatePwd(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_update_pwd");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        [AuthClient]
        public string forgotPwd(User user)
        {
            try
            {
                user.activationToken = Guid.NewGuid().ToString();
                result = orm.execObject<Result>(user, "api.user_pwd_forgot");
                if (result.dbMessage == null)
                {
                   // result.User.sendPwdForgot();
                }
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        [AuthClient]
        public string resendForgotPwd(User user)
        {
            try
            {
                user.activationToken = Guid.NewGuid().ToString();
                result = orm.execObject<Result>(user, "api.user_resend_pwd_forgot");
                if (result.dbMessage == null)
                {
                   // result.User.sendPwdForgot();
                }
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string token(LoginLink loginLink)
        {
            try
            {
                result = orm.execObject<Result>(loginLink, "api.user_login_link");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);

        }


        [AuthClient]
        public string emailAvailable(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_email_available");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string profile(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_profile");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string getCollector(User user)
        {
            try
            {
                result = orm.execObject<Result>(user, "api.user_collector_get");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


       

    }
}
