#pragma checksum "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56b9bb502c3acdc5d3af89125489004ce9b676f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Seller_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Seller/Views/Home/Index.cshtml")]
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
#line 1 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b9bb502c3acdc5d3af89125489004ce9b676f7", @"/Areas/Seller/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Seller/Views/_ViewImports.cshtml")]
    public class Areas_Seller_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "پنل فروشندگی";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header text-center\">\r\n<div class=\"container\">\r\n    <h3 class=\"text-danger\">");
#nullable restore
#line 8 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n</div><!-- End .container -->\r\n");
#nullable restore
#line 10 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
 if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <h5 class=\"page-title\">پنل فروشندگی ، ");
#nullable restore
#line 13 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
                                     Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n</div><!-- End .container -->\r\n");
#nullable restore
#line 15 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<nav aria-label=""breadcrumb"" class=""breadcrumb-nav mb-3"">
    <div class=""container"">
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a href=""/"">صفحه اصلی</a></li>
            <li class=""breadcrumb-item"" aria-current=""page"">");
#nullable restore
#line 22 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
                                                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 23 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
             if (User.Identity.IsAuthenticated)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"breadcrumb-item active\"><a href=\"#\">");
#nullable restore
#line 25 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
                                                      Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 26 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ol>\r\n    </div><!-- End .container -->\r\n</nav>\r\n\r\n<div class=\"page-content\">\r\n    <div class=\"dashboard\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <aside class=\"col-md-4 col-lg-3\">\r\n                    ");
#nullable restore
#line 36 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Home\Index.cshtml"
               Write(await Component.InvokeAsync("SellerSidebarDashboard"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </aside><!-- End .col-lg-3 -->

                <div class=""col-md-8 col-lg-9"">
                    <div class=""tab-content"">
                        <div class=""tab-pane fade show active"" id=""tab-dashboard"" role=""tabpanel"" aria-labelledby=""tab-dashboard-link"">
                            <p>
                                سلام. به پنل فروشندگی خودتان خوش آمدید. شما در اینجا می توانید کلیه عملیات مربوط به محصولات از جمله: اضافه کردن، ویرایش، تعیین تخفیف و ... را بر روی دسته محصولات، محصولات و گالری محصولات انجام دهید.
                            </p>
                        </div><!-- .End .tab-pane -->

                    </div>
                </div><!-- End .col-lg-9 -->
            </div><!-- End .row -->
        </div><!-- End .container -->
    </div><!-- End .dashboard -->
</div>


");
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
