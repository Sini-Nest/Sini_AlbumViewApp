using AlbumViewApp.Logger;
using AlbumViewApp.Models.ThumbNail;
using AlbumViewApp.Models.UserDetails;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AlbumViewApp.Models.Home;
using System.Diagnostics;

namespace AlbumViewApp.Service
{
    public class APICallService
    {
        public static async Task<List<UserDetailsViewModel>> GetUserAsync()
        {
            List<UserDetailsViewModel> userList = null;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.GetAsync(new Uri("https://jsonplaceholder.typicode.com/users"));
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var userListfromAPI = await response.Result.Content.ReadAsStringAsync();
                        userList = JsonConvert.DeserializeObject<List<UserDetailsViewModel>>(userListfromAPI);

                    }
                }
                catch (Exception ex)
                {
                    EventLogger.LogError("AlbumViewApp", string.Format("Error while reading User Data from API", ex.Message), EventLogEntryType.Error);
                }
            }
            return userList;
        }
        public static async Task<List<AlbumViewModel>> GetAlbumAsync()
        {
            List<AlbumViewModel> albumList = null;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.GetAsync(new Uri("https://jsonplaceholder.typicode.com/albums"));
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var albumListFromAPI = await response.Result.Content.ReadAsStringAsync();
                        albumList = JsonConvert.DeserializeObject<List<AlbumViewModel>>(albumListFromAPI);

                    }
                }
                catch (Exception ex)
                {
                    EventLogger.LogError("AlbumViewApp", string.Format("Error while reading Album Data from API", ex.Message), EventLogEntryType.Error);
                }
            }

            return albumList;
        }
        public static async Task<List<ThumbNailViewModel>> GetPhotoAsync()
        {
            List<ThumbNailViewModel> photoList = null;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.GetAsync(new Uri("https://jsonplaceholder.typicode.com/photos"));
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var photoListfromAPI = await response.Result.Content.ReadAsStringAsync();
                        photoList = JsonConvert.DeserializeObject<List<ThumbNailViewModel>>(photoListfromAPI);

                    }
                }
                catch (Exception ex)
                {
                    EventLogger.LogError("AlbumViewApp", string.Format("Error while reading Photos from API", ex.Message), EventLogEntryType.Error);

                }
            }
            return photoList;
        }
        public static async Task<List<PostModel>> GetUserPostAsync()
        {
            List<PostModel> postList = null;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = httpClient.GetAsync(new Uri("https://jsonplaceholder.typicode.com/posts"));
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var postListfromAPI = await response.Result.Content.ReadAsStringAsync();
                        postList = JsonConvert.DeserializeObject<List<PostModel>>(postListfromAPI);

                    }
                }
                catch (Exception ex)
                {
                    EventLogger.LogError("AlbumViewApp", string.Format("Error while reading Photos from API", ex.Message), EventLogEntryType.Error);

                }
            }
            return postList;
        }
    }
}