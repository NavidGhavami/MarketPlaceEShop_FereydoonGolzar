#pragma checksum "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "237564cee00d217e0fbeac7e6ef8b0146d45c9da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SiteBannerHome3_SiteBannerHome3), @"mvc.1.0.view", @"/Views/Shared/Components/SiteBannerHome3/SiteBannerHome3.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
using MarketPlace.DataLayer.Entities.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
using MarketPlace.Application.EntitiesExtensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"237564cee00d217e0fbeac7e6ef8b0146d45c9da", @"/Views/Shared/Components/SiteBannerHome3/SiteBannerHome3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SiteBannerHome3_SiteBannerHome3 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
  
    var banners = ViewBag.banners as List<SiteBanner>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
 if (banners != null && banners.Any(x => x.BannersLocation == SiteBanner.BannersLocations.Home3))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 12 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
            foreach (var item in banners.Where(x => x.BannersLocation == SiteBanner.BannersLocations.Home3))
           {

#line default
#line hidden
#nullable disable
            WriteLiteral("               <div");
            BeginWriteAttribute("class", " class=\"", 463, "\"", 484, 1);
#nullable restore
#line 14 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
WriteAttributeValue("", 471, item.ColSize, 471, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                   <div class=\"banner banner-overlay\">\r\n                       <a");
            BeginWriteAttribute("href", " href=\"", 569, "\"", 585, 1);
#nullable restore
#line 16 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
WriteAttributeValue("", 576, item.Url, 576, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                           <img");
            BeginWriteAttribute("src", " src=\"", 620, "\"", 659, 1);
#nullable restore
#line 17 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
WriteAttributeValue("", 626, item.GetBannerMainImageAddress(), 626, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 660, "\"", 680, 1);
#nullable restore
#line 17 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
WriteAttributeValue("", 666, item.MainText, 666, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 681, "\"", 703, 1);
#nullable restore
#line 17 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
WriteAttributeValue("", 689, item.MainText, 689, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                       </a>\r\n\r\n                       <div class=\"banner-content\">\r\n                           <h4 class=\"banner-subtitle text-warning\"><a");
            BeginWriteAttribute("href", " href=\"", 861, "\"", 877, 1);
#nullable restore
#line 21 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
WriteAttributeValue("", 868, item.Url, 868, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 21 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
                                                                                   Write(item.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h4>\r\n                           <!-- End .banner-subtitle -->\r\n                           <h3 class=\"banner-title text-black\">\r\n                               <a");
            BeginWriteAttribute("href", " href=\"", 1058, "\"", 1074, 1);
#nullable restore
#line 24 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
WriteAttributeValue("", 1065, item.Url, 1065, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                   <span>\r\n                                       ");
#nullable restore
#line 26 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
                                  Write(item.MainText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                   </span>\r\n                               </a>\r\n                           </h3><!-- End .banner-title -->\r\n                           <a");
            BeginWriteAttribute("href", " href=\"", 1346, "\"", 1362, 1);
#nullable restore
#line 30 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
WriteAttributeValue("", 1353, item.Url, 1353, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"banner-link\">");
#nullable restore
#line 30 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
                                                              Write(item.BtnText);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"icon-long-arrow-left\"></i></a>\r\n                       </div><!-- End .banner-content -->\r\n                   </div><!-- End .banner -->\r\n               </div><!-- End .col-lg-3 -->\r\n");
#nullable restore
#line 34 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
           }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div><!-- End .row -->\r\n    </div><!-- End .container -->\r\n");
#nullable restore
#line 37 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\SiteBannerHome3\SiteBannerHome3.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591