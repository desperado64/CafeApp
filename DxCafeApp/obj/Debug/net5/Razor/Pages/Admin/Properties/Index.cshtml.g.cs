#pragma checksum "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\Admin\Properties\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fdb836f4130a12f0db6e138e276a88c65c15216"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DxCafeApp.Pages.Admin.Properties.Pages_Admin_Properties_Index), @"mvc.1.0.razor-page", @"/Pages/Admin/Properties/Index.cshtml")]
namespace DxCafeApp.Pages.Admin.Properties
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
#nullable restore
#line 3 "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\Admin\Properties\Index.cshtml"
using CafeApp.Entities.Concrete.Tables;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fdb836f4130a12f0db6e138e276a88c65c15216", @"/Pages/Admin/Properties/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aaf9a5b27400dbc6864ae3d65a36b73415348a3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Properties_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"p-2\">\r\n    <h2>Property Panel</h2>\r\n\r\n    ");
#nullable restore
#line 8 "C:\Users\mg\source\repos\desperado64\CafeApp\DxCafeApp\Pages\Admin\Properties\Index.cshtml"
Write(Html.DevExtreme().DataGrid<Property>()
        .ID("gridContainer")
        .Editing(editing => {
            editing.Mode(GridEditMode.Form);
            editing.AllowUpdating(true);
            editing.AllowAdding(true);
            editing.AllowDeleting(true);
        })
        .Columns(columns => {

            columns.AddFor(m => m.Key);

            columns.AddFor(m => m.Value);

        })
        .AllowColumnReordering(true)
        .ShowBorders(true)
        .Grouping(grouping => grouping.AutoExpandAll(true))
        .SearchPanel(searchPanel => searchPanel.Visible(true))
        .GroupPanel(groupPanel => groupPanel.Visible(true))
        .Paging(paging => paging.PageSize(10))
        .DataSource(d => d.Mvc()
            .Controller("Property")
            .LoadAction("Get")
            .InsertAction("Post")
            .UpdateAction("Put")
            .Key("PropertyID")
        )
    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DxCafeApp.Pages.Admin.Properties.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DxCafeApp.Pages.Admin.Properties.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DxCafeApp.Pages.Admin.Properties.IndexModel>)PageContext?.ViewData;
        public DxCafeApp.Pages.Admin.Properties.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
