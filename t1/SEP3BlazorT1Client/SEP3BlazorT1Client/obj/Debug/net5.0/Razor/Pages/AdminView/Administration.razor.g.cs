#pragma checksum "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa918d0ec5295a98394ea9de8f2322b8c269ee8b"
// <auto-generated/>
#pragma warning disable 1591
namespace SEP3BlazorT1Client.Pages.AdminView
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using SEP3BlazorT1Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using SEP3BlazorT1Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
using SEP3BlazorT1Client.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Administration")]
    public partial class Administration : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MatBlazor.MatTabGroup>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MatBlazor.MatTab>(2);
                __builder2.AddAttribute(3, "Label", "Hosts Requests");
                __builder2.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 7 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
             if (hostRequestList == null)
            {

#line default
#line hidden
#nullable disable
                    __builder3.AddMarkupContent(5, "<p>Nothing to show</p>");
#nullable restore
#line 10 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
            }
            else
            {
                
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                 foreach (var h in hostRequestList)
                {

#line default
#line hidden
#nullable disable
                    __builder3.OpenComponent<MatBlazor.MatAccordion>(6);
                    __builder3.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MatBlazor.MatExpansionPanel>(8);
                        __builder4.AddAttribute(9, "Expanded", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 17 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                                            panelOpenState

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(10, "ExpandedChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => panelOpenState = __value, panelOpenState))));
                        __builder4.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<MatBlazor.MatExpansionPanelSummary>(12);
                            __builder5.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.OpenComponent<MatBlazor.MatExpansionPanelHeader>(14);
                                __builder6.AddAttribute(15, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder7) => {
                                    __builder7.OpenElement(16, "p");
                                    __builder7.AddContent(17, 
#nullable restore
#line 20 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.Id

#line default
#line hidden
#nullable disable
                                    );
                                    __builder7.CloseElement();
                                }
                                ));
                                __builder6.CloseComponent();
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(18, "\r\n                            ");
                            __builder5.OpenComponent<MatBlazor.MatExpansionPanelDetails>(19);
                            __builder5.AddAttribute(20, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.OpenElement(21, "div");
                                __builder6.AddAttribute(22, "class", "form-group");
                                __builder6.OpenElement(23, "p");
                                __builder6.AddContent(24, 
#nullable restore
#line 24 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.Id

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(25, "\r\n                                ");
                                __builder6.OpenElement(26, "div");
                                __builder6.AddAttribute(27, "class", "form-group");
                                __builder6.OpenElement(28, "p");
                                __builder6.AddContent(29, 
#nullable restore
#line 26 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.FirstName

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(30, "\r\n                                ");
                                __builder6.OpenElement(31, "div");
                                __builder6.AddAttribute(32, "class", "form-group");
                                __builder6.OpenElement(33, "p");
                                __builder6.AddContent(34, 
#nullable restore
#line 28 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.LastName

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(35, "\r\n                                ");
                                __builder6.OpenElement(36, "div");
                                __builder6.AddAttribute(37, "class", "form-group");
                                __builder6.OpenElement(38, "p");
                                __builder6.AddContent(39, 
#nullable restore
#line 30 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.PhoneNumber

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(40, "\r\n                                ");
                                __builder6.OpenElement(41, "div");
                                __builder6.AddAttribute(42, "class", "form-group");
                                __builder6.OpenElement(43, "p");
                                __builder6.AddContent(44, 
#nullable restore
#line 32 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.Email

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(45, "\r\n                                ");
                                __builder6.OpenElement(46, "div");
                                __builder6.AddAttribute(47, "class", "form-group");
                                __builder6.OpenElement(48, "p");
                                __builder6.AddContent(49, 
#nullable restore
#line 34 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.Password

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(50, "\r\n                                ");
                                __builder6.OpenElement(51, "div");
                                __builder6.AddAttribute(52, "class", "form-group");
                                __builder6.OpenElement(53, "p");
                                __builder6.AddContent(54, 
#nullable restore
#line 36 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.Cpr

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(55, "\r\n                                ");
                                __builder6.OpenElement(56, "div");
                                __builder6.AddAttribute(57, "class", "form-group");
                                __builder6.OpenElement(58, "p");
                                __builder6.AddContent(59, 
#nullable restore
#line 38 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                        h.ProfileImageUrl

#line default
#line hidden
#nullable disable
                                );
                                __builder6.CloseElement();
                                __builder6.CloseElement();
                                __builder6.AddMarkupContent(60, "\r\n                                ");
                                __builder6.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(61);
                                __builder6.AddAttribute(62, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 39 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                                  h

#line default
#line hidden
#nullable disable
                                ));
                                __builder6.AddAttribute(63, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 39 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                                                     ValidateHost

#line default
#line hidden
#nullable disable
                                )));
                                __builder6.AddAttribute(64, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder7) => {
                                    __builder7.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(65);
                                    __builder7.CloseComponent();
                                    __builder7.AddMarkupContent(66, "\r\n                                    ");
                                    __builder7.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(67);
                                    __builder7.CloseComponent();
                                    __builder7.AddMarkupContent(68, "\r\n                                    ");
                                    __builder7.OpenElement(69, "div");
                                    __builder7.AddAttribute(70, "class", "form-group");
                                    __builder7.OpenElement(71, "p");
                                    __builder7.AddContent(72, 
#nullable restore
#line 43 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                            h.IsApprovedHost

#line default
#line hidden
#nullable disable
                                    );
                                    __builder7.CloseElement();
                                    __builder7.AddMarkupContent(73, "\r\n                                        ");
                                    __builder7.OpenElement(74, "form");
                                    __builder7.OpenElement(75, "select");
                                    __builder7.AddAttribute(76, "name", "Status");
                                    __builder7.OpenElement(77, "option");
                                    __builder7.AddAttribute(78, "value", 
#nullable restore
#line 46 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                                                false

#line default
#line hidden
#nullable disable
                                    );
                                    __builder7.AddContent(79, "Don\'t Aapprove");
                                    __builder7.CloseElement();
                                    __builder7.AddMarkupContent(80, "\r\n                                                ");
                                    __builder7.OpenElement(81, "option");
                                    __builder7.AddAttribute(82, "value", 
#nullable restore
#line 47 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                                                                true

#line default
#line hidden
#nullable disable
                                    );
                                    __builder7.AddContent(83, "Approved");
                                    __builder7.CloseElement();
                                    __builder7.CloseElement();
                                    __builder7.CloseElement();
                                    __builder7.CloseElement();
                                }
                                ));
                                __builder6.CloseComponent();
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
#nullable restore
#line 55 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\kkash\RiderProjects\VIABnB-SEP3\t1\SEP3BlazorT1Client\SEP3BlazorT1Client\Pages\AdminView\Administration.razor"
                 
            }

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
