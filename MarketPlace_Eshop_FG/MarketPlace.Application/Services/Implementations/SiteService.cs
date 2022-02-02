using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Application.Extensions;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
using MarketPlace.DataLayer.DTOs.Paging;
using MarketPlace.DataLayer.DTOs.Seller;
using MarketPlace.DataLayer.DTOs.Site;
using MarketPlace.DataLayer.Entities.Site;
using MarketPlace.DataLayer.Entities.Store;
using MarketPlace.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Application.Services.Implementations
{
    public class SiteService : ISiteService
    {

        #region Constructor

        private readonly IGenericRepository<SiteSetting> _siteSettingRepository;
        private readonly IGenericRepository<Slider> _sliderRepository;
        private readonly IGenericRepository<SiteBanner> _siteBanner;
        private readonly IGenericRepository<FrequentlyQuestion> _frequentlyQuestionRepository;

        public SiteService(IGenericRepository<SiteSetting> siteSettingRepository, IGenericRepository<Slider> sliderRepository,
            IGenericRepository<SiteBanner> siteBanner, IGenericRepository<FrequentlyQuestion> frequentlyQuestionRepository)
        {
            _siteSettingRepository = siteSettingRepository;
            _sliderRepository = sliderRepository;
            _siteBanner = siteBanner;
            _frequentlyQuestionRepository = frequentlyQuestionRepository;
        }

        #endregion


        #region Site Setting

        public async Task<SiteSetting> GetDefaultSiteSetting()
        {
            return await _siteSettingRepository.GetQuery().AsQueryable()
                .SingleOrDefaultAsync(x => x.IsDefault && !x.IsDelete);
        }

        public async Task<EditSiteSettingDTO> GetSiteSettingForEdit(long id)
        {
            var setting = await _siteSettingRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == id);
            if (setting == null)
            {
                return null;
            }

            return new EditSiteSettingDTO
            {
                Id = setting.Id,
                Address = setting.Address,
                CopyRight = setting.CopyRight,
                Email = setting.Email,
                FooterText = setting.FooterText,
                IsDefault = setting.IsDefault,
                MapScript = setting.MapScript,
                Mobile = setting.Mobile,
                Phone = setting.Phone
            };
        }

        public async Task<bool> EditSiteSetting(EditSiteSettingDTO edit)
        {
            var mainSetting = await _siteSettingRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (mainSetting == null)
            {
                return false;
            }

            mainSetting.Id = edit.Id;
            mainSetting.Address = edit.Address;
            mainSetting.CopyRight = edit.CopyRight;
            mainSetting.Email = edit.Email;
            mainSetting.FooterText = edit.FooterText;
            mainSetting.MapScript = edit.MapScript;
            mainSetting.Mobile = edit.Mobile;
            mainSetting.Phone = edit.Phone;

            _siteSettingRepository.EditEntity(mainSetting);
            await _siteSettingRepository.SaveChanges();

            return true;



        }

        #endregion

        #region Slider

        public async Task<List<Slider>> GetAllActiveSlider()
        {
            return await _sliderRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => x.IsActive && !x.IsDelete)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<Slider>> GetAllSlider()
        {
            return await _sliderRepository.GetQuery().AsQueryable()
                .ToListAsync();
        }

        public async Task<CreateSliderResult> CreateSlider(CreateSliderDTO slider, IFormFile sliderImage)
        {
            if (sliderImage != null && sliderImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(sliderImage.FileName);
                sliderImage.AddImageToServer(imageName, PathExtension.SliderOriginServer,
                    100, 100, PathExtension.SliderThumbServer);

                var newSlider = new Slider
                {
                    Header = slider.Header,
                    MainText = slider.MainText,
                    SecondText = slider.SecondText,
                    Footer = slider.Footer,
                    Link = slider.Link,
                    ImageName = imageName,
                    IsActive = true
                };

                await _sliderRepository.AddEntity(newSlider);
                await _sliderRepository.SaveChanges();

                return CreateSliderResult.Success;
            }

            return CreateSliderResult.Error;

        }

        public async Task<EditSliderDTO> GetSliderForEdit(long sliderId)
        {
            var slider = await _sliderRepository.GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == sliderId);

            if (slider == null)
            {
                return null;
            }

            return new EditSliderDTO
            {
                Id = slider.Id,
                Header = slider.Header,
                MainText = slider.MainText,
                SecondText = slider.SecondText,
                Footer = slider.Footer,
                ImageName = slider.ImageName,
                Link = slider.Link,
                IsActive = slider.IsActive
            };
        }

        public async Task<EditSliderResult> EditSlider(EditSliderDTO edit, IFormFile sliderImage)
        {
            var mainSlider = await _sliderRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (sliderImage != null && sliderImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(sliderImage.FileName);
                sliderImage.AddImageToServer(imageName, PathExtension.SliderOriginServer,
                    100, 100, PathExtension.SliderThumbServer, mainSlider.ImageName);

                mainSlider.ImageName = imageName;
            }

            if (mainSlider == null)
            {
                return EditSliderResult.NotFound;
            }

            mainSlider.Id = edit.Id;
            mainSlider.Header = edit.Header;
            mainSlider.MainText = edit.MainText;
            mainSlider.SecondText = edit.SecondText;
            mainSlider.Footer = edit.Footer;
            mainSlider.Link = edit.Link;

            _sliderRepository.EditEntity(mainSlider);
            await _sliderRepository.SaveChanges();

            return EditSliderResult.Success;

        }

        public async Task<bool> ActiveSlider(long sliderId)
        {
            var slider = await _sliderRepository.GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == sliderId);

            if (slider == null)
            {
                return false;
            }

            slider.IsActive = true;

            _sliderRepository.EditEntity(slider);
            await _sliderRepository.SaveChanges();

            return true;
        }

        public async Task<bool> DeactiveSlider(long sliderId)
        {
            var slider = await _sliderRepository.GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == sliderId);

            if (slider == null)
            {
                return false;
            }

            slider.IsActive = false;

            _sliderRepository.EditEntity(slider);
            await _sliderRepository.SaveChanges();

            return true;
        }

        #endregion

        #region Site Banners

        public async Task<List<SiteBanner>> GetSiteBannersByLocations(List<SiteBanner.BannersLocations> locations)
        {
            return await _siteBanner
                .GetQuery()
                .AsQueryable()
                .Where(x => locations.Contains(x.BannersLocation) && !x.IsDelete)
                .ToListAsync();
        }

        public async Task<List<SiteBanner>> GetAllBanners()
        {
            return await _siteBanner
                .GetQuery()
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<CreateBannerResult> CreateBanner(CreateBannerDTO banner, IFormFile bannerImage)
        {
            if (bannerImage != null && bannerImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(bannerImage.FileName);
                bannerImage.AddImageToServer(imageName, PathExtension.BannerOriginServer,
                    100, 100, PathExtension.BannerThumbServer);

                var newBanner = new SiteBanner
                {
                    Header = banner.Header,
                    MainText = banner.MainText,
                    BtnText = banner.BtnText,
                    BannersLocation = banner.BannersLocation,
                    ColSize = banner.ColSize,
                    Url = banner.Url,
                    ImageName = imageName,

                };

                await _siteBanner.AddEntity(newBanner);
                await _siteBanner.SaveChanges();

                return CreateBannerResult.Success;
            }

            return CreateBannerResult.Error;
        }

        public async Task<EditBannerDTO> GetBannerForEdit(long bannerId)
        {
            var banner = await _siteBanner
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == bannerId);

            return new EditBannerDTO
            {
                Id = banner.Id,
                BtnText = banner.BtnText,
                BannersLocation = banner.BannersLocation,
                MainText = banner.MainText,
                Url = banner.Url,
                ImageName = banner.ImageName,
                ColSize = banner.ColSize,
                Header = banner.Header,
            };
        }

        public async Task<EditBannerResult> EditBanner(EditBannerDTO edit, IFormFile bannerImage)
        {
            var mainBanner = await _siteBanner
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (mainBanner == null)
            {
                return EditBannerResult.Error;
            }

            if (bannerImage != null && bannerImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(bannerImage.FileName);
                bannerImage.AddImageToServer(imageName, PathExtension.BannerOriginServer,
                    100, 100, PathExtension.BannerThumbServer, mainBanner.ImageName);

                mainBanner.ImageName = imageName;
            }

            mainBanner.Id = edit.Id;
            mainBanner.BtnText = edit.BtnText;
            mainBanner.BannersLocation = edit.BannersLocation;
            mainBanner.MainText = edit.MainText;
            mainBanner.Url = edit.Url;
            mainBanner.ColSize = edit.ColSize;
            mainBanner.Header = edit.Header;

            _siteBanner.EditEntity(mainBanner);
            await _siteBanner.SaveChanges();

            return EditBannerResult.Success;

        }

        public async Task<bool> ActiveBanner(long bannerId)
        {
            var banner = await _siteBanner.GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == bannerId);

            if (banner == null)
            {
                return false;
            }

            banner.IsDelete = false;

            _siteBanner.EditEntity(banner);
            await _siteBanner.SaveChanges();

            return true;
        }

        public async Task<bool> DeactiveBanner(long bannerId)
        {
            var banner = await _siteBanner.GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == bannerId);

            if (banner == null)
            {
                return false;
            }

            banner.IsDelete = true;

            _siteBanner.EditEntity(banner);
            await _siteBanner.SaveChanges();

            return true;
        }

        public async Task<List<FrequentlyQuestion>> GetAllFrequentlyQuestions()
        {
            return await _frequentlyQuestionRepository
                .GetQuery()
                .AsQueryable()
                .Where(x => !x.IsDelete)
                .OrderBy(x=>x.Id)
                .ToListAsync();
        }

        #endregion

        #region Frequently Questions

        public async Task<FilterFrequentlyQuestionDTO> GetFrequentlyQuestions(FilterFrequentlyQuestionDTO filter)
        {
            var query = _frequentlyQuestionRepository
                .GetQuery()
                .AsQueryable();


            #region Paging


            var faqCount = await query.CountAsync();

            var pager = Pager.Build(filter.PageId, faqCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();


            #endregion

            return filter.SetPaging(pager).SetFaq(allEntities);
        }

        public async Task<CreateFaqResult> CreateFrequentlyQuestion(CreatefrequentlyQuestionDTO faq)
        {
            var newFaq = new FrequentlyQuestion
            {
                QuestionHeader = faq.QuestionHeader,
                QuestionText = faq.QuestionText
            };

            await _frequentlyQuestionRepository.AddEntity(newFaq);
            await _frequentlyQuestionRepository.SaveChanges();

            return CreateFaqResult.Success;
        }

        public async Task<EditFrequentlyQuestionDTO> GetFrequentlyQuestionForEdit(long faqId)
        {
            var faq = await _frequentlyQuestionRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == faqId);


            if (faq == null)
            {
                return null;
            }

            return new EditFrequentlyQuestionDTO
            {
                Id = faq.Id,
                QuestionHeader = faq.QuestionHeader,
                QuestionText = faq.QuestionText
            };
        }

        public async Task<EditFrequentlyQuestionResult> EditFrequentlyQuestion(EditFrequentlyQuestionDTO edit)
        {
            var mainFaq = await _frequentlyQuestionRepository
                .GetQuery()
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == edit.Id);

            if (mainFaq == null)
            {
                return EditFrequentlyQuestionResult.NotFound;
            }

            mainFaq.Id = edit.Id;
            mainFaq.QuestionHeader = edit.QuestionHeader;
            mainFaq.QuestionText = edit.QuestionText;

            _frequentlyQuestionRepository.EditEntity(mainFaq);
            await _frequentlyQuestionRepository.SaveChanges();

            return EditFrequentlyQuestionResult.Success;

        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if (_siteSettingRepository != null)
            {
                await _siteSettingRepository.DisposeAsync();
            }
            if (_sliderRepository != null)
            {
                await _sliderRepository.DisposeAsync();
            }
            if (_siteBanner != null)
            {
                await _siteBanner.DisposeAsync();
            }
            if (_frequentlyQuestionRepository != null)
            {
                await _frequentlyQuestionRepository.DisposeAsync();
            }
        }


        #endregion

    }
}
