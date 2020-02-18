using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestWebApp.Models
{

    public class SampleModel
    {
        [UIHint("String")]
        public string SampleString1 { get; set; }
        [UIHint("String")]
        public string SampleString2 { get; set; }
        [UIHint("String")]
        public string SampleString3 { get; set; }


        [UIHint("DropdownList")]
        public string SampleDropdown1 { get; set; }

    }
}
