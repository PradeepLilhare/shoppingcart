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
    
    public partial class tbl_All_User
    {
        public int int_id { get; set; }
        public string v_FirstName { get; set; }
        public string v_LastName { get; set; }
        public Nullable<int> int_CityId { get; set; }
        public Nullable<int> int_StateId { get; set; }
        public Nullable<int> int_CountryId { get; set; }
        public string v_address { get; set; }
        public string v_Pin { get; set; }
        public string v_MobileNo { get; set; }
        public string v_EmailId { get; set; }
        public string v_Password { get; set; }
        public byte[] o_Cart { get; set; }
        public Nullable<int> int_User_Type { get; set; }
        public Nullable<System.DateTime> dt_CreatedOn { get; set; }
        public Nullable<bool> b_IsActive { get; set; }
    }
}
