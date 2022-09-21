// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ToolsApp.Tests.Components.CarTool
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using Microsoft.Extensions.DependencyInjection;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using AngleSharp.Dom;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using Xunit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using Bunit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using Bunit.TestDoubles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using ToolsApp.Components.ColorTool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/_Imports.razor"
using ToolsApp.Components.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/Components/CarTool/CarViewRowRazorTest.razor"
using ToolsApp.Components.CarTool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/Components/CarTool/CarViewRowRazorTest.razor"
using ToolsApp.Models;

#line default
#line hidden
#nullable disable
    public partial class CarViewRowRazorTest : TestContext
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/Components/CarTool/CarViewRowRazorTest.razor"
       

  [Fact]
  public void CarViewRowComponentRendersCorrectly()
  {
    // Arrange
    var car = new Car {
      Id=1, 
      Make="Ford",
      Model="Fusion Hybrid",
      Year=2020, Color="blue",
      Price=45000.0M
    };

    // Act
    var cut = Render(

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.OpenElement(0, "CarViewRow");
            __builder2.AddAttribute(1, "Car", 
#nullable restore
#line 21 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/Components/CarTool/CarViewRowRazorTest.razor"
                                        car

#line default
#line hidden
#nullable disable
            );
            __builder2.CloseElement();
        }
#nullable restore
#line 21 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/Components/CarTool/CarViewRowRazorTest.razor"
                                               );

    // Assert
    cut.MarkupMatches(
      

#line default
#line hidden
#nullable disable
        (__builder2) => {
            __builder2.AddMarkupContent(2, @"<tr>
        <td>1</td>
        <td>Ford</td>
        <td>Fusion Hybrid</td>
        <td>2020</td>
        <td>blue</td>
        <td>45000.0</td>
        <td>
          <button>Edit</button>
          <button>Delete</button>
        </td>
      </tr>
");
        }
#nullable restore
#line 37 "/Users/ericwgreene/git/github.com/t4d-classes/blazor-server_05232022/ToolsAppComplete/ToolsApp.Tests/Components/CarTool/CarViewRowRazorTest.razor"
    );
  }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
