using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumViewApp.Models.ThumbNail
{
    public class ThumbNailViewModel
    {
        public string AlbumId { get; set; }
        public string Id { get; set; }
        public string ThumbNailUrl { get; set; }
        public string Title { get; set; }
    }
}