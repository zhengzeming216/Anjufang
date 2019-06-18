using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Enums
    {
        /// <summary>
        /// 安居房类型
        /// </summary>
        public enum eAnjuType
        {
            安居房 = 1,
            公租房 = 2,
            人才房 = 4
        }

        /// <summary>
        /// 标签类型
        /// </summary>
        public enum eTagType
        {
            普通标签 = 0,
            新房标签 = 1
        }

        /// <summary>
        /// 系统类型
        /// </summary>
        public enum eSystemType
        {
            默认 = 0,
            家在深圳 = 1,
            咚咚找房 = 2,
            咚咚抢客 = 3,
            哇窝装修 = 4
        }

        /// <summary>
        /// 楼盘页目录
        /// </summary>
        public enum eProjectMenu
        {
            无 = 0,
            楼评 = 1,
            户型 = 2,
            样板间 = 3,
            相册 = 4,
            资讯动态 = 5,
            详细信息 = 6,
            楼盘圈子 = 7,
            销控表 = 8
        }

        //项目特色
        public enum eXMTS
        {
            地铁口 = 1,
            地铁周边 = 2,
            多地铁 = 4,
            学位房 = 8,
            名校学区 = 16,
            近公园 = 32,
            山水景观 = 64,
            中心区 = 128,
            品质住宅 = 256,
            精品公寓 = 512,
            花园式小区 = 1024,
            综合体 = 2048,
            成熟片区 = 4096,
            新兴片区 = 8192,
            高拓展率 = 16384,
            海滨住宅 = 32768,
            大型社区 = 65536,
            商住两用 = 131072,
            品质写字楼 = 262144,
            重点产业园 = 524288,
            配套丰富 = 1048576,
            自带大型商业 = 2097152,
            容积率低 = 4194304,
            带装修 = 8388608,
            高绿化率 = 16777216,
            现楼 = 33554432
        }

        /// <summary>
        /// 项目户型类型（即主力户型）
        /// </summary>
        /// <remarks></remarks>
        public enum ZLHX
        {
            一房 = 1,
            二房 = 2,
            三房 = 3,
            四房 = 4,
            五房及以上 = 5,
            写字楼 = 6,
            商务公寓 = 7,
            复式 = 8,
            单身公寓 = 9,
            别墅 = 10,
            商业 = 11
        }

        /// <summary>
        /// 新闻类别
        /// </summary>
        public enum eNewstype
        {
            首页 = 0,
            安居房 = 1,
            公租房 = 2,
            人才房 = 3
        }

        /// <summary>
        /// 新闻显示类型
        /// </summary>
        public enum eNewsCategory
        {
            顶部热讯 = 1,
            顶部滚动资讯 = 2,
            顶部图片资讯 = 3,
            滚动资讯 = 4,
            图片资讯 = 5,
            公益设计 = 6,
            顶部背景图 = 7,
            百问百答热搜 = 8,
            底部广告图 = 9
        }

        /// <summary>
        /// 区域
        /// </summary>
        public enum eAreas
        {
            罗湖 = 1000,
            福田 = 2000,
            南山 = 3000,
            盐田 = 4000,
            宝安 = 5000,
            龙岗 = 6000,
            龙华 = 9000,
            坪山 = 9400,
            光明 = 9200,
            大鹏新区 = 9600
        }

        /// <summary>
        /// 申请状态
        /// </summary>
        public enum eXMZT
        {
            即将申请 = 3,
            正在申请 = 2,
            结束申请 = 4
        }

        //物业类型
        public enum WYLX
        {
            住宅 = 1,
            公寓 = 2,
            豪宅 = 4,
            别墅 = 8,
            商铺 = 16,
            写字楼 = 32,
            商业综合体 = 64,
            厂房 = 128,
            产业园 = 256,
            //复合查询=512（包含住宅、公寓、豪宅、别墅、商业综合体）
            公租房 = 1024,
            安居房 = 2048
        }

        /// <summary>
        /// 问答类别
        /// </summary>
        public enum eQuestiontype
        {
            安居房 = 1,
            公租房 = 2,
            人才房 = 3
        }

        /// <summary>
        /// 轮候库类型
        /// </summary>
        public enum AJHouseType
        {
            首次轮候 = 1,
            日常轮候 = 2
        }

        /// <summary>
        /// 公示类型
        /// </summary>
        public enum eAJHouseType
        {
            初审公示 = 1,
            终审公示 = 2
        }

        /// <summary>
        /// 申请人类别
        /// </summary>
        public enum eCategory
        {
            申请人 = 1,
            共同申请人 = 2,
            非共同申请人 = 3
        }

        /// <summary>
        /// 安居房家庭状况
        /// </summary>
        public enum eFamilyType
        {
            残疾人 = 1,
            抚恤定补 = 2,
            人才 = 3
        }

        /// <summary>
        /// 页面 
        /// </summary>
        public enum ePageType
        {
            首页 = 1,
            安居房 = 2,
            公租房 = 3,
            人才房 = 4,
            轮候排名查询 = 5,
            百问百答 = 6,
            搜索页 = 7
        }

        /// <summary>
        /// 轮候库导航页面
        /// </summary>
        public enum eWaitingNavigation
        {
            安居房轮候 = 1,
            安居房资格 = 2,
            公租房轮候 = 3,
            公租房资格 = 4
        }

        /// <summary>
        /// 轮候库搜索类型
        /// </summary>
        public enum eWaitingSearchType
        {
            智能 = 0,
            回执编号 = 1,
            姓名 = 2,
            身份证 = 3
        }

        /// <summary>
        /// 安居房已选楼盘
        /// </summary>
        public enum eAJFProject
        {
            招商锦绣观园 = 11,
            爱心家园 = 12,
            香林世纪华府 = 13,
            龙悦居四期 = 14,
            茗语华苑 = 15,
            福安雅园 = 16,
            莲馨家园 = 17,
            锦鸿花园 = 18,
            悦澜山花园 = 19,
            富士嘉园 = 20,
            嘉悦山花园 = 21,
            中海锦城花园 = 22,
            和平里花园II期 = 23,
            正大时代华庭 = 24,
            中粮云景花园北区 = 25,
            融悦山居 = 26,
            碧桂园荣汇花园 = 27,
            碧桂园阳光苑 = 28
        }

        /// <summary>
        /// 公租房租房楼盘
        /// </summary>
        public enum eGZFRentProject
        {
            深康村 = 11,
            龙海家园 = 12,
            和悦居 = 13,
            和悦居二期 = 14,
            朗麓家园 = 15,
            龙泽苑 = 16,
            金穗花园 = 17,
            龙瑞佳园 = 18,
            羊台苑一期 = 19,
            华联城市全景花园 = 20,
            澜汇居 = 21,
            壹成中心 = 22,
            深业泰然观澜玫瑰苑 = 23,
            金众金域阁 = 24,
            聚龙花园一期 = 25,
            聚龙花园二期 = 26,
            新城东方丽园 = 27

        }

        /// <summary>
        /// 公租房购房楼盘
        /// </summary>
        public enum eGZFSellProject
        {
            爱心家园 = 51,
            香林世纪华府 = 52,
            龙悦居四期 = 53,
            茗语华苑 = 54,
            福安雅园 = 55
        }

        /// <summary>
        /// 安居房购房资格楼盘
        /// </summary>
        public enum eAJFZGProject
        {
            悦澜山花园 = 1,
            富士嘉园 = 2,
            锦鸿花园 = 3,
            福安雅园 = 4,
            香林世纪华府 = 5,
            爱心家园 = 6,
            茗语华苑 = 7,
            锦绣观园 = 8,
            嘉悦山花园 = 9,
            中海锦城花园 = 10,
            正大时代华庭 = 11,
            中粮云景花园北区 = 12,
            融悦山居 = 13,
            碧桂园荣汇花园 = 14,
            锦鸿花园剩余房源 = 15,
            富士嘉园剩余房源 = 16,
            碧桂园阳光苑 = 17,
            新城东方丽园 = 18,
            智慧领寓 = 19,
            菁英领寓 = 20,
            碧桂园荣汇花园剩余房源 = 21,
            碧桂园阳光苑剩余房源 = 22
        }

        /// <summary>
        /// 公租房租房资格楼盘
        /// </summary>
        public enum eGZFZGProject
        {
            深康村 = 1,
            龙海家园 = 2,
            和悦居 = 3,
            龙华新区公租房 = 4,
            宝安区公租房 = 5,
            朗麓家园 = 6,
            金穗花园龙泽苑 = 7,
            龙瑞佳园 = 8,
            华盛峰荟名庭 = 9,
            保利悦都花园 = 10,
            松岗宏发君域花园 = 11,
            西乡源和苑 = 12,
            松岗联投嘉苑 = 13,
            坪洲新村三期 = 14,
            流塘阳光花园 = 15,
            源和苑剩余房源 = 16,
            大族河山花园 = 17,
            平吉上苑 = 18,
            荷谷美苑 = 19,
            悦龙华府二期 = 20,
            宏发君域剩余房源 = 21,
            羊台苑一期 = 22,
            华联城市全景花园 = 23,
            羊台苑二期 = 24,
            龙华区公租房2017 = 25,
            金众金域阁 = 26,
            聚龙花园一期 = 27,
            聚龙花园二期 = 28,
            新城东方丽园 = 29,
            融悦山居 = 30,
            宝安区公租房2018 = 31
        }

        /// <summary>
        /// 装修
        /// </summary>
        public enum Decoration
        {
            简装 = 1,
            毛坯 = 4
        }

        /// <summary>
        /// 新销售类型
        /// </summary>
        public enum eNewXSZT
        {
            开盘在售 = 1,
            样板间开放 = 2,
            展示中心开放 = 3,
            尾盘 = 4,
            建设中 = 5,
            售罄 = 6
        }

        /// <summary>
        /// 图片类型
        /// </summary>
        /// <remarks></remarks>
        public enum ImageType
        {
            楼书 = 1,
            效果图 = 2,
            样板间 = 3,
            位置配套 = 4,
            实景图 = 5,
            项目现场 = 6,
            全景图 = 7
        }
        /// <summary>
        /// 楼评类型
        /// </summary>
        public enum eComment
        {
            开发商 = 1,
            规划配套 = 2,
            项目解析 = 3,
            图解新盘 = 6
        }

        /// <summary>
        /// 房源户型,用于M版首页
        /// </summary>
        public enum HouseSourceHuxing4list
        {
            一房 = 1,
            二房 = 2,
            三房 = 3,
            四房及以上 = 4
        }

        /// <summary>
        /// 数字枚举
        /// </summary>
        public enum eSumCount
        {
            零 = 0,
            一 = 1,
            二 = 2,
            三 = 3,
            四 = 4,
            五 = 5,
            六 = 6,
            七 = 7,
            八 = 8,
            九 = 9
        }
        /// <summary>
        /// 文章图片类型
        /// </summary>
        public enum eArticleIconsType
        {
            无图 = 0,
            小图 = 1,
            宽图 = 2,
            三图 = 3
        }
    }
}
