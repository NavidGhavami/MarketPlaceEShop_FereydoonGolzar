#pragma checksum "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "086b8dbd2389d225963344f0390ace1e27a88944"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_GetMenuCategories_GetMenuCategories), @"mvc.1.0.view", @"/Views/Shared/Components/GetMenuCategories/GetMenuCategories.cshtml")]
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
#line 1 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
using MarketPlace.DataLayer.Entities.Products;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"086b8dbd2389d225963344f0390ace1e27a88944", @"/Views/Shared/Components/GetMenuCategories/GetMenuCategories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_GetMenuCategories_GetMenuCategories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FilterProducts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ArticleList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FrequentlyQuestions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AboutUs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ContactUs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
   var categories = ViewBag.ProductCategories as List<ProductCategory>; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""header-bottom sticky-header"">
    <div class=""container"">
        <div class=""header-left"">
            <div class=""dropdown category-dropdown show is-on"" data-visible=""true"">
                <a href=""#"" class=""dropdown-toggle"" role=""button"" data-toggle=""dropdown""
                   aria-haspopup=""true"" aria-expanded=""true"" data-display=""static""
                   title=""دسته بندی فروشگاه"">
                    فهرست دسته بندی ها
                </a>

                <div class=""dropdown-menu"">
                    <nav class=""side-nav"">
                        <ul class=""menu-vertical sf-arrows "">
");
#nullable restore
#line 18 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                             if (categories != null && categories.Any())
                            {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                         foreach (var category in categories.Where(x=>x.ParentId == null))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"megamenu-container\">\n                            <a class=\"sf-with-ul\" href=\"#\">");
#nullable restore
#line 23 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                      Write(category.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>

                            <div class=""megamenu"">
                                <div class=""row no-gutters"">
                                    <div class=""col-md-12"">
                                        <div class=""menu-col"">
                                            <div class=""row"">
");
#nullable restore
#line 30 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                 if (categories.Any(x => x.ParentId == category.Id))
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                     foreach (var subCategory in categories.Where(x=>x.ParentId == category.Id))
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <div class=\"col-md-3\">\n                                                            <div class=\"menu-title\">");
#nullable restore
#line 35 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                                               Write(subCategory.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                                                            <!-- End .menu-title -->\n");
#nullable restore
#line 37 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                             if (categories.Any(x => x.ParentId == subCategory.Id))
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <ul>\n");
#nullable restore
#line 40 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                             foreach (var secondSubCategory in categories.Where(x => x.ParentId == subCategory.Id).Take(6))
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "086b8dbd2389d225963344f0390ace1e27a8894412476", async() => {
#nullable restore
#line 43 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                                                                          Write(secondSubCategory.Title);

#line default
#line hidden
#nullable disable
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
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Category", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                                       WriteLiteral(secondSubCategory.UrlName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Category"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Category", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Category"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>");
#nullable restore
#line 43 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                                                                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        </ul>\n");
#nullable restore
#line 45 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        </div><!-- End .col-md-6 -->\n");
#nullable restore
#line 47 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                                                     
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            </div><!-- End .row -->
                                        </div><!-- End .menu-col -->
                                    </div><!-- End .col-md-8 -->
                                </div><!-- End .row -->
                            </div><!-- End .megamenu -->
                        </li>
");
#nullable restore
#line 55 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"

                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "E:\Programming\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\Components\GetMenuCategories\GetMenuCategories.cshtml"
                         

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </ul><!-- End .menu-vertical -->
                    </nav><!-- End .side-nav -->
                </div><!-- End .dropdown-menu -->
            </div><!-- End .category-dropdown -->
        </div><!-- End .col-lg-3 -->
        <div class=""header-center"">
            <nav class=""main-nav"">
                <ul class=""menu sf-arrows"">
                    <li class=""megamenu-container active"">
                        <a href=""/""");
            BeginWriteAttribute("class", " class=\"", 3898, "\"", 3906, 0);
            EndWriteAttribute();
            WriteLiteral(">صفحه اصلی</a>\n                    </li>\n\n                    <li class=\"megamenu-container\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "086b8dbd2389d225963344f0390ace1e27a8894419124", async() => {
                WriteLiteral("محصولات");
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </li>\n                    <li>\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "086b8dbd2389d225963344f0390ace1e27a8894420845", async() => {
                WriteLiteral("بلاگ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </li>\n                    <li class=\"megamenu-container\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "086b8dbd2389d225963344f0390ace1e27a8894422592", async() => {
                WriteLiteral("سوالات متداول");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </li>\n                    <li class=\"megamenu-container\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "086b8dbd2389d225963344f0390ace1e27a8894424148", async() => {
                WriteLiteral("درباره ما");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </li>\n                    <li class=\"megamenu-container\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "086b8dbd2389d225963344f0390ace1e27a8894425700", async() => {
                WriteLiteral("تماس با ما");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </li>


                </ul><!-- End .menu -->
            </nav><!-- End .main-nav -->
        </div><!-- End .col-lg-9 -->
        <div class=""header-right"">
            <i class=""la la-lightbulb-o""></i>
            <span>
                <a href=""index-1.html"" class=""text-warning"">جشنواره و تخفیفات</a>
            </span>

        </div>
    </div><!-- End .container -->
</div>");
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
