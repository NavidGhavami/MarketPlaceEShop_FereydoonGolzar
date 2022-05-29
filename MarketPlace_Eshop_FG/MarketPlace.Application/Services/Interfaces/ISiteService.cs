using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlace.DataLayer.DTOs.Site;
using MarketPlace.DataLayer.Entities.Site;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.Interfaces
{
    public interface ISiteService : IAsyncDisposable
    {
        #region Site Setting

        Task<SiteSetting> GetDefaultSiteSetting();
        Task<EditSiteSettingDTO> GetSiteSettingForEdit(long id);
        Task<bool> EditSiteSetting(EditSiteSettingDTO edit);

        #endregion

        #region Slider

        Task<List<Slider>> GetAllActiveSlider();
        Task<List<Slider>> GetAllSlider();
        Task<CreateSliderResult> CreateSlider(CreateSliderDTO slider, IFormFile sliderImage);
        Task<EditSliderDTO> GetSliderForEdit(long sliderId);
        Task<EditSliderResult> EditSlider(EditSliderDTO edit, IFormFile sliderImage);
        Task<bool> ActiveSlider(long sliderId);
        Task<bool> DeactiveSlider(long sliderId);

        #endregion

        #region Site Banners

        Task<List<SiteBanner>> GetSiteBannersByLocations(List<SiteBanner.BannersLocations> locations);
        Task<List<SiteBanner>> GetAllBanners();
        Task<CreateBannerResult> CreateBanner(CreateBannerDTO banner, IFormFile bannerImage);
        Task<EditBannerDTO> GetBannerForEdit(long bannerId);
        Task<EditBannerResult> EditBanner(EditBannerDTO edit, IFormFile bannerImage);
        Task<bool> ActiveBanner(long bannerId);
        Task<bool> DeactiveBanner(long bannerId);

        #endregion

        #region Frequently Questions

        Task<List<FrequentlyQuestion>> GetAllFrequentlyQuestions();
        Task<FilterFrequentlyQuestionDTO> GetFrequentlyQuestions(FilterFrequentlyQuestionDTO filter);
        Task<CreateFaqResult> CreateFrequentlyQuestion(CreatefrequentlyQuestionDTO faq);
        Task<EditFrequentlyQuestionDTO> GetFrequentlyQuestionForEdit(long faqId);
        Task<EditFrequentlyQuestionResult> EditFrequentlyQuestion(EditFrequentlyQuestionDTO edit);

        #endregion

        #region Seller Guidelines

        Task<List<SellerGuideline>> GetAllSellerGuidelines();
        Task<FilterSellerGuidelineDTO> GetSellerGuidelines(FilterSellerGuidelineDTO filter);
        Task<CreateSellerGuidelineDTO.CreateSellerGuidelineResult> CreateSellerGuideline(CreateSellerGuidelineDTO guideline);
        Task<EditSellerGuidelineDTO> GetSellerGuidelineForEdit(long guidelineId);
        Task<EditSellerGuidelineResult> EditSellerGuideline(EditSellerGuidelineDTO edit);


        #endregion

        #region Site Guidelines

        Task<List<SiteGuideline>> GetAllSiteGuidelines();
        Task<FilterSiteGuidelineDTO> GetSiteGuidelines(FilterSiteGuidelineDTO filter);
        Task<CreateSiteGuidelineDTO.CreateSiteGuidelineResult> CreateSiteGuideline(CreateSiteGuidelineDTO guideline);
        Task<EditSiteGuidelineDTO> GetSiteGuidelineForEdit(long guidelineId);
        Task<EditSiteGuidelineDTO.EditSiteGuidelineResult> EditSiteGuideline(EditSiteGuidelineDTO edit);


        #endregion
    }
}
