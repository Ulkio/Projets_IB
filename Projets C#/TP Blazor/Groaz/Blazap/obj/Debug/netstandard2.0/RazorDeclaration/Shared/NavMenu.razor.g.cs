#pragma checksum "C:\partage\Blazor\Groaz\Blazap\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3023c314fd5bd0a54146b3b9a5b66ffebb3c9062"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Blazap.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Blazap;

#line default
#line hidden
#line 7 "C:\partage\Blazor\Groaz\Blazap\_Imports.razor"
using Blazap.Shared;

#line default
#line hidden
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 28 "C:\partage\Blazor\Groaz\Blazap\Shared\NavMenu.razor"
       
    bool collapseNavMenu = true;

    string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591
