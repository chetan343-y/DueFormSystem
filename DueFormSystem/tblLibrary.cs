//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DueFormSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLibrary
    {
        public string PRNNo { get; set; }
        public string PendingBookingId { get; set; }
        public Nullable<decimal> Fine { get; set; }
    
        public virtual tblStudent tblStudent { get; set; }
    }
}
