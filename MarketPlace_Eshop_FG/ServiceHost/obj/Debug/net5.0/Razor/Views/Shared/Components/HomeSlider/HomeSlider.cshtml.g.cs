#pragma checksum "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fe6dcc300417cf6aafab67fdc3fab40f9519aae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HomeSlider_HomeSlider), @"mvc.1.0.view", @"/Views/Shared/Components/HomeSlider/HomeSlider.cshtml")]
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
#line 1 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
using MarketPlace.Application.EntitiesExtensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fe6dcc300417cf6aafab67fdc3fab40f9519aae", @"/Views/Shared/Components/HomeSlider/HomeSlider.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_HomeSlider_HomeSlider : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MarketPlace.DataLayer.Entities.Site.Slider>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 6 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
 if (Model != null && Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"carouselExampleIndicators\" class=\"carousel slide\" data-ride=\"carousel\">\r\n    <!-- Indicators -->\r\n");
            WriteLiteral("    <!-- Wrapper for slides -->\r\n    <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 17 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"carousel-item\">\r\n                <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 761, "\"", 796, 1);
#nullable restore
#line 20 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
WriteAttributeValue("", 767, item.GetSliderImageAddress(), 767, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("alt=\"First Image\">\r\n                <div class=\"carousel-caption SliderContent d-md-block\">\r\n                    \r\n                        <h3 class=\"intro-subtitle\">");
#nullable restore
#line 23 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
                                              Write(item.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <h1 class=\"intro-title\">\r\n                            ");
#nullable restore
#line 25 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
                       Write(item.MainText);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>");
#nullable restore
#line 25 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
                                          Write(item.SecondText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h1>\r\n\r\n                        <h3 class=\"text-danger\">");
#nullable restore
#line 28 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
                                           Write(item.Footer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                        <!-- End .intro-title -->\r\n                        <br />\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1308, "\"", 1325, 1);
#nullable restore
#line 32 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
WriteAttributeValue("", 1315, item.Link, 1315, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" target=""_blank"" class=""btn btn-primary btn-round"">
                            <span>اکنون بخرید</span>
                            <i class=""icon-long-arrow-left""></i>
                        </a>
                    
                </div>
            </div>
");
#nullable restore
#line 39 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <!-- Controls -->
    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>
");
#nullable restore
#line 52 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\HomeSlider\HomeSlider.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MarketPlace.DataLayer.Entities.Site.Slider>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
