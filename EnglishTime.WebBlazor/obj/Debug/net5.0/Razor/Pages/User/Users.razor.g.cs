#pragma checksum "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45ac1872f3aa891463513d78403ccacfc7048756"
// <auto-generated/>
#pragma warning disable 1591
namespace EnglishTime.WebBlazor.Pages.User
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using EnglishTime.WebBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\_Imports.razor"
using EnglishTime.WebBlazor.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/user")]
    public partial class Users : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>English Time Users</h1>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>This component is just fetching all English Time user registered.</p>");
#nullable restore
#line 8 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor"
 if (users == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<p><em>Loading...</em></p>");
#nullable restore
#line 11 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "table");
            __builder.AddAttribute(4, "class", "table");
            __builder.AddMarkupContent(5, "<thead><tr><th>Name</th>\r\n                <th>Email</th>\r\n                <th>JobTitle</th></tr></thead>\r\n        ");
            __builder.OpenElement(6, "tbody");
#nullable restore
#line 23 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor"
             foreach (var user in users)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(7, "tr");
            __builder.OpenElement(8, "td");
            __builder.AddContent(9, 
#nullable restore
#line 26 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor"
                         user.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n                    ");
            __builder.OpenElement(11, "td");
            __builder.AddContent(12, 
#nullable restore
#line 27 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor"
                         user.Email

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n                    ");
            __builder.OpenElement(14, "td");
            __builder.AddContent(15, 
#nullable restore
#line 28 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor"
                         user.JobTitle

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 30 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 33 "C:\Guilherme\English-Time\Project\EnglishTime.WebBlazor\Pages\User\Users.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591