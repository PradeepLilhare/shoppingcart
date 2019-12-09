﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class newconecommerce : DbContext
    {
        public newconecommerce()
            : base("name=newconecommerce")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_All_User> tbl_All_User { get; set; }
        public virtual DbSet<tbl_appointment> tbl_appointment { get; set; }
        public virtual DbSet<tbl_Brands> tbl_Brands { get; set; }
        public virtual DbSet<tbl_category> tbl_category { get; set; }
        public virtual DbSet<tbl_Cities> tbl_Cities { get; set; }
        public virtual DbSet<tbl_Countries> tbl_Countries { get; set; }
        public virtual DbSet<tbl_credit_debit_history> tbl_credit_debit_history { get; set; }
        public virtual DbSet<tbl_order_product> tbl_order_product { get; set; }
        public virtual DbSet<tbl_OTP> tbl_OTP { get; set; }
        public virtual DbSet<tbl_Products> tbl_Products { get; set; }
        public virtual DbSet<tbl_service_management> tbl_service_management { get; set; }
        public virtual DbSet<tbl_shipping_address> tbl_shipping_address { get; set; }
        public virtual DbSet<tbl_States> tbl_States { get; set; }
        public virtual DbSet<tbl_User_Types> tbl_User_Types { get; set; }
    
        public virtual ObjectResult<byte[]> usp_get_user_cart_by_id(Nullable<int> int_user_id)
        {
            var int_user_idParameter = int_user_id.HasValue ?
                new ObjectParameter("int_user_id", int_user_id) :
                new ObjectParameter("int_user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<byte[]>("usp_get_user_cart_by_id", int_user_idParameter);
        }
    
        public virtual int usp_insert_shopping_cart(Nullable<int> int_user_id, byte[] buffer)
        {
            var int_user_idParameter = int_user_id.HasValue ?
                new ObjectParameter("int_user_id", int_user_id) :
                new ObjectParameter("int_user_id", typeof(int));
    
            var bufferParameter = buffer != null ?
                new ObjectParameter("buffer", buffer) :
                new ObjectParameter("buffer", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_insert_shopping_cart", int_user_idParameter, bufferParameter);
        }
    
        public virtual ObjectResult<usp_user_login_Result> usp_user_login(Nullable<int> v_EmailId, string v_Password, string v_MobileNo, Nullable<int> intModuleTypeId, string strDeviceId, string strDevicetoken, string strDevicemode)
        {
            var v_EmailIdParameter = v_EmailId.HasValue ?
                new ObjectParameter("v_EmailId", v_EmailId) :
                new ObjectParameter("v_EmailId", typeof(int));
    
            var v_PasswordParameter = v_Password != null ?
                new ObjectParameter("v_Password", v_Password) :
                new ObjectParameter("v_Password", typeof(string));
    
            var v_MobileNoParameter = v_MobileNo != null ?
                new ObjectParameter("v_MobileNo", v_MobileNo) :
                new ObjectParameter("v_MobileNo", typeof(string));
    
            var intModuleTypeIdParameter = intModuleTypeId.HasValue ?
                new ObjectParameter("intModuleTypeId", intModuleTypeId) :
                new ObjectParameter("intModuleTypeId", typeof(int));
    
            var strDeviceIdParameter = strDeviceId != null ?
                new ObjectParameter("strDeviceId", strDeviceId) :
                new ObjectParameter("strDeviceId", typeof(string));
    
            var strDevicetokenParameter = strDevicetoken != null ?
                new ObjectParameter("strDevicetoken", strDevicetoken) :
                new ObjectParameter("strDevicetoken", typeof(string));
    
            var strDevicemodeParameter = strDevicemode != null ?
                new ObjectParameter("strDevicemode", strDevicemode) :
                new ObjectParameter("strDevicemode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_user_login_Result>("usp_user_login", v_EmailIdParameter, v_PasswordParameter, v_MobileNoParameter, intModuleTypeIdParameter, strDeviceIdParameter, strDevicetokenParameter, strDevicemodeParameter);
        }
    }
}
