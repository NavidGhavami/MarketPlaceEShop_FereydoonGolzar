#pragma checksum "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc9e33143492442559dbfff61f1e2f6508062122"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Order_UserOrderAddress), @"mvc.1.0.view", @"/Areas/User/Views/Order/UserOrderAddress.cshtml")]
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
#line 1 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
using MarketPlace.Application.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc9e33143492442559dbfff61f1e2f6508062122", @"/Areas/User/Views/Order/UserOrderAddress.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/User/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_User_Views_Order_UserOrderAddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MarketPlace.DataLayer.DTOs.ProductOrder.UserAddressDTO>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetUserOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_NoItemFound", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
  
    ViewData["Title"] = "آدرس پستی";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header text-center\">\r\n    <div class=\"container\">\r\n        <h3 class=\"text-danger\">");
#nullable restore
#line 9 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div><!-- End .container -->\r\n");
#nullable restore
#line 11 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"container\">\r\n            <h5 class=\"page-title\">پنل کاربری ، ");
#nullable restore
#line 14 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                           Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        </div><!-- End .container -->\r\n");
#nullable restore
#line 16 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc9e33143492442559dbfff61f1e2f65080621227943", async() => {
                WriteLiteral("داشبورد");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li class=\"breadcrumb-item\" aria-current=\"page\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc9e33143492442559dbfff61f1e2f65080621229574", async() => {
                WriteLiteral("سفارشات من");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li class=\"breadcrumb-item active\"><a href=\"#\">");
#nullable restore
#line 25 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n\r\n        </ol>\r\n    </div><!-- End .container -->\r\n</nav>\r\n\r\n<div class=\"page-content\">\r\n    <div class=\"dashboard\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n");
            WriteLiteral("\r\n                <div class=\"col-md-12 col-lg-12\">\r\n                    <div class=\"tab-content\">\r\n                        <div class=\"tab-pane fade active show\" id=\"tab-account\" role=\"tabpanel\" aria-labelledby=\"tab-account-link\">\r\n");
#nullable restore
#line 42 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                             if (Model.Order != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h3 class=\"title mb-3\">آدرس پستی</h3>\r\n");
            WriteLiteral(@"                                <div class=""col-md-12"">


                                    <table class=""table table-striped table-responsive-md text-center"">
                                        <thead class=""thead-dark"">
                                            <tr>
                                                <th scope=""col"">شناسه سفارش</th>
                                                <th scope=""col"">نام و نام خانوادگی</th>
                                                <th scope=""col"">شرکت</th>
                                                <th scope=""col"">استان</th>
                                                <th scope=""col"">شهر / شهرستان</th>
                                                <th scope=""col"">خیابان</th>
                                                <th scope=""col"">کد پستی</th>
                                                <th scope=""col"">شماره پلاک</th>
                                                <th scope=""col"">ایمیل</th>
                      ");
            WriteLiteral(@"                          <th scope=""col"">موبایل</th>
                                                <th scope=""col"">روش پرداخت</th>
                                                <th scope=""col"">توضیحات</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>");
#nullable restore
#line 68 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 69 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                                Write(Model.Name + " " + Model.Family);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 70 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                                Write(Model.Company ?? "---");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 71 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 72 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 73 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 74 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 75 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.PlaqueNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 76 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 77 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 78 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                               Write(Model.PaymentMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 79 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                                                Write(Model.Description ?? "---");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                        </tbody>\r\n                                    </table>\r\n\r\n\r\n                                </div>\r\n");
#nullable restore
#line 86 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dc9e33143492442559dbfff61f1e2f650806212219694", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 90 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\User\Views\Order\UserOrderAddress.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div><!-- .End .tab-pane -->
                    </div>
                </div><!-- End .col-lg-9 -->
            </div><!-- End .row -->
        </div><!-- End .container -->
    </div><!-- End .dashboard -->
</div>







");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MarketPlace.DataLayer.DTOs.ProductOrder.UserAddressDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
