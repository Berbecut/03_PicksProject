#pragma checksum "F:\Florin\Campus Varnamo_02\02 Molnbaserat_arkitektur\Florin_Picks\Picks\Picks.Web\Views\Home\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87458b8512227ce231b087ac3d77e06267b605ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Category), @"mvc.1.0.view", @"/Views/Home/Category.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Category.cshtml", typeof(AspNetCore.Views_Home_Category))]
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
#line 1 "F:\Florin\Campus Varnamo_02\02 Molnbaserat_arkitektur\Florin_Picks\Picks\Picks.Web\Views\_ViewImports.cshtml"
using Picks.Web;

#line default
#line hidden
#line 2 "F:\Florin\Campus Varnamo_02\02 Molnbaserat_arkitektur\Florin_Picks\Picks\Picks.Web\Views\_ViewImports.cshtml"
using Picks.Core;

#line default
#line hidden
#line 3 "F:\Florin\Campus Varnamo_02\02 Molnbaserat_arkitektur\Florin_Picks\Picks\Picks.Web\Views\_ViewImports.cshtml"
using Picks.Infrastructure.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87458b8512227ce231b087ac3d77e06267b605ae", @"/Views/Home/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec7865040515d903d78375176c363055b342537e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "F:\Florin\Campus Varnamo_02\02 Molnbaserat_arkitektur\Florin_Picks\Picks\Picks.Web\Views\Home\Category.cshtml"
  
    ViewData["Title"] = "Category";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(91, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(96, 20, false);
#line 5 "F:\Florin\Campus Varnamo_02\02 Molnbaserat_arkitektur\Florin_Picks\Picks\Picks.Web\Views\Home\Category.cshtml"
Write(ViewData["Category"]);

#line default
#line hidden
            EndContext();
            BeginContext(116, 115, true);
            WriteLiteral("</h1>\r\n\r\n\r\n<div class=\"col-md-12 text-center\">\r\n    <hr />\r\n    <h5>\r\n        Browse by category\r\n    </h5>\r\n</div>");
            EndContext();
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
