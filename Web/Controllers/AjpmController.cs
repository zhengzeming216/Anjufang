using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entity;
using Common;

namespace Web.Controllers
{
    public class AjpmController : Controller
    {
        ///// <summary>
        ///// 安居房轮候排名
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        #region pc版
        /// <summary>
        /// 安居房轮候排名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                id = "1-0-0-0-1-0";
            }
            string[] array = id.Split('-');
            if (array.Length != 6)
            {
                id = "1-0-0-0-1-0";
                array = id.Split('-');
            }
            string SearchKey = string.IsNullOrEmpty(Request["key"]) ? "" : Request["key"].Trim(); //查询关键字 

            int Pages = Convert.ToInt32(array[0]),
                SearchType = Convert.ToInt32(array[1]),
                FamilyCount = Convert.ToInt32(array[2]),
                FamilyType = Convert.ToInt32(array[3]),
                FamilyHouse = Convert.ToInt32(array[4]),
                waitingType = Convert.ToInt32(array[5]);

            //if (SZHomeDLL.StringHelper.IsIncludeSqlInjection(SearchKey))
            //{
            //    SearchKey = "";
            //}
            if (Pages < 1)
            {
                Pages = 1;
            }
            PageSet pageSet = new PageSet() { PageIndex = Pages, PageSize = 20 };

            List<Anju_AJFWaitinglistEntity> List = new List<Anju_AJFWaitinglistEntity>(); //轮候库
            //List<Anju_AJFHouseResultEntity> listResult = new List<Anju_AJFHouseResultEntity>(); //选房结果

            if (FamilyHouse < 10)
            {
                List = Anju_AJFWaitinglistBLL.GetPageList(SearchKey, SearchType, FamilyCount, FamilyType, FamilyHouse, waitingType, pageSet);
                //List = Anju_AJFWaitinglistBLL.GetAll(FamilyCount, FamilyType);
            }
            //else
            //{
            //    listResult = Anju_AJFHouseResultBLL.GetPageList(SearchKey, SearchType, FamilyHouse, pageSet);
            //}

            ViewBag.List = List;
            //ViewBag.listResult = listResult;
            ViewBag.Pages = Pages;
            ViewBag.Pagesize = pageSet.PageSize;
            ViewBag.SearchType = SearchType;
            ViewBag.FamilyCount = FamilyCount;
            ViewBag.FamilyType = FamilyType;
            ViewBag.FamilyHouse = FamilyHouse;
            ViewBag.waitingType = waitingType;
            ViewBag.SearchKey = SearchKey;
            ViewBag.Count = pageSet.RecordCount;
            ViewBag.PageType = (int)Enums.ePageType.轮候排名查询;

            return View();
        }

        /// <summary>
        /// 安居房轮候库家庭情况详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Family(int id)
        {
            Anju_AJFWaitinglistEntity entity = Anju_AJFWaitinglistBLL.GetById(id);
            if (entity == null)
            {
                return View("~/Views/NotFound/Index.cshtml");
            }

            if (entity.Category != (int)Enums.eCategory.申请人)
            {
                return View("~/Views/NotFound/Index.cshtml");
            }

            //共同申请人
            List<Anju_AJFWaitinglistEntity> List = Anju_AJFWaitinglistBLL.GetJointApplicant(id);

            ViewBag.entity = entity;
            ViewBag.List = List;
            return View();
        }

        #endregion pc版


        //#region m版

        ///// <summary>
        ///// 安居房轮候库查询条件
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult mIndex()
        //{
        //    return View();
        //}

        ///// <summary>
        ///// 安居房轮候库查询结果
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult SearchList()
        //{
        //    int WaitingType = string.IsNullOrEmpty(Request["w"]) ? 0 : SZHomeDLL.ConvertHelper.StringToInt(Request["w"]); //轮候类型
        //    int FamilyCount = string.IsNullOrEmpty(Request["c"]) ? 0 : SZHomeDLL.ConvertHelper.StringToInt(Request["c"]);  //家庭人数
        //    int FamilyType = string.IsNullOrEmpty(Request["f"]) ? 0 : SZHomeDLL.ConvertHelper.StringToInt(Request["f"]);   //特殊家庭：
        //    int FamilyHouse = string.IsNullOrEmpty(Request["h"]) ? 1 : SZHomeDLL.ConvertHelper.StringToInt(Request["h"]);  //未选房/已选房家庭
        //    string SearchKey = string.IsNullOrEmpty(Request["key"]) ? "" : Request["key"]; //查询关键字 

        //    ViewBag.WaitingType = WaitingType;
        //    ViewBag.FamilyCount = FamilyCount;
        //    ViewBag.FamilyType = FamilyType;
        //    ViewBag.FamilyHouse = FamilyHouse;
        //    ViewBag.SearchKey = SearchKey;

        //    return View();
        //}

        ///// <summary>
        ///// 分页查询安居房轮候库数据
        ///// </summary>
        ///// <param name="SearchType"></param>
        ///// <param name="FamilyCount"></param>
        ///// <param name="FamilyType"></param>
        ///// <param name="FamilyHouse"></param>
        ///// <param name="waitingType"></param>
        ///// <param name="SearchKey"></param>
        ///// <param name="Pages"></param>
        ///// <returns></returns>
        //[HttpPost, AjaxFilter, JsonException]
        //public ActionResult Search(int FamilyCount, int FamilyType, int FamilyHouse, int waitingType, string SearchKey, int Pages)
        //{

        //    HandleResult hr = new HandleResult();

        //    if (SZHomeDLL.StringHelper.IsIncludeSqlInjection(SearchKey))
        //    {
        //        SearchKey = "";
        //    }
        //    if (Pages < 1)
        //    {
        //        Pages = 1;
        //    }
        //    PageSet pageSet = new PageSet() { PageIndex = Pages, PageSize = 10 };

        //    List<Dictionary<string, object>> List = new List<Dictionary<string, object>>();
        //    if (FamilyHouse < 10)
        //    {
        //        List<Anju_AJFWaitinglistEntity> ListAJF = Anju_AJFWaitinglistBLL.GetPageList(SearchKey, 0, FamilyCount, FamilyType, FamilyHouse, waitingType, pageSet);
        //        List = Anju_AJFWaitinglistBLL.GetDictionaryBydtAJF(ListAJF);
        //    }
        //    else
        //    {
        //        List<Anju_AJFHouseResultEntity> listResult = Anju_AJFHouseResultBLL.GetPageList(SearchKey, 0, FamilyHouse, pageSet);
        //        List = Anju_AJFWaitinglistBLL.GetDictionaryBydtAJF(listResult);
        //    }

        //    hr.StatsCode = 200;
        //    hr.Message = "ok";
        //    hr.Data = List;
        //    hr.Other = pageSet.RecordCount.ToString();
        //    return Json(hr);
        //}

        ///// <summary>
        ///// m版安居房轮候库家庭情况详情
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult mFamily(int id)
        //{
        //    Anju_AJFWaitinglistEntity entity = Anju_AJFWaitinglistBLL.GetById(id);
        //    if (entity == null)
        //    {
        //        return View("~/Views/NotFound/Index.cshtml");
        //    }

        //    if (entity.Category != (int)Enums.eCategory.申请人)
        //    {
        //        return View("~/Views/NotFound/Index.cshtml");
        //    }

        //    //共同申请人
        //    List<Anju_AJFWaitinglistEntity> List = Anju_AJFWaitinglistBLL.GetJointApplicant(id);

        //    ViewBag.entity = entity;
        //    ViewBag.List = List;
        //    return View();
        //}

        //#endregion m版
    }
}