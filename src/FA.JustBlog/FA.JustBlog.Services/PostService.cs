using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;

namespace FA.JustBlog.Services
{
    public class PostService : BaseServices<Post>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
