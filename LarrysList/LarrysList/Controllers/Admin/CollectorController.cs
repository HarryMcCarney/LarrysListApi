using System;
using DBVC;
using LarrysList.Auth;
using LarrysList.Models;
using Newtonsoft.Json.Linq;

namespace LarrysList.Controllers.Admin
{
    public class CollectorController : BaseController
    {

        [AuthClient]
        public string index(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collector_get");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        [AuthClient]
        public string create(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collector_create");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string contactEdit(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collector_contacts_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        [AuthClient]
        public string basicEdit(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collector_base_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string businessEdit(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collector_business_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string sourceEdit(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_source_edit");
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
                result = orm.execObject<Result>(collector, "api.admin_collector_document_assign");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string fact(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collector_fact_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        [AuthClient]
        public string status(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collector_status_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        [AuthClient]
        public string directorMuseum(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collector_director_nuseum_edit");
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
                var jsonresult = jsonProc.execStoredProc("api.admin_collector_set_meta_json", JsonObjectId, jsonParam);
                if (!string.IsNullOrEmpty(jsonresult))
                    result.json = JObject.Parse(jsonresult);
                result.procName = "api.admin_collector_set_meta_json";
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
                var jsonresult = jsonProc.execStoredProc("api.admin_collector_meta_json", JsonObjectId, null);
                if (!string.IsNullOrEmpty(jsonresult))
                    result.json = JObject.Parse(jsonresult);
                result.procName = "api.admin_collector_meta_json";
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
