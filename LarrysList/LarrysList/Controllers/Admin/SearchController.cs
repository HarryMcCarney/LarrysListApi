using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LarrysList.Models;

namespace LarrysList.Controllers.Admin
{
    public class SearchController : BaseController
    {
        public string address(AddressSearch search)
        {
            try
            {
                result = orm.execObject<Result>(search, "api.admin_search_address");
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
                result = orm.execObject<Result>(search, "api.admin_search_collector");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string artist(ArtistSearch search)
        {
            try
            {
                result = orm.execObject<Result>(search, "api.admin_artist_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }
        public string theme(ThemeSearch search)
        {
            try
            {
                result = orm.execObject<Result>(search, "api.admin_theme_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string origin(OriginSearch origin)
        {
            try
            {
                result = orm.execObject<Result>(origin, "api.admin_origin_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string interest(InterstSearch interest)
        {
            try
            {
                result = orm.execObject<Result>(interest, "api.admin_interest_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string medium(MediumSearch medium)
        {
            try
            {
                result = orm.execObject<Result>(medium, "api.admin_medium_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string genre(GenreSearch genre)
        {
            try
            {
                result = orm.execObject<Result>(genre, "api.admin_genre_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }
    }
}
