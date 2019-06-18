using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Entity;

namespace Web.Controllers
{
    public class UserControlsController : Controller
    {
        /// <summary>
        /// 新版头部控件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Header(int PageType = 0)
        {
            ViewBag.PageType = PageType;
            return View();
        }

        /// <summary>
        /// 新版底部控件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Footer()
        {
            return View();
        }

        /// <summary>
        /// 轮候库导航控件
        /// </summary>
        /// <param name="WaitingType"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult WaitingNavigation(int WaitingType = 1)
        {
            ViewBag.WaitingType = WaitingType;
            return View();
        }

        /// <summary>
        /// 轮候库搜索控件
        /// </summary>
        /// <param name="SearchKey"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult WaitingSearch(string SearchKey = "")
        {
            ViewBag.SearchKey = SearchKey;
            return View();
        }

        /// <summary>
        /// 楼盘资讯列表（同步加载）
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ArticlesList(List<Dictionary<string, object>> List)
        {
            ViewBag.List = List;
            return View();
        }
        /// <summary>
        /// 新版项目详情等页面导航条控件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //[HttpGet]
        //public ActionResult ProjectHeader(AnjuHouseEntity anjuEntity, Enums.eProjectMenu projectMenu = Enums.eProjectMenu.无)
        //{           
        //    ViewBag.anjuEntity = anjuEntity;
        //    ViewBag.projectMenu = projectMenu;

        //    return View();
        //}
        /// <summary>
        /// 新版楼盘页面没有数据时显示内容
        /// </summary>
        /// <param name="bbsProjectID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProjectNodata(int bbsProjectID)
        {
            ViewBag.bbsProjectID = bbsProjectID;
            return View();
        }

        /// <summary>
        /// m版楼盘详情页导航
        /// </summary>
        /// <param name="bbsProjectID"></param>
        /// <returns></returns>
        //[HttpGet]
        //public ActionResult mProjectNavigation(AnjuHouseEntity anjuEntit)
        //{
        //    ViewBag.anjuEntity = anjuEntit;
        //    return View();
        //}        
    }
}