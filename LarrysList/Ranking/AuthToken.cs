using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class AuthToken
    {

        private static string email = Globals.Instance.settings["RankApiEmail"];
        private static string pwd= Globals.Instance.settings["RankApiPwd"]; 

        public static string getAuthToken()
        {

            //get auth token 
            /*
             * request example 
             * url:
             * https://www.google.com/accounts/ClientLogin
             * header:
             * POST /accounts/ClientLogin HTTP/1.0
             * Content-type: application/x-www-form-urlencoded
             * body:
             * accountType=HOSTED_OR_GOOGLE&Email=jondoe@gmail.com&Passwd=north23AZ&service=cl&
             * source=Gulp-CalGulp-1.05
            */
            //here will be my token
            var myAuthToken = "";

            WebRequest request_auth = WebRequest.Create("https://www.google.com/accounts/ClientLogin");

            //header settings
            request_auth.Method = "POST";
            request_auth.ContentType = "application/x-www-form-urlencoded";
            //body settings
            string body_auth = "accountType=google&Email=" + email + "&Passwd=" + pwd + "&service=cprose";
            byte[] byteArray_auth = Encoding.UTF8.GetBytes(body_auth);
            request_auth.ContentLength = byteArray_auth.Length;
            Stream dataStream_auth = request_auth.GetRequestStream();
            // Write the data to the request stream.
            dataStream_auth.Write(byteArray_auth, 0, byteArray_auth.Length);
            // Close the Stream object.
            dataStream_auth.Close();
            // Get the response.
            WebResponse response_auth = request_auth.GetResponse();

            dataStream_auth = response_auth.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader_auth = new StreamReader(dataStream_auth);
            // Read the content.
            string responseFromServer_auth = reader_auth.ReadToEnd();
            //celan up
            dataStream_auth.Close();
            reader_auth.Close();
            response_auth.Close();

            //now get the token information out of responce
            char[] delimiterChars = { '\n' };
            string[] words = responseFromServer_auth.Split(delimiterChars);
            char[] delimiterChars_auth = { '=' };
            foreach (string s in words)
            {
                if (s.Contains("Auth"))
                {
                    string[] auth = s.Split(delimiterChars_auth);
                     myAuthToken = auth[1];
                }
            }
            return myAuthToken;
        }

    }
}
