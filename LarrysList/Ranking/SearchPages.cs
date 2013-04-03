using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ranking
{

    public static class SearchPages
    {


        public static string user = Globals.Instance.settings["RankApiUser"];
        public static string cse =  Globals.Instance.settings["RankApiCse"];
        public static List<string> pages = Globals.Instance.rankPages;
        private static string token;

        public static void createSearchPages() 
        {
            token = AuthToken.getAuthToken();
           
            WebRequest request = WebRequest.Create("http://www.google.com/cse/api/" + user + "/annotations/" + cse);
            // Setting the header
            request.Method = "POST";
            request.Headers.Add("Authorization: GoogleLogin auth=" + token);
            request.ContentType = "text/xml";
            // Create POST data and convert it to a byte array.
            //post data have xml structure
            XElement batch = new XElement("Batch");
            XElement add = new XElement("Add");
            XElement ann = new XElement("Annotations");
            XElement label = new XElement("Label");
            label.SetAttributeValue("name", "_cse_" + cse);
            XElement temp = null;
            foreach (string p in pages)
            {

                temp = new XElement("Annotation");
                temp.SetAttributeValue("about", p + "/*");
                temp.Add(label);
                ann.Add(temp);
            }
            add.Add(ann);
            batch.Add(add);

            //write xml to body
            byte[] byteArray = Encoding.UTF8.GetBytes(batch.ToString());
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);       
            response.Close();   
        
        }

        public static void deleteSearchPages() 

        {
            token = AuthToken.getAuthToken();

            /*get all annotations - sites
            * GET http://www.google.com/cse/api/<USER_ID>/cse/<CSE_ID>/annotations/
            * Authorization: GoogleLogin auth="IM6F7Cx2fo0TAiwlhNVdSE8Ov8hw6aHV"
           */
            WebRequest request_getList = WebRequest.Create("http://www.google.com/cse/api/" + user + "/annotations/" + cse);
            //set header
            request_getList.Headers.Add("Authorization: GoogleLogin auth=" + token);
            request_getList.Method = "GET";
            //get responce
            WebResponse response_getList = request_getList.GetResponse();
            Stream stream = response_getList.GetResponseStream();
            //get responce in xml
            XDocument doc = XDocument.Load(stream);
            //celan up
            response_getList.Close();
            stream.Close();

            //build delete xml with using the responce
            XElement batch = new XElement("Batch");
            XElement delete = new XElement("Remove");
            XElement ann = new XElement("Annotations");
            //create deletein xml
            XElement temp = null;
            foreach (XElement element in doc.Descendants("Annotation"))
            {
                temp = new XElement("Annotation");
                temp.SetAttributeValue("href", (string)element.Attribute("href"));
                ann.Add(temp);
            }
            delete.Add(ann);
            batch.Add(delete);

            /********************************************/
            //delete all the sites

            WebRequest request = WebRequest.Create("http://www.google.com/cse/api/" + user + "/annotations/" + cse);
            // Setting the header
            request.Method = "POST";
            request.Headers.Add("Authorization: GoogleLogin auth=" + token);
            request.ContentType = "text/xml";
            // Create POST data and convert it to a byte array.
            //post data have xml structure
            byte[] byteArray = Encoding.UTF8.GetBytes(batch.ToString());
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // string x = Console.ReadLine();
            response.Close();
        }

    }
}
