using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Facebook;

namespace Web.Controllers
{
    public class FacebookController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            ViewBag.Message = "Facebook";

            return View();
        }
        #endregion

        public void CheckAuth()
        {
            var app_id = "1421383058109198";
            var app_secret = "e45b1d2bd8fc0369f5ead8ce9ec93e41";
            var scope = "publish_stream, manage_pages";
 
            if (Request["code"] == null)
            {
                Response.Redirect(string.Format(
                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope));
            }
            else
            {
                var tokens = new Dictionary<string, string>();
 
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);
 
                var request = WebRequest.Create(url) as HttpWebRequest;
 
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    var reader = new StreamReader(response.GetResponseStream());
 
                    var vals = reader.ReadToEnd();
 
                    foreach (var token in vals.Split('&'))
                    {
                        tokens.Add(token.Substring(0, token.IndexOf("=")),
                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                    }
                }
 
                var access_token = tokens["access_token"];

                Debug.WriteLine(access_token);

                var client = new FacebookClient(access_token);

                //client.Post("/me/feed", new { message = "I'm testing my application" });
            }

            RedirectToAction("Index", "Home");
        }
    }
}