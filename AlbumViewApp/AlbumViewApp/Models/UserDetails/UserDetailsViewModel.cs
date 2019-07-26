using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumViewApp.Models.UserDetails
{
    public class UserDetailsViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public UserAddress Address { get; set; }
        public string Id { get; set; }
        public string Website { get; set; }

        public Company Company { get; set; }

    }


    public class UserAddress
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public geom geo { get; set; }
    }

    public class geom
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }

    public class PostModel
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}