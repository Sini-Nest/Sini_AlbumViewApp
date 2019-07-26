using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlbumViewApp.Models.UserDetails;

namespace AlbumViewApp.Models.Home
{
    public class HomeIndexViewModel
    {
       
    }

    public class AlbumViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public UserAddress Address { get; set; }
        public string Id { get; set; }

        public string Title { get; set; }
        public string ThumbNailUrl { get; set; }
    }



}