using System;
using DBVC;
using LarrysList.Auth;
using LarrysList.Models;
using Newtonsoft.Json.Linq;

namespace LarrysList.Controllers.Admin
{
    public class CollectionController : BaseController
    {
  
        public string create(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_create");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string basicEdit(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_base_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string artistEdit(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_artist_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }
        public string communicationEdit(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_communication_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        [AuthClient]
        public string document(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_document_assign");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string theme(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_theme_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }
        [AuthClient]
        public string origin(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_origin_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

      
        [AuthClient]
        public string metaSet()
        {
            try
            {
                var jsonProc = new MSSQLData();
                var jsonresult = jsonProc.execStoredProc("api.admin_collection_set_meta_json", JsonObjectId, jsonParam);
                if (jsonresult != null)
                    result.json = JObject.Parse(jsonresult);
                result.procName = "api.admin_collection_set_meta_json";
                result.status = 0;
               
            }
            catch (Exception exp)
            {
                errorResult(exp);
               
            }
            return formattedResult(result);

        }
        [AuthClient]
        public string meta()
        {
            try
            {
                var jsonProc = new MSSQLData();
                var jsonresult = jsonProc.execStoredProc("api.admin_collection_meta_json", JsonObjectId, null);
                if (jsonresult != null)
                    result.json = JObject.Parse(jsonresult);
                result.procName = "api.admin_collection_meta_json";
                result.status = 0;

            }
            catch (Exception exp)
            {
                errorResult(exp);

            }
            return formattedResult(result);

        }

    }
}
