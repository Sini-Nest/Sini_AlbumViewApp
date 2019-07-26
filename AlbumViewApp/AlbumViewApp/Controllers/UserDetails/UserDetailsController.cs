using AlbumViewApp.Models.Home;
using AlbumViewApp.Models.UserDetails;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlbumViewApp.Logger;
using System.Diagnostics;

namespace AlbumViewApp.Controllers.UserDetails
{
    public class UserDetailsController : Controller
    {
        // GET: UserDetails
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult UserDetailsView(string userid)
        {
            try
            {
                var userData = Repository.AlbumUserDataRepository.GetUserData(userid);

                var PostData = Repository.AlbumUserDataRepository.GetUserPostData(userid);
                ViewData["postdata"] = PostData;

                return View("UserDetailsView", userData);
            }
            catch (Exception ex)
            {

                EventLogger.LogError("AlbumViewApp", string.Format("Error while Loding UserDetails", ex.Message), EventLogEntryType.Error);
                return View("Error", new HandleErrorInfo(ex, "UserDetails", "UserDetailsView"));
            }

        }

    }
}