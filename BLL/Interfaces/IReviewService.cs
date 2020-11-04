using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetAllReviews();

        void AddReview(string name, string comment, DateTime date);
        void Dispose();
    }
}
