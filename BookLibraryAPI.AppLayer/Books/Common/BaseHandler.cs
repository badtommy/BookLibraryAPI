using BookLibraryAPI.Domain.Interfaces;

namespace BookLibraryAPI.AppLayer.Books.Common
{
    public abstract class BaseHandler
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
