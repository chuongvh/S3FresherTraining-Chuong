using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace S3Train
{
    /// <summary>
    /// Base controller for Front End page
    /// </summary>
    public abstract class AppControllerBase : Controller
    {

    }

    /// <summary>
    /// Base controller for Admin page
    /// </summary>
    public abstract class AdminControllerBase : AppControllerBase
    {

    }
}
