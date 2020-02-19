using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Core.Enum
{
    public class DefaultRole
    {
        public const string Administration = "Administration";
    }

    public class DefaultUser
    {
        public const string Administration = "admin";
    }


    public enum UserRoles
    {
        [Display(Name = "Administration")]
        [Description("Administration")]
        Administration = 1,
        [Display(Name = "Customer")]
        [Description("Customer")]
        Customer,
        [Display(Name = "Guest")]
        [Description("Guest")]
        Guest
    }
}
