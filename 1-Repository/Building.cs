//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1_Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Building
    {
        public int BuildingID { get; set; }

        [Display(Name ="�����")]
        public string Name { get; set; }

        [AllowHtml]
        [Display(Name = "�����")]
        public string Content { get; set; }
        public Nullable<int> Priority { get; set; }
        public string ImageAddress { get; set; }
        public Nullable<int> CategoryRefID { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
