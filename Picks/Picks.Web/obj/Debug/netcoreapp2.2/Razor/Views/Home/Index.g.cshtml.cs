#pragma checksum "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d98e2d04f8e4bbe8d352125e1652c217a66abeba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\_ViewImports.cshtml"
using Picks.Web;

#line default
#line hidden
#line 2 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\_ViewImports.cshtml"
using Picks.Core;

#line default
#line hidden
#line 3 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\_ViewImports.cshtml"
using Picks.Infrastructure.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d98e2d04f8e4bbe8d352125e1652c217a66abeba", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec7865040515d903d78375176c363055b342537e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FileUploadViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Catalog";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(120, 265, true);
            WriteLiteral(@"
<div class=""col-md-12"">
    <hr />
    <h4 class=""text-uppercase text-center"">All images from all categories</h4>

    <section class=""ftco-section-2 @*text-center*@"">
        <div class=""photograhy"">
            <div class=""row no-gutters text-center"">

");
            EndContext();
#line 16 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml"
                 if (Model.FileUpload.Count == 0)
                {

#line default
#line hidden
            BeginContext(455, 33, true);
            WriteLiteral("                    <div></div>\r\n");
            EndContext();
#line 19 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#line 22 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml"
                     foreach (var v in Model.FileUpload)
                    {

#line default
#line hidden
            BeginContext(629, 112, true);
            WriteLiteral("                        <div class=\"col-md-4 ftco-animate\" style=\"padding: 3px\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 741, "\"", 759, 1);
#line 25 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 748, v.FilePath, 748, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(760, 97, true);
            WriteLiteral(" data-lightbox=\"roadtrip\" class=\"photography-entry img justify-content-center align-items-center\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 857, "\"", 899, 4);
            WriteAttributeValue("", 865, "background-image:", 865, 17, true);
            WriteAttributeValue(" ", 882, "url(", 883, 5, true);
#line 25 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 887, v.FilePath, 887, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 898, ")", 898, 1, true);
            EndWriteAttribute();
            BeginContext(900, 234, true);
            WriteLiteral(">\r\n                                <div class=\"overlay\"></div>\r\n                                <div class=\"text text-center\">\r\n                                </div>\r\n                            </a>\r\n                        </div>\r\n");
            EndContext();
#line 31 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#line 31 "F:\MyProjects for interviews\03_PicksProject\Picks\Picks.Web\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
            BeginContext(1176, 60, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </section>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FileUploadViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
