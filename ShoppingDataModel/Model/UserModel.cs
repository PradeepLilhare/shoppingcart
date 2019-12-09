using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.Model
{
    public class UserModel : ResponseModel
    {
        public int int_id { get; set; }

        public int? intUserId { get; set; }

        public int intModuleTypeId { get; set; }

        [Required(ErrorMessage = "Email Id is required.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email Address")]
        public string strEmailId { get; set; }

        [Required(ErrorMessage = "Mobile no is required.")]
        [RegularExpression(@"^([\+]|0)[(\s]{0,1}[2-9][0-9]{0,2}[\s-)]{0,2}[0-9][0-9][0-9\s-]*[0-9]$", ErrorMessage = "Invalid mobile Address")]
        public string strMobileNo { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string strPassword { get; set; }

        public string strOldPassword { get; set; }
        public string strDeviceId { get; set; }
        public string strDevicetoken { get; set; }
        public string strDevicemode { get; set; }
        public bool strLoginstatus { get; set; }
        public string strName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(10)]
        public string strFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(10)]
        public string strLastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string strAddress { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int intCountryId { get; set; }
        public string strCountry { get; set; }
        public int intStateId { get; set; }
        public string strState { get; set; }
        public int intCityId { get; set; }
        public string strPin { get; set; }
        public string strCity { get; set; }
        public List<CountryList> _listCountry { get; set; }
        public List<StateList> _listState { get; set; }
        public List<CityList> _listCity { get; set; }
        public List<UserTypeList> _listUserType { get; set; }

        public string strUserType { get; set; }


    }
    public class Postloginreq
    {
        public Nullable<int> intloginId { get; set; }
        public string strEmailId { get; set; }
        public string strPassword { get; set; }
        public string strDevicemode { get; set; }
        public string strMobileNo { get; set; }
        public int intModuleTypeId { get; set; }
        public string strDeviceId { get; set; }
        public string strDevicetoken { get; set; }
        public bool strLoginstatus { get; set; }
    }
    public class Postloginres
    {
        public int intUserId { get; set; }
        public string strName { get; set; }
        public string strEmailId { get; set; }
        public string strMobileNo { get; set; }
        public string strMsg { get; set; }       
    }
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        //public string strUserName { get; set; }        
        public string strEmailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string strPassword { get; set; }

        public int intEmployeeId { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class CountryList
    {
        public int int_id { get; set; }
        public string v_name { get; set; }
    }

    public class StateList
    {
        public int int_id { get; set; }
        public string v_name { get; set; }
    }
    public class CityList
    {
        public int int_id { get; set; }
        public string v_name { get; set; }
    }
    public class UserTypeList
    {
        public int int_id { get; set; }
        public string v_User_Type { get; set; }
    }
    public class UserModelList
    {
        public List<CountryList> _listCountry { get; set; }
        public List<StateList> _listState { get; set; }
        public List<CityList> _listCity { get; set; }
        public List<UserTypeList> _listUserType { get; set; }
    }
}
