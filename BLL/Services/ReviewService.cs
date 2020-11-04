using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using AutoMapper;

namespace BLL.Services
{
    public class ReviewService : IReviewService
    {
        IUnitOfWork Database { get; set; }

        public ReviewService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void AddReview(string name, string comment, DateTime date)
        {
            Review review = new Review
            {
                Name = name,
                Comment = comment,
                Date = date
            };
            Database.Review.Add(review);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ReviewDTO> GetAllReviews()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Review>, List<ReviewDTO>>(Database.Review.Get());
        }
    }
}
