//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToDoes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ToDo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This Field is Required")]
        public string Description { get; set; }
        public Nullable<bool> IsDone { get; set; }
    }
}
