using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LarrysList.Models;

namespace LarrysList.Controllers
{
    public class ArtistController : BaseController
    {

        public string create(Artist artist)
        {
            try
            {
                result = orm.execObject<Result>(artist, "api.admin_artist_create");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


        public string artwork(Collection collection)
        {
            try
            {
                result = orm.execObject<Result>(collection, "api.admin_artwork_create");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }


    }
}
