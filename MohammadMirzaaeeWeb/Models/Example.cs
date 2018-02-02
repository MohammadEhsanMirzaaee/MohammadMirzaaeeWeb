using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MohammadMirzaaeeWeb.Models
{
    public class Example
    {
        [AllowHtml]
        public string HtmlContent { get; set; }

        public Example()
        {

        }
    }
}