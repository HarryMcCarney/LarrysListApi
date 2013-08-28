using LarrysList.Models;
using System;


namespace LarrysList.Controllers.Web
{
    public class SearchController : BaseController
    {
        public string typeAhead(TypeAhead search)
        {
            try
            {
                result = orm.execObject<Result>(search, "api.user_type_ahead");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string collector(CollectorSearch search)
        {
            try
            {
                result = orm.execObject<Result>(search, "api.user_collector_search_filtered");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string myCollector(CollectorSearch search)
        {
            try
            {
                search.my = true;
                result = orm.execObject<Result>(search, "api.user_collector_search_filtered");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string recommended(CollectorSearch search)
        {
            try
            {
                
                result = orm.execObject<Result>(search, "api.user_recommended_collectors");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string addressTypeAhead(Search search)
        {
            try
            {

                result = orm.execObject<Result>(search, "api.user_address_type_ahead");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string artistTypeAhead(Search search)
        {
            try
            {

                result = orm.execObject<Result>(search, "api.user_artist_type_ahead");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
