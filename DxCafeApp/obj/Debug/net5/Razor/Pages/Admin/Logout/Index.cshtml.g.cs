#pragma checksum "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\Admin\Logout\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b36ac5f9496c6c3d5bcc6a95690860ee73148b0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DxCafeApp.Pages.Admin.Logout.Pages_Admin_Logout_Index), @"mvc.1.0.razor-page", @"/Pages/Admin/Logout/Index.cshtml")]
namespace DxCafeApp.Pages.Admin.Logout
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
#line 1 "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\_ViewImports.cshtml"
using DxCafeApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b36ac5f9496c6c3d5bcc6a95690860ee73148b0b", @"/Pages/Admin/Logout/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aaf9a5b27400dbc6864ae3d65a36b73415348a3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Logout_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<meta http-equiv=\"refresh\" content=\"3;URL=../../\">\r\n\r\n<div class=\"p-5\">\r\n");
#nullable restore
#line 8 "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\Admin\Logout\Index.cshtml"
      
        
        if (ViewData["IsMessage"].Equals("True"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-warning\" role=\"alert\">\r\n                ");
#nullable restore
#line 13 "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\Admin\Logout\Index.cshtml"
           Write(ViewData["Message"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 15 "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\Admin\Logout\Index.cshtml"
        }

    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DxCafeApp.Pages.Admin.Logout.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DxCafeApp.Pages.Admin.Logout.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DxCafeApp.Pages.Admin.Logout.IndexModel>)PageContext?.ViewData;
        public DxCafeApp.Pages.Admin.Logout.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591