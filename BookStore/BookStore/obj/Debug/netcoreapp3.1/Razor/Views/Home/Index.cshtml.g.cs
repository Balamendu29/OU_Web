#pragma checksum "D:\School\Advanced Web Design\OU_Web\BookStore\BookStore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8169f922be06d26b7928817fe4ad5732d8672a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\School\Advanced Web Design\OU_Web\BookStore\BookStore\Views\_ViewImports.cshtml"
using BookStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\School\Advanced Web Design\OU_Web\BookStore\BookStore\Views\_ViewImports.cshtml"
using BookStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8169f922be06d26b7928817fe4ad5732d8672a2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"970ad2232b60c18355d1b72e2ff9366751045b67", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\School\Advanced Web Design\OU_Web\BookStore\BookStore\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to B&T BookStore</h1>\r\n");
            WriteLiteral(@"</div>
    <div class=""slideshow-container"">

        <div class=""mySlides fade"">
            <div class=""numbertext"">1 / 5</div>
            <img src=""/images/igallery1.jpg"" style=""width:100%"">
            <div class=""text"">Caption Text</div>
        </div>

        <div class=""mySlides fade"">
            <div class=""numbertext"">2 / 5</div>
            <img src=""/images/igallery2.webp"" style=""width:100%"">
            <div class=""text"">Caption Two</div>
        </div>

        <div class=""mySlides fade"">
            <div class=""numbertext"">3 / 5</div>
            <img src=""/images/igallery3.webp"" style=""width:100%"">
            <div class=""text"">Caption Three</div>
        </div>

        <div class=""mySlides fade"">
            <div class=""numbertext"">4 / 5</div>
            <img src=""/images/igallery4.jpg"" style=""width:100%"">
            <div class=""text"">Caption Four</div>
        </div>

        <div class=""mySlides fade"">
            <div class=""numbertext"">5 / 5</div>
       ");
            WriteLiteral(@"     <img src=""/images/igallery5.webp"" style=""width:100%"">
            <div class=""text"">Caption Five</div>
        </div>

        <a class=""prev"" onclick=""plusSlides(-1)"">&#10094;</a>
        <a class=""next"" onclick=""plusSlides(1)"">&#10095;</a>

    </div>
    <br>

    <div style=""text-align:center"">
        <span class=""dot"" onclick=""currentSlide(1)""></span>
        <span class=""dot"" onclick=""currentSlide(2)""></span>
        <span class=""dot"" onclick=""currentSlide(3)""></span>
        <span class=""dot"" onclick=""currentSlide(4)""></span>
        <span class=""dot"" onclick=""currentSlide(5)""></span>
    </div>

    <script>
        var slideIndex = 1;
        showSlides(slideIndex);

        function plusSlides(n) {
            showSlides(slideIndex += n);
        }

        function currentSlide(n) {
            showSlides(slideIndex = n);
        }

        function showSlides(n) {
            var i;
            var slides = document.getElementsByClassName(""mySlides"");
       ");
            WriteLiteral(@"     var dots = document.getElementsByClassName(""dot"");
            if (n > slides.length) { slideIndex = 1 }
            if (n < 1) { slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = ""none"";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace("" active"", """");
            }
            slides[slideIndex - 1].style.display = ""block"";
            dots[slideIndex - 1].className += "" active"";
        }
    </script>
    
");
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
