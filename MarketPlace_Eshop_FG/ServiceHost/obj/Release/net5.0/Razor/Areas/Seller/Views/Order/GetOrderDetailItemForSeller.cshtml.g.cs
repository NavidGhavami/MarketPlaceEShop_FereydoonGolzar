#pragma checksum "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23ed1b9e62433365ae168d6cf5c47708db7cb6bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Seller_Views_Order_GetOrderDetailItemForSeller), @"mvc.1.0.view", @"/Areas/Seller/Views/Order/GetOrderDetailItemForSeller.cshtml")]
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
#line 1 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
using MarketPlace.Application.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ed1b9e62433365ae168d6cf5c47708db7cb6bf", @"/Areas/Seller/Views/Order/GetOrderDetailItemForSeller.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Seller/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Seller_Views_Order_GetOrderDetailItemForSeller : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MarketPlace.DataLayer.DTOs.ProductOrder.SellerOrderDetailItemDTO>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Seller", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetOrderForSeller", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-round"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
  
    ViewData["Title"] = "جزییات سفارش فروشنده";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header text-center\">\r\n    <div class=\"container\">\r\n        <h3 class=\"text-danger\">");
#nullable restore
#line 10 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div><!-- End .container -->\r\n");
#nullable restore
#line 12 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"container\">\r\n            <h5 class=\"page-title\">پنل کاربری ، ");
#nullable restore
#line 15 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                           Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        </div><!-- End .container -->\r\n");
#nullable restore
#line 17 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<nav aria-label=\"breadcrumb\" class=\"breadcrumb-nav mb-3\">\r\n    <div class=\"container\">\r\n        <ol class=\"breadcrumb\">\r\n            <li class=\"breadcrumb-item\"><a href=\"/\">صفحه اصلی</a></li>\r\n            <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ed1b9e62433365ae168d6cf5c47708db7cb6bf9587", async() => {
                WriteLiteral("داشبورد پنل کاربری");
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
            WriteLiteral("</li>\r\n            <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ed1b9e62433365ae168d6cf5c47708db7cb6bf11207", async() => {
                WriteLiteral("داشبورد پنل فروشندگی");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ed1b9e62433365ae168d6cf5c47708db7cb6bf12830", async() => {
                WriteLiteral("مدیریت سفارشات");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n            <li class=\"breadcrumb-item active\"><a href=\"#\">");
#nullable restore
#line 27 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a></li>

        </ol>
    </div><!-- End .container -->
</nav>

<div class=""page-content"">
    <div class=""dashboard"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-12 col-lg-12"">
                    <div class=""tab-content"">
                        <div class=""tab-pane fade active show"" id=""tab-account"" role=""tabpanel"" aria-labelledby=""tab-account-link"">
                            <h3 class=""title mb-3"">لیست جزییات سفارش</h3>

                            <div class=""col-md-12"">
");
#nullable restore
#line 43 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                 if (Model != null && Model.Any())
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div id=""accordion"">
                                            <div class=""card"">
                                                <div class=""card-header"" id=""headingOne"">
                                                    <h5 class=""mb-0"">
                                                        <a class=""btn btn-link"" data-toggle=""collapse"" data-target=""#collapseOne_");
#nullable restore
#line 51 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                                                                            Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"false\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 2446, "\"", 2489, 2);
            WriteAttributeValue("", 2462, "collapseOne_", 2462, 12, true);
#nullable restore
#line 51 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
WriteAttributeValue("", 2474, item.ProductId, 2474, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                            <img style=\"width: 150px; height: 150px;\"");
            BeginWriteAttribute("src", "\r\n                                                                 src=\"", 2594, "\"", 2864, 1);
#nullable restore
#line 53 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
WriteAttributeValue("", 2666, !string.IsNullOrEmpty(item.ProductImage) ?
                                                                          PathExtension.ProductOrigin + item.ProductImage : PathExtension.DefaultAvatar, 2666, 198, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n                                                                 alt=\"", 2865, "\"", 2955, 1);
#nullable restore
#line 55 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
WriteAttributeValue("", 2937, item.ProductTitle, 2937, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 2956, "\"", 2982, 1);
#nullable restore
#line 55 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
WriteAttributeValue("", 2964, item.ProductTitle, 2964, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                                            <span class=\"product-title-lineHeight text-justify\" style=\"font-size: 15px;\">\r\n                                                                ");
#nullable restore
#line 57 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                           Write(item.ProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                            </span>
                                                        </a>
                                                    </h5>
                                                </div>

                                                <div");
            BeginWriteAttribute("id", " id=\"", 3511, "\"", 3543, 2);
            WriteAttributeValue("", 3516, "collapseOne_", 3516, 12, true);
#nullable restore
#line 63 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
WriteAttributeValue("", 3528, item.ProductId, 3528, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""collapse"" aria-labelledby=""headingOne"" data-parent=""#accordion"">
                                                    <div class=""card-body"">
                                                        <table class=""table table-striped table-responsive-lg table-hover text-center"">
                                                            <thead class=""thead-dark"">
                                                                <tr>
                                                                    <th scope=""col"">قیمت اصلی</th>
                                                                    <th scope=""col"">قیمت پرداخت شده</th>
                                                                    <th scope=""col"">فروشنده</th>
                                                                    <th scope=""col"">تعداد</th>
                                                                    <th scope=""col"">رنگ</th>
                                                                    <th scope=""col"">");
            WriteLiteral(@"قیمت رنگ</th>
                                                                    <th scope=""col"">مقدار تخفیف</th>
                                                                    <th scope=""col""></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td>");
#nullable restore
#line 80 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                   Write(item.MainProductPrice.ToString("#,0 تومان"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 81 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                   Write(item.ProductPrice.ToString("#,0 تومان"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 82 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                   Write(item.StoreName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 83 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" عدد</td>\r\n                                                                    <td>");
#nullable restore
#line 84 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                   Write(item.ColorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 85 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                   Write(item.ProductColorPrice.ToString("#,0 تومان"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 86 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                    Write(item.DiscountPrice!=0 ? item.DiscountPrice.ToString("#,0 تومان") : "---");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>\r\n                                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ed1b9e62433365ae168d6cf5c47708db7cb6bf26077", async() => {
                WriteLiteral("\r\n                                                                            مشاهده محصول\r\n                                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                                    WriteLiteral(item.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                                                                                                      WriteLiteral(item.ProductTitle);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-title", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["title"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
");
#nullable restore
#line 101 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Areas\Seller\Views\Order\GetOrderDetailItemForSeller.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MarketPlace.DataLayer.DTOs.ProductOrder.SellerOrderDetailItemDTO>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591