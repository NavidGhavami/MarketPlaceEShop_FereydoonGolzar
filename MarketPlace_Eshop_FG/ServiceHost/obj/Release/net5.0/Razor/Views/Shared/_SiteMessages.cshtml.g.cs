#pragma checksum "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fb33d16f85447b490366eb991028eb41102cb17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SiteMessages), @"mvc.1.0.view", @"/Views/Shared/_SiteMessages.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fb33d16f85447b490366eb991028eb41102cb17", @"/Views/Shared/_SiteMessages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__SiteMessages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
 if (
 TempData["SuccessMessage"] != null ||
 TempData["ErrorMessage"] != null ||
 TempData["InfoMessage"] != null ||
 TempData["WarningMessage"] != null)
{
    if (TempData["SuccessMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                ShowMessage(\'پیغام موفقیت\', \'");
#nullable restore
#line 12 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
                                        Write(TempData["SuccessMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'success\');\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 15 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
    }

    if (TempData["ErrorMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                ShowMessage(\'پیغام خطا\', \'");
#nullable restore
#line 21 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
                                     Write(TempData["ErrorMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'error\');\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 24 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
    }

    if (TempData["InfoMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                ShowMessage(\'پیغام اطلاعیه\', \'");
#nullable restore
#line 30 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
                                         Write(TempData["InfoMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'info\');\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 33 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
    }

    if (TempData["WarningMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            $(document).ready(function () {\r\n                ShowMessage(\'پیغام اخطار\', \'");
#nullable restore
#line 39 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
                                       Write(TempData["WarningMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'warning\');\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 42 "E:\Codes and projects\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_Fereydoon Golzar\MarketPlace_Eshop_FG\ServiceHost\Views\Shared\_SiteMessages.cshtml"
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
