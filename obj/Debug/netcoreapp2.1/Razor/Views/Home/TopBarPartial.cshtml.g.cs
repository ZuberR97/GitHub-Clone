#pragma checksum "C:\Users\ryan\Desktop\CodingDojo\PersonalProjects\GithubClone\Views\Home\TopBarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f88d7fb3519fc9d1f85f0b15219501e21e00058f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TopBarPartial), @"mvc.1.0.view", @"/Views/Home/TopBarPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/TopBarPartial.cshtml", typeof(AspNetCore.Views_Home_TopBarPartial))]
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
#line 1 "C:\Users\ryan\Desktop\CodingDojo\PersonalProjects\GithubClone\Views\_ViewImports.cshtml"
using GithubClone;

#line default
#line hidden
#line 2 "C:\Users\ryan\Desktop\CodingDojo\PersonalProjects\GithubClone\Views\_ViewImports.cshtml"
using GithubClone.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f88d7fb3519fc9d1f85f0b15219501e21e00058f", @"/Views/Home/TopBarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f20afbd7abd5be2f002fe8e1d339d1c759d7b226", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TopBarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: inline-block;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 154, true);
            WriteLiteral("<div class=\"TopBarSignedIn\">\r\n    <img src=\"https://onlinejpgtools.com/images/examples-onlinejpgtools/github-logo-transparent-bg.gif\" alt=\"Catopus\">\r\n    ");
            EndContext();
            BeginContext(154, 193, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f541e6690854d469c65a7ac54c32bdd", async() => {
                BeginContext(241, 99, true);
                WriteLiteral(" <!-- likely needs change -->\r\n        <input type=\"text\" placeholder=\"Search or jump to...\">\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(347, 1219, true);
            WriteLiteral(@"
    <a href=""/none"">Pull requests</a>
    <a href=""/none"">Issues</a>
    <a href=""/none"">Marketplace</a>
    <a href=""/none"">Explore</a>
    <a href=""/none"" style=""margin-left:47%;""><img style=""width:20px;"" src=""https://camo.githubusercontent.com/9ae81219be0009a3b727e03e8ae1f009ec632d24/68747470733a2f2f696d6167652e666c617469636f6e2e636f6d2f69636f6e732f7376672f36312f36313037332e737667"" alt=""bell""></a>
    <div class=""Dropdown"">
        <button class=""DropButton"" onclick=""Ndropdown()""><img style=""width:20px;"" src=""https://i.ya-webdesign.com/images/png-white-plus-sign-6.png"" alt=""plus"">▼</button>
        <div id=""NewDropdown"" class=""dropdown-content"">
            <a href="""">New repository</a>
            <a href="""">Import repository</a>
            <a href="""">New gist</a>
            <a href="""">New organization</a>
            <a href="""">New project</a>
        </div>
    </div>
    <div class=""Dropdown"">
        <button class=""DropButton"" onclick=""Adropdown()""><img style=""width:20px;"" src=""htt");
            WriteLiteral("ps://icon-library.net/images/default-profile-icon/default-profile-icon-24.jpg\" alt=\"\">▼</button>\r\n        <div id=\"AccountDropdown\" class=\"dropdown-content\">\r\n            <a href=\"\">Signed in as ");
            EndContext();
            BeginContext(1567, 28, false);
#line 24 "C:\Users\ryan\Desktop\CodingDojo\PersonalProjects\GithubClone\Views\Home\TopBarPartial.cshtml"
                               Write(ViewBag.CurrentUser.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1595, 1034, true);
            WriteLiteral(@"</a>
            <a href="""">New repository</a>
            <a href="""">Import repository</a>
            <a href="""">New gist</a>
            <a href="""">New organization</a>
            <a href="""">New project</a>
        </div>
    </div>
</div>

<script>
    function Ndropdown() 
    {
        document.getElementById(""NewDropdown"").classList.toggle(""show"");
    }

    function Adropdown() 
    {
        document.getElementById(""AccountDropdown"").classList.toggle(""show"");
    }

    window.onclick = function(event) 
    {
        if(!event.target.matches('.DropButton')) 
        {
            var dropdowns = document.getElementsByClassName(""dropdown-content"");
            var i;
            for (i = 0; i < dropdowns.length; i++) 
            {
                var openDropdown = dropdowns[i];
                if (openDropdown.classList.contains('show')) 
                {
                    openDropdown.classList.remove('show');
                }
            }
        }
    }");
            WriteLiteral("\n</script>");
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
