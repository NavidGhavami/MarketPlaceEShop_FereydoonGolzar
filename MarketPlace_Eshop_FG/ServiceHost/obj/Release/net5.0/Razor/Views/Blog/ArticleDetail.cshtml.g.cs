#pragma checksum "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fa34bf830cdc70e4d721a430a178261542e2a93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_ArticleDetail), @"mvc.1.0.view", @"/Views/Blog/ArticleDetail.cshtml")]
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
#line 1 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
using MarketPlace.Application.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fa34bf830cdc70e4d721a430a178261542e2a93", @"/Views/Blog/ArticleDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Blog_ArticleDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MarketPlace.DataLayer.DTOs.Blog.Article.ArticleDTO>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
  
    ViewData["Title"] = "جزییات مقاله";
    ViewData["metaDescription"] = Model.MetaDescription;
    ViewData["keywords"] = Model.Keywords;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<nav aria-label=\"breadcrumb\" class=\"breadcrumb-nav border-0 mb-0\">\r\n    <div class=\"container\">\r\n        <ol class=\"breadcrumb\">\r\n            <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fa34bf830cdc70e4d721a430a178261542e2a935150", async() => {
                WriteLiteral("صفحه اصلی");
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
            WriteLiteral("</li>\r\n            <li class=\"breadcrumb-item\"><a href=\"#\">مقالات</a></li>\r\n            <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 14 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                                                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        </ol>\r\n    </div><!-- End .container -->\r\n</nav>\r\n\r\n<div class=\"page-content\">\r\n    <figure class=\"entry-media\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 788, "\"", 838, 1);
#nullable restore
#line 21 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
WriteAttributeValue("", 794, PathExtension.ArticleOrigin + Model.Image, 794, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 839, "\"", 857, 1);
#nullable restore
#line 21 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
WriteAttributeValue("", 845, Model.Title, 845, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 858, "\"", 878, 1);
#nullable restore
#line 21 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
WriteAttributeValue("", 866, Model.Title, 866, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
    </figure><!-- End .entry-media -->
    <div class=""container"">
        <article class=""entry single-entry entry-fullwidth"">
            <div class=""row"">
                <div class=""col-lg-11"">
                    <div class=""entry-body"">
                        <div class=""entry-meta"">
                            <span class=""entry-author"">
                                نویسنده : <a href=""#"">مدیر سایت</a>
                            </span>
                            <span class=""meta-separator"">|</span>
                            <a href=""#"">");
#nullable restore
#line 33 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                                   Write(Model.PublishDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            <span class=\"meta-separator\">|</span>\r\n                            <a href=\"#\">");
#nullable restore
#line 35 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                                   Write(Model.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div><!-- End .entry-meta -->\r\n                        <br />\r\n                        <h1 class=\"entry-title entry-title-big\">\r\n                            ");
#nullable restore
#line 39 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h1><!-- End .entry-title -->\r\n\r\n\r\n                        <div class=\"entry-content editor-content\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 45 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                           Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </p>


                        </div><!-- End .entry-content -->

                        <div class=""entry-footer row no-gutters"">
                            <div class=""col-12"">
                                <div class=""entry-tags"">
                                    <span>کلمات کلیدی : </span>
");
#nullable restore
#line 55 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                                     if (Model.KeywordList != null && Model.KeywordList.Any())
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                                         foreach (var tag in Model.KeywordList)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <a href=\"#\">");
#nullable restore
#line 59 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                                                   Write(tag);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 60 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Blog\ArticleDetail.cshtml"
                                         
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div><!-- End .entry-tags -->
                            </div><!-- End .col -->
                        </div><!-- End .entry-footer row no-gutters -->
                    </div><!-- End .entry-body -->
                </div><!-- End .col-lg-11 -->

                <div class=""col-lg-1 order-lg-first mb-2 mb-lg-0"">
                    <div class=""sticky-content""");
            BeginWriteAttribute("style", " style=\"", 3178, "\"", 3186, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        <div class=""social-icons social-icons-colored social-icons-vertical"">
                            <span class=""social-label"">اشتراک گذاری</span>
                            <a href=""#"" class=""social-icon social-facebook"" title=""فیسبوک"" target=""_blank""><i class=""icon-facebook-f""></i></a>
                            <a href=""#"" class=""social-icon social-twitter"" title=""توییتر"" target=""_blank""><i class=""icon-twitter""></i></a>
                            <a href=""#"" class=""social-icon social-pinterest"" title=""پینترست"" target=""_blank""><i class=""icon-pinterest""></i></a>
                            <a href=""#"" class=""social-icon social-linkedin"" title=""لینکدین"" target=""_blank""><i class=""icon-linkedin""></i></a>
                        </div><!-- End .soial-icons -->
                    </div><!-- End .sticky-content -->
                </div><!-- End .col-lg-1 -->
            </div><!-- End .row -->
        </article><!-- End .entry -->
    </div><!-- End .container -->
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MarketPlace.DataLayer.DTOs.Blog.Article.ArticleDTO> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
