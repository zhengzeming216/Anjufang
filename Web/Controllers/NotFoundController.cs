using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class NotFoundController : Controller
    {
        /// <summary>
        /// 未找到，不存在提示页面
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(string from)
        {
            return View((object)from);
        }
    }
}