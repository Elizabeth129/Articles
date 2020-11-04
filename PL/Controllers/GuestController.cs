using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using PL.Models;
using PL.ViewModel;

namespace PL.Controllers
{
    public class GuestController : Controller
    {
        IReviewService reviewService;
        List<Review> Reviews;
        public GuestController(IReviewService serv)
        {
            reviewService = serv;
            IEnumerable<ReviewDTO> reviews = reviewService.GetAllReviews();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>()).CreateMapper();
            Reviews = mapper.Map<IEnumerable<ReviewDTO>, List<Review>>(reviews);
        }
        // GET: Guest
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;
            IEnumerable<Review> reviewsPerPages = Reviews.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = Reviews.Count };
            ReviewIndex ivm = new ReviewIndex { PageInfo = pageInfo, Reviews = reviewsPerPages, ReviewNew = new Review()};
            return View(ivm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ResponsesAdd(ReviewIndex review)
        {
            //var reviewDTO = new ReviewDTO { Name = review.Name, Comment = review.Comment, Date = DateTime.Now };
            
            if (ModelState.IsValid)
            {
                reviewService.AddReview(review.ReviewNew.Name, review.ReviewNew.Comment, DateTime.Now);
                return RedirectToAction("Index");
            }
            else
            {
                int page = 1;
                int pageSize = 3;
                IEnumerable<Review> reviewsPerPages = Reviews.Skip((page - 1) * pageSize).Take(pageSize);
                PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = Reviews.Count };
                ReviewIndex ivm = new ReviewIndex { PageInfo = pageInfo, Reviews = reviewsPerPages, ReviewNew = new Review() };
                return View("Index", ivm);
            }
        }
    }
}