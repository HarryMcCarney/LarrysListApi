using System;
using System.IO;
using System.Web;
using LarrysList.Auth;
using LarrysList.Controllers;
using LarrysList.Services.GlobalConfig;


namespace LarrysList.Controllers.Admin
{
    public class ResourcesController : BaseController
    {
        private readonly string uploadPath;

        public ResourcesController()
        {
            uploadPath = Globals.Instance.settings["UploadPath"];
        }
        [AuthClient]
        public string index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {

                string extension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + extension;
                var path = Path.Combine(uploadPath, fileName);
                file.SaveAs(path);
                result.status = 0;
                result.Upload = new Models.Upload() { file = fileName };
            }
            else
            {
                result.status = 1;
                result.errorMessage = "Upload failed";
            }
            return formattedResult(result);
        }

        
    }
}
