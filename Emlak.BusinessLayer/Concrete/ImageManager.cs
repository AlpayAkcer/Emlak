using Emlak.BusinessLayer.Abstract;
using Emlak.DataAccessLayer.Abstract;
using Emlak.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Emlak.BusinessLayer.Concrete
{
    public class ImageManager : GenericService<Images>
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

        public List<Images> TGetListAll()
        {
            return _imagesRepository.GetListAll();
        }

        public void TUpdate(Images entity)
        {
            _imagesRepository.Update(entity);
        }
    }
}
