using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoReviews.DAL.Domain.Entities;
using VideoReviews.DAL.Domain.Repositories;

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
            try
            {
                string nameAndLocation = $"/Reviews/{videoName}";
                file.SaveAs(Server.MapPath(nameAndLocation));

                VideoReview review = new VideoReview()
                {
                    VideoID = videoId,
                    Url = nameAndLocation
                };
                VideoReviewRepository videoReviewRepository = new VideoReviewRepository(new DAL.VideoReviewsContext());
                videoReviewRepository.Add(review);
                videoReviewRepository.PersistChanges();
            } catch (Exception ex)
            {

            }
            
            return Json("ok");
        }
    }
}