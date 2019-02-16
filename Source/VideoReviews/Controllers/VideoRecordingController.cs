using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoReviews.Controllers
{
    public class VideoRecordingController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadReview(long videoId, HttpPostedFileBase file)
        {
            var videoName = $"{Guid.NewGuid().ToString()}.webm";
            string nameAndLocation = $"~/Reviews/video{videoId}/{videoName}";
            file.SaveAs(Server.MapPath(nameAndLocation));
            return Json("ok");
        }
    }
}