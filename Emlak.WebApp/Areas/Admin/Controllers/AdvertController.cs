using Emlak.BusinessLayer.Abstract;
using Emlak.BusinessLayer.ValidationRules;
using Emlak.Dto.AdvertDto;
using Emlak.EntityLayer.Entities;
using Emlak.WebApp.ResultMessage;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NToastNotify;

namespace Emlak.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdvertController : Controller
    {
        private readonly AdvertService _advertService;
        private readonly CityService _cityService;
        private readonly DistrictService _districtService;
        private readonly NeightbourhoodService _neightbourhoodService;
        private readonly SituationService _situationService;
        private readonly AdvertTypeService _advertTypeService;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ImageService _imageService;

        public AdvertController(AdvertService advertService, CityService cityService, DistrictService districtService, NeightbourhoodService neightbourhoodService, SituationService situationService, AdvertTypeService advertTypeService, IWebHostEnvironment webHostEnvironment, IToastNotification toastNotification, ImageService imageService)
        {
            _advertService = advertService;
            _cityService = cityService;
            _districtService = districtService;
            _neightbourhoodService = neightbourhoodService;
            _situationService = situationService;
            _advertTypeService = advertTypeService;
            _webHostEnvironment = webHostEnvironment;
            _toastNotification = toastNotification;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string UserID = HttpContext.Session.GetString("ID");
            //Giriş yapmış kullanıcının Id değeri

            var list = _advertService.TGetList().Where(x => x.UserAdminID == UserID && x.Status == true).Select(x => new AdvertListDto
            {
                AdvertID = x.AdvertID,
                AirCordinator = x.AirCordinator,
                Area = x.Area,
                Title = x.Title,
                AdvertDate = x.AdvertDate,
                BathOfRoomNumber = x.BathOfRoomNumber,
                FirePlace = x.FirePlace,
                Floor = x.Floor,
                NumberOfRoom = x.NumberOfRoom,
                Pool = x.Pool,
                Price = x.Price,
                Garden = x.Garden,
                Status = x.Status
            }).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult CreateAdvert()
        {
            ViewBag.UserID = HttpContext.Session.GetString("ID");
            DropDown();
            return View();
        }

        [HttpPost]
        public IActionResult CreateAdvert(Advert model)
        {
            AdvertValidator _validationRules = new AdvertValidator();
            ValidationResult result = _validationRules.Validate(model);
            if (result.IsValid)
            {
                if (model.ImageUrl != null)
                {
                    var dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Adverts/");
                    foreach (var item in model.ImageUrl)
                    {
                        var yuklemeyolu = Path.Combine(dosyaYolu, item.FileName);
                        using (var dosya = new FileStream(yuklemeyolu, FileMode.Create))
                        {
                            item.CopyTo(dosya);
                        }

                        model.Images.Add(new Images { ImageName = item.FileName, Status = true });
                    }
                }
                model.AdvertDate = DateTime.Now;
                model.Status = true;
                model.UserAdminID = HttpContext.Session.GetString("ID");
                _advertService.TAdd(model);
                _toastNotification.AddSuccessToastMessage(NotifyMessage.Advert.Add(model.Title), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Advert", new { Area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            DropDown();
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateAdvert(int AdvertID)
        {
            ViewBag.UserID = HttpContext.Session.GetString("ID");
            var updateadvert = _advertService.TGetByID(AdvertID);
            DropDown();
            return View(updateadvert);
        }

        [HttpPost]
        public IActionResult UpdateAdvert(Advert advert)
        {
            AdvertValidator _validationRules = new AdvertValidator();
            ValidationResult result = _validationRules.Validate(advert);
            if (result.IsValid)
            {
                advert.Status = true;
                _advertService.TUpdate(advert);
                _toastNotification.AddSuccessToastMessage(NotifyMessage.Advert.Update(advert.Title), new ToastrOptions { Title = "Güncelleme Başarılı" });
                return RedirectToAction("Index", "Advert", new { Area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            DropDown();
            return View(advert);
        }

        [HttpGet]
        public IActionResult ImageList(int advertId)
        {
            var list = _imageService.TGetListFilter(x => x.AdvertID == advertId).ToList();
            ViewBag.AdvertName = list.Where(x => x.AdvertID == advertId).Select(x => x.Advert.Title).FirstOrDefault();
            ViewBag.AdvertId = advertId;
            return View(list);
        }

        public IActionResult ImageDelete(int imageId)
        {
            var delete = _imageService.TGetByID(imageId);
            _imageService.TDelete(delete);
            _toastNotification.AddSuccessToastMessage(NotifyMessage.Images.Delete(delete.ImageName), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "Advert", new { Area = "Admin" });
        }


        [HttpPost]
        public IActionResult ImageUpdate(Images model, int imgId)
        {
            var image = _imageService.TGetByID(imgId);
            model.ImagesID = imgId;
            ImageValidator _validations = new ImageValidator();
            ValidationResult result = _validations.Validate(model);
            if (result.IsValid)
            {
                model.AdvertID = image.AdvertID;
                model.ImageName = image.ImageName;
                image.ImageUrl = model.ImageUrl;
                if (model.ImageUrl != null)
                {
                    var dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Adverts/");
                    var yuklemeyolu = Path.Combine(dosyaYolu, model.ImageUrl.FileName);
                    using (var dosyakisi = new FileStream(yuklemeyolu, FileMode.Create))
                    {
                        model.ImageUrl.CopyTo(dosyakisi);
                    }

                    _imageService.TUpdate(model);
                    _toastNotification.AddSuccessToastMessage(NotifyMessage.Images.Update(model.ImageName), new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "Advert", new { Area = "Admin" });
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateImageAdvert(Advert model)
        {
            var advert = _advertService.TGetByID(model.AdvertID);
            if (model.ImageUrl != null)
            {
                var dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Adverts/");
                foreach (var item in model.ImageUrl)
                {
                    var yuklemeyolu = Path.Combine(dosyaYolu, item.FileName);
                    using (var dosya = new FileStream(yuklemeyolu, FileMode.Create))
                    {
                        item.CopyTo(dosya);
                    }

                    _imageService.TAdd(new Images { ImageName = item.FileName, Status = true, AdvertID = advert.AdvertID });
                }
                _toastNotification.AddSuccessToastMessage(NotifyMessage.Advert.Add(model.Title), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("ImageList", "Advert", new { Area = "Admin" });
            }
            return View(advert);
        }

        public IActionResult InActiveAdvert()
        {
            string UserID = HttpContext.Session.GetString("ID");
            //Giriş yapmış kullanıcının Id değeri

            var list = _advertService.TGetList().Where(x => x.UserAdminID == UserID && x.Status == false).Select(x => new AdvertListDto
            {
                AdvertID = x.AdvertID,
                AirCordinator = x.AirCordinator,
                Area = x.Area,
                Title = x.Title,
                AdvertDate = x.AdvertDate,
                BathOfRoomNumber = x.BathOfRoomNumber,
                FirePlace = x.FirePlace,
                Floor = x.Floor,
                NumberOfRoom = x.NumberOfRoom,
                Pool = x.Pool,
                Price = x.Price,
                Garden = x.Garden,
                Status = x.Status
            }).ToList();
            return View(list);
        }

        public IActionResult ChangeStatus(int advertId)
        {
            var userId = HttpContext.Session.GetString("ID");
            var changeAdvert = _advertService.TGetByID(advertId);
            if (userId == changeAdvert.UserAdminID)
            {
                if (changeAdvert.Status == true)
                {
                    changeAdvert.Status = false;
                }
                else
                {
                    changeAdvert.Status = true;
                }
                _advertService.TUpdate(changeAdvert);
                _toastNotification.AddWarningToastMessage(NotifyMessage.Advert.UndoDelete(changeAdvert.Title), new ToastrOptions { Title = "Geri Yükleme Başarılı" });
            }
            return RedirectToAction("InActiveAdvert", "Advert", new { Area = "Admin" });
        }

        public IActionResult DeleteAdvert(int advertId)
        {
            var userId = HttpContext.Session.GetString("ID");
            var delete = _advertService.TGetByID(advertId);
            if (userId == delete.UserAdminID)
            {
                _advertService.TDelete(delete);
                _toastNotification.AddErrorToastMessage(NotifyMessage.Advert.Delete(delete.Title), new ToastrOptions { Title = "Başarılı" });
            }
            return RedirectToAction("Index", "Advert", new { Area = "Admin" });
        }

        public IActionResult DeleteCompleteAdvert(int advertId)
        {
            var userId = HttpContext.Session.GetString("ID");
            var delete = _advertService.TGetByID(advertId);
            if (userId == delete.UserAdminID)
            {
                _advertService.CompleteDelete(delete);
                _toastNotification.AddErrorToastMessage(NotifyMessage.Advert.Delete(delete.Title), new ToastrOptions { Title = "Silme Başarılı" });
            }
            return RedirectToAction("Index", "Advert", new { Area = "Admin" });
        }
        public List<City> GetCity()
        {
            List<City> cities = _cityService.TGetList();
            return cities;
        }
        public List<Situation> GetSituation()
        {
            List<Situation> situations = _situationService.TGetList().Where(x => x.Status == true).ToList();
            return situations;
        }
        public PartialViewResult AdvertTypePartial()
        {
            return PartialView();
        }
        public PartialViewResult DistrictPartial()
        {
            return PartialView();
        }
        public PartialViewResult NeighbourhoodPartial()
        {
            return PartialView();
        }
        public IActionResult GetAdvertType(int situationId)
        {
            List<AdvertType> advertTypes = _advertTypeService.TGetListFilter(x => x.SituationID == situationId);
            ViewBag.AdvertTypeList = new SelectList(advertTypes, "AdvertTypeID", "AdvertTypeName");
            return PartialView("AdvertTypePartial");
        }
        public IActionResult GetDistrict(int cityId)
        {
            List<District> districts = _districtService.TGetListFilter(x => x.CityID == cityId);
            ViewBag.DistrictList = new SelectList(districts, "DistrictID", "DistrictName");
            return PartialView("DistrictPartial");
        }
        public IActionResult GetNeighbourHood(int districtId)
        {
            List<Neighbourhood> neighbourhoodlist = _neightbourhoodService.TGetListFilter(x => x.DistrictID == districtId);
            ViewBag.NeighbourhoodList = new SelectList(neighbourhoodlist, "NeighbourhoodID", "NeighbourhoodName");
            return PartialView("NeighbourhoodPartial");
        }
        public void DropDown()
        {
            ViewBag.CityList = new SelectList(GetCity(), "CityID", "CityName");
            ViewBag.SituationList = new SelectList(GetSituation(), "SituationID", "Name");

            List<SelectListItem> value = (from x in _districtService.TGetList()
                                          select new SelectListItem
                                          {
                                              Value = x.DistrictID.ToString(),
                                              Text = x.DistrictName
                                          }).ToList();
            ViewBag.district = value;

            List<SelectListItem> value1 = (from x in _neightbourhoodService.TGetList()
                                           select new SelectListItem
                                           {
                                               Value = x.NeighbourhoodID.ToString(),
                                               Text = x.NeighbourhoodName
                                           }).ToList();
            ViewBag.neighbourhood = value1;

            List<SelectListItem> value2 = (from x in _advertTypeService.TGetList()
                                           select new SelectListItem
                                           {
                                               Value = x.AdvertTypeID.ToString(),
                                               Text = x.AdvertTypeName
                                           }).ToList();
            ViewBag.advertType = value2;

            List<SelectListItem> value3 = (from x in _situationService.TGetList()
                                           select new SelectListItem
                                           {
                                               Value = x.SituationID.ToString(),
                                               Text = x.Name
                                           }).ToList();
            ViewBag.situations = value3;

        }
    }
}
