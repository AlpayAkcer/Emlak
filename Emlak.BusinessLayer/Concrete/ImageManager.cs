using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class ImageManager : ImageService
    {
        IImagesRepository _imagesRepository;

        public ImageManager(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }

        public void TAdd(Images entity)
        {
            _imagesRepository.Add(entity);
        }

        public void TDelete(Images entity)
        {
            _imagesRepository.Delete(entity);
        }

        public Images TGetByID(int id)
        {
            return _imagesRepository.GetByID(id);
        }

        public List<Images> TGetListFilter(Expression<Func<Images, bool>> filter)
        {
            return _imagesRepository.GetListFilter(filter);
        }

        public List<Images> TGetList()
        {
            return _imagesRepository.GetList();
        }

        public void TUpdate(Images entity)
        {
            var update = _imagesRepository.GetByID(entity.ImagesID);
            _imagesRepository.Update(entity);
        }
    }
}
