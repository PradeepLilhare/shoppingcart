//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_service_management
    {
        public int int_id { get; set; }
        public string v_service { get; set; }
        public string v_latitude { get; set; }
        public string v_longitude { get; set; }
        public string v_address { get; set; }
        public string v_problem { get; set; }
        public Nullable<int> int_preferred_time { get; set; }
        public string v_image_path { get; set; }
        public Nullable<int> int_emp_id { get; set; }
        public Nullable<int> int_status_id { get; set; }
        public Nullable<int> int_tip_amount { get; set; }
        public Nullable<System.DateTime> dt_created_on { get; set; }
    }
}
