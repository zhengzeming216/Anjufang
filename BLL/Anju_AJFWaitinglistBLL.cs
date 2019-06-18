using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Anju_AJFWaitinglistBLL
    {
        /// <summary>
        /// 安居房轮候库最后更新时间
        /// </summary>
        public const string LastDate = "2019.05.23";

        /// <summary>
        /// 获取数据库一条记录实体(根据主键条件)
        /// </summary>
        /// <param name="id">序号</param>
        /// <returns>Anju_AJFWaitinglistEntity实体类</returns>
        public static Anju_AJFWaitinglistEntity GetById(int id)
        {
            return Anju_AJFWaitinglistDAL.GetById(id);
        }

        /// <summary>
        /// 获取数据库一条记录实体(根据备案回执号)
        /// </summary>
        /// <param name="BGNo">备案回执号</param>
        /// <returns>Entity.Anju_AJFWaitinglistEntity实体类</returns>
        public static Anju_AJFWaitinglistEntity GetByBGNo(string BGNo)
        {
            return Anju_AJFWaitinglistDAL.GetByBGNo(BGNo);
        }

        /// <summary>
        /// 查询共同申请人，Category=2，ParentID相同
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static List<Anju_AJFWaitinglistEntity> GetJointApplicant(int id)
        {
            //string strWhere = "Category !=1 And ParentID=" + id;
            return Anju_AJFWaitinglistDAL.GetAll().Where(e => e.Category != 1).Where(e => e.ParentID == id).ToList();
        }

        /// <summary>
        /// 获得备注说明
        /// </summary>
        /// <param name="strGiveUp"></param>
        /// <param name="HouseName"></param>
        /// <param name="FamilyType"></param>
        /// <param name="GiveupContractNum"></param>
        /// <returns></returns>     
        protected static string GetRemark(string strGiveUp, string HouseName, string FamilyType, int GiveupContractNum)
        {
            int GiveUp = Convert.ToInt32(strGiveUp);
            string result = "";// "弃权次数:" + GiveUp + "<br/>";
            if (GiveUp > 0)
            {
                result += "放弃选房" + GiveUp + "次<br/>";
            }
            //if (!string.IsNullOrEmpty(GiveUpProject))
            //{
            //    result += "你已弃签" + GiveUpProject + "的购房合同<br/>";
            //}

            if (GiveupContractNum > 0)
            {
                result += "放弃签约" + GiveupContractNum + "次<br/>";
            }

            if (!string.IsNullOrEmpty(HouseName))
            {
                result += HouseName + "<br/>";
            }
            if (!string.IsNullOrEmpty(FamilyType))
            {
                string[] Array = FamilyType.Split(',');
                foreach (string str in Array)
                {
                    if (string.IsNullOrWhiteSpace(str))
                    {
                        continue;
                    }
                    result += str + "<br/>";
                }
            }
            if (!string.IsNullOrWhiteSpace(result))
            {
                result = result.Substring(0, result.Length - 5);
            }
            return result;
        }

        protected static string GetWaitType(string intWaitType)
        {
            int WaitType = Convert.ToInt32(intWaitType);
            if (WaitType == 1)
            {
                return "(首次轮候)";
            }
            else
            {
                return "(日常轮候)";
            }
        }

        protected static string GetHouse(int FamilyCount)
        {
            if (FamilyCount > 3)
            {
                return "(三房一厅)";
            }
            else
            {
                return "(两房一厅)";
            }
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="SearchType"></param>
        /// <param name="FamilyCount">家庭人数</param>
        /// <param name="FamilyType">特殊家庭</param>
        /// <param name="FamilyHouse">未选房家庭</param>
        /// <param name="waitingType">轮候类型</param>
        /// <returns></returns>
        public static string GetWhere(string searchKey, int SearchType, int FamilyCount, int FamilyType, int FamilyHouse, int waitingType)
        {
            if (SZHomeDLL.StringHelper.IsIncludeSqlInjection(searchKey))
            {
                searchKey = "";
            }
            var list = Anju_AJFWaitinglistDAL.GetAll().Where(e=>e.Category==1);
            string where = "\"Category\" = 1 And ", strFamily = string.Empty;

            if (string.IsNullOrWhiteSpace(searchKey))
            {
                SearchType = -1;
                strFamily = "\"RealTimeRanking\" != 0 And ";
            }

            switch (waitingType)
            {
                case 1:
                    //首次轮候
                    where += "\"AJHouseType\" = 1 And ";
                    break;
                case 2:
                    //日常轮候
                    where += "\"AJHouseType\" = 2  And ";
                    break;
                default:
                    //不做限制
                    break;
            }

            if (!string.IsNullOrEmpty(searchKey))
            {
                switch (SearchType)
                {
                    case 0:
                        //全匹配
                        where += " \"SearchALL\" like '%" + searchKey.Trim() + "%' And ";
                        break;
                    case 1:
                        //只匹配备案号
                        where += " \"BGNo\" like '%" + searchKey.Trim() + "%' And ";
                        break;
                    case 2:
                        //只匹配姓名
                        where += " \"SearchName\" like '%" + searchKey.Trim() + "%' And ";
                        break;
                    case 3:
                        //只匹配身份证
                        where += " \"SearchIDCardNo\" like '%" + searchKey.Trim() + "%' And ";
                        break;
                    default:
                        //什么都不匹配
                        break;
                }

            }

            switch (FamilyCount)
            {
                case 1:
                    //两房一厅排位(统计1~3人家庭)
                    where += " \"FamilyCount\" in (1,2,3) And ";
                    break;
                case 2:
                    //三房一厅排位(统计4人及以上家庭)
                    where += " \"FamilyCount\" > 3 And ";
                    break;
                default:
                    //什么都没选
                    break;
            }

            switch (FamilyType)
            {
                case 1:
                    //残疾人家庭
                    where += " \"SearchFamilyType\" like '%残疾%' And ";
                    break;
                case 2:
                    //抚恤定补家庭
                    where += " \"SearchFamilyType\" like '%抚恤定补%' And ";
                    break;
                case 3:
                    //人才家庭
                    where += " \"SearchFamilyType\" like '%人才%' And ";
                    break;
                default:
                    //什么都没选
                    break;
            }

            switch (FamilyHouse)
            {
                case 1:
                    //所有未选房的家庭
                    where += " length(\"SelectProject\") = 0 AND  \"GiveupContractNum\"<2 AND \"GiveupSelectNum\"<3 AND ";
                    break;
                case 2:
                    //弃权一次的家庭
                    where += " \"GiveupSelectNum\" = 1 And length(\"SelectProject\") = 0 And \"RealTimeRanking\" != 0 AND ";
                    break;
                case 3:
                    //弃权两次的家庭
                    where += " \"GiveupSelectNum\" = 2 And length(\"SelectProject\") = 0 And \"RealTimeRanking\" != 0 AND ";
                    break;
                case 4:
                    //弃权三次的家庭
                    where += " \"GiveupSelectNum\" = 3 And length(\"SelectProject\") = 0 And \"RealTimeRanking\" != 0 AND ";
                    break;
                case 5:
                    //弃签一次的
                    where += " \"GiveupContractNum\" = 1 And length(\"SelectProject\") = 0 And ";
                    break;
                case 6:
                    //弃签一次的
                    where += " \"GiveupContractNum\" = 2 And length(\"SelectProject\") = 0 And ";
                    break;
                default:
                    //什么都没选、全部家庭,默认不显示已选择楼盘的家庭 
                    where += strFamily;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(where))
            {
                where = where.Substring(0, where.Length - 4);
            }
            return where;
        }

        public static List<Anju_AJFWaitinglistEntity> GetAll()
        {
            return Anju_AJFWaitinglistDAL.GetAll().ToList() ;
        }

        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="SearchType"></param>
        /// <param name="FamilyCount"></param>
        /// <param name="FamilyType"></param>
        /// <param name="FamilyHouse"></param>
        /// <param name="waitingType"></param>
        /// <param name="pageSet"></param>
        /// <returns></returns>

        public static List<Anju_AJFWaitinglistEntity> GetPageList(string searchKey, int SearchType, int FamilyCount, int FamilyType, int FamilyHouse, int waitingType, PageSet pageSet)
        {
            string strWhere = GetWhere(searchKey, SearchType, FamilyCount, FamilyType, FamilyHouse, waitingType);
            pageSet.RecordCount = Anju_AJFWaitinglistDAL.SearchCount(strWhere);
            pageSet.PageCount = (int)System.Math.Ceiling(pageSet.RecordCount / (pageSet.PageSize * 1.0));
            return Anju_AJFWaitinglistDAL.Search(strWhere, "\"AJHouseType\",\"RealTimeRanking\",\"Id\"", (pageSet.PageIndex - 1) * pageSet.PageSize, pageSet.PageSize);
        }

        

        /// <summary>
        /// 显示排名
        /// </summary>
        /// <param name="FamilyType"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetStrPM(Anju_AJFWaitinglistEntity item)
        {
            string strPM = "";
            if (item.FamilyCount > 3)
            {
                strPM = item.FamilyRange + "(三房一厅)";
            }
            else
            {
                strPM = item.FamilyRange + "(两房一厅)";
            }

            return strPM;
        }

        /// <summary>
        /// 排名标题
        /// </summary>
        /// <param name="FamilyType"></param>
        /// <returns></returns>
        public static string GetStrPMTitle(int FamilyType)
        {
            string strHX = "实时房型<br>排位";
            switch (FamilyType)
            {
                case 0:
                    strHX = "实时房型<br>排位";
                    break;
                case 1:
                    strHX = "两房一厅";
                    break;
                case 2:
                    strHX = "三房一厅";
                    break;
            }

            return strHX;
        }

        

        //public Anju_AJFWaitinglistEntity GetById(int id)
        //{
        //    return Anju_AJFWaitinglistDAL.GetById(id);
        //}
    }
}
