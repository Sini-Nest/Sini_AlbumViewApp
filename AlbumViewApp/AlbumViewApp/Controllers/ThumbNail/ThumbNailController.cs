using AlbumViewApp.Logger;
using AlbumViewApp.Models.Home;
using AlbumViewApp.Models.ThumbNail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlbumViewApp.Controllers.ThumbNail
{
    public class ThumbNailController : Controller
    {
        // GET: ThumbNail
        public ActionResult Index()
        {
            return View();
        }
        public  ActionResult ThumbNailView(string albumid,string title)
        {
            try
            {               
                var photoData = Repository.AlbumUserDataRepository.GetThumbNailData(albumid);

                ViewData["AlbumTitle"] = title;

                return View(photoData);
            }
            catch (Exception ex)
            {

                EventLogger.LogError("AlbumViewApp", string.Format("Error while Loding UserDetails", ex.Message), EventLogEntryType.Error);
                return View("Error", new HandleErrorInfo(ex, "UserDetails", "UserDetailsView"));
            }

        }
    }
}