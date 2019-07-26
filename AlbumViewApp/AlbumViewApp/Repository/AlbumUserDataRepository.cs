using AlbumViewApp.Models.Home;
using AlbumViewApp.Models.ThumbNail;
using AlbumViewApp.Models.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlbumViewApp.Service;

namespace AlbumViewApp.Repository
{
    public class AlbumUserDataRepository
    {

        public static List<AlbumViewModel> GetAlbumUserData()
        {
            var userDataAsync = Service.APICallService.GetUserAsync();
            var userData = (List<UserDetailsViewModel>)userDataAsync.Result;
            var albumDataAsyc = Service.APICallService.GetAlbumAsync();
            var albumData = (List<AlbumViewModel>)albumDataAsyc.Result;
            var photoDataAsync = Service.APICallService.GetPhotoAsync();
            var photoData = (List<ThumbNailViewModel>)photoDataAsync.Result;

            foreach (var album in albumData)
            {

                var photodatas = from photo in photoData
                                 orderby photo.Id
                                 select photo;
                album.ThumbNailUrl = photodatas.Where(a => a.AlbumId == album.Id).FirstOrDefault().ThumbNailUrl;
                foreach (var user in userData)
                {
                    if (album.UserId == user.Id)
                    {
                        album.Name = user.Name;
                        album.UserId = user.Id;
                        album.Phone = user.Phone;
                        album.Email = user.Email;
                        album.Address = user.Address;
                    }

                }
            }
            return albumData;
        }


        public static List<AlbumViewModel> GetSearchData(string searchfiltertype, string searchstring, List<AlbumViewModel> albumList)
        {
            //var albumData = Repository.AlbumUserDataRepository.GetAlbumUserData();
            IEnumerable<AlbumViewModel> userAlbumList = new List<AlbumViewModel>();
            if (searchfiltertype == "AuthorName" && !String.IsNullOrEmpty(searchstring))
            {             
                
                userAlbumList = from album in albumList
                                where album.Name.Contains(searchstring.Trim())
                                select album;
            }
            else if (searchfiltertype == "Title" && !String.IsNullOrEmpty(searchstring))
            {
               
                userAlbumList = from album in albumList
                                where album.Title.Contains(searchstring.Trim())
                                select album;
            }

            return userAlbumList.ToList();

        }


        public static List<ThumbNailViewModel> GetThumbNailData(string albumid)
        {
            var albumDataAsyc = Service.APICallService.GetAlbumAsync();

            var albumData = (List<AlbumViewModel>)albumDataAsyc.Result;
            var photoDataAsync = Service.APICallService.GetPhotoAsync();
            var photoData = (List<ThumbNailViewModel>)photoDataAsync.Result;            
            var photodatas = from photo in photoData
                             where photo.AlbumId == albumid
                             select photo;
            IEnumerable<ThumbNailViewModel> Photolist = (IEnumerable<ThumbNailViewModel>)photodatas;

            return Photolist.ToList();

        }
        public static List<AlbumViewModel> GetAlbumData(string albumid)
        {
            IEnumerable<AlbumViewModel> albumlist = new List<AlbumViewModel>();
            if (!String.IsNullOrEmpty(albumid))
            { 
            var albumDataAsyc = Service.APICallService.GetAlbumAsync();

            var albumData = (List<AlbumViewModel>)albumDataAsyc.Result;         
            var albumdatas = from album in albumData
                             where album.Id == albumid
                             select album;
                    albumlist = (IEnumerable<AlbumViewModel>)albumdatas;

            
            }
            return albumlist.ToList();
        }

        public static List<UserDetailsViewModel> GetUserData(string userid)
        {

            IEnumerable<UserDetailsViewModel> userlist = new List<UserDetailsViewModel>();
            if (!String.IsNullOrEmpty(userid))
            {
                var userDataAsyc = Service.APICallService.GetUserAsync();

                var userData = (List<UserDetailsViewModel>)userDataAsyc.Result;
                var userdatas = from user in userData
                                 where user.Id == userid
                                 select user;
                userlist = (IEnumerable<UserDetailsViewModel>)userdatas;


            }
            return userlist.ToList();

        }

        public static List<PostModel> GetUserPostData(string userid)
        {

            IEnumerable<PostModel> userlist = new List<PostModel>();
            if (!String.IsNullOrEmpty(userid))
            {
                var userPostDataAsyc = Service.APICallService.GetUserPostAsync();

                var userPostData = (List<PostModel>)userPostDataAsyc.Result;
                var userPostdatas = from post in userPostData
                                where post.UserId == userid
                                select post;
                userlist = (IEnumerable<PostModel>)userPostdatas;


            }
            return userlist.ToList();

        }


    }




}