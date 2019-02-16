using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoReviews.DAL.Domain.Repositories;

namespace VideoReviews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var videoRepository = new VideoRepository(new DAL.VideoReviewsContext(), 1);            
            return View(videoRepository.VideosWithUser());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}