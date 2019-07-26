using AlbumViewApp.Models.Home;
using AlbumViewApp.Models.ThumbNail;
using AlbumViewApp.Models.UserDetails;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Threading.Tasks;
using System.Net.Http;
using AlbumViewApp.Logger;
using System.Diagnostics;

namespace AlbumViewApp.Controllers
{
    public class HomeController : Controller
    {

        static List<AlbumViewModel> albumList = new List<AlbumViewModel>();
        int pageSize = 10;
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(string searchfiltertype, string searchstring, int? pageNumber)
        {
            try
            {               
                     var albumData = Repository.AlbumUserDataRepository.GetAlbumUserData();
                    albumList = albumData.ToList();           
                    if (searchstring != null)
                    {
                        albumList = Search(searchfiltertype, searchstring, pageNumber);
                    }                  
                    ViewBag.searchfiltertype = searchfiltertype;
                    ViewBag.searchstring = searchstring;
                    return View("Index", albumList.ToPagedList(pageNumber ?? 1, pageSize));
            }
            catch (Exception ex)
            {
                EventLogger.LogError("AlbumViewApp", string.Format("Error while Loading Model data ", ex.Message), EventLogEntryType.Error);
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }

        }

        public List<AlbumViewModel> Search(string searchfiltertype, string searchstring, int? pagenumber)
        {                         
             var userAlbumList= Repository.AlbumUserDataRepository.GetSearchData(searchfiltertype, searchstring, albumList);                      
            return userAlbumList;
        }

        
    }
}