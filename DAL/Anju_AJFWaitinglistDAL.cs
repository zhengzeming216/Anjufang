using Common;
using Entity;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Anju_AJFWaitinglistDAL
    {
        #region ConstVariables
        private const string C_TABLE_NAME = "Anju_AJFWaitinglist";
        private const string C_SP_ANJU_AJFWAITINGLIST_FIELDS = "[Id],[WaterID],[BGNo],[Name],[Category],[ParentID],[SearchName],[SearchIDCardNo],[SearchFamilyType],[SearchALL],[IDCardNo],[FamilyCount],[Range],[FamilyRange],[RealTimeRanking],[SZRPRTime],[SZSSTime],[RangeType],[AdultTime],[SZRPRRangeTime],[SZSSRangeTime],[RangeTime],[StrRangeTime],[SZSSCCY],[OtherInformation],[PermanentAddress],[Remarks],[GiveupSelectNum],[SelectProject],[AJHouseType],[operationTime],[GiveupContractNum],[GiveupContractProject],[XZQ],[AREARank],[LastRank],[LastAREARank]";
        private const string C_SP_ANJU_AJFWAITINGLIST_INSERT = "INSERT INTO \"Anju_AJFWaitinglist\"(\"WaterID\",\"BGNo\",\"Name\",\"Category\",\"ParentID\",\"SearchName\",\"SearchIDCardNo\",\"SearchFamilyType\",\"SearchALL\",\"IDCardNo\",\"FamilyCount\",\"Range\",\"FamilyRange\",\"RealTimeRanking\",\"SZRPRTime\",\"SZSSTime\",\"RangeType\",\"AdultTime\",\"SZRPRRangeTime\",\"SZSSRangeTime\",\"RangeTime\",\"StrRangeTime\",\"SZSSCCY\",\"OtherInformation\",\"PermanentAddress\",\"Remarks\",\"GiveupSelectNum\",\"SelectProject\",\"AJHouseType\",\"operationTime\",\"GiveupContractNum\",\"GiveupContractProject\",\"XZQ\",\"AREARank\",\"LastRank\",\"LastAREARank\") VALUES(@WaterID,@BGNo,@Name,@Category,@ParentID,@SearchName,@SearchIDCardNo,@SearchFamilyType,@SearchALL,@IDCardNo,@FamilyCount,@Range,@FamilyRange,@RealTimeRanking,@SZRPRTime,@SZSSTime,@RangeType,@AdultTime,@SZRPRRangeTime,@SZSSRangeTime,@RangeTime,@StrRangeTime,@SZSSCCY,@OtherInformation,@PermanentAddress,@Remarks,@GiveupSelectNum,@SelectProject,@AJHouseType,@operationTime,@GiveupContractNum,@GiveupContractProject,@XZQ,@AREARank,@LastRank,@LastAREARank);";
        private const string C_SP_ANJU_AJFWAITINGLIST_UPDATE = "UPDATE [Anju_AJFWaitinglist] SET [Id]=@Id,[WaterID]=@WaterID,[BGNo]=@BGNo,[Name]=@Name,[Category]=@Category,[ParentID]=@ParentID,[SearchName]=@SearchName,[SearchIDCardNo]=@SearchIDCardNo,[SearchFamilyType]=@SearchFamilyType,[SearchALL]=@SearchALL,[IDCardNo]=@IDCardNo,[FamilyCount]=@FamilyCount,[Range]=@Range,[FamilyRange]=@FamilyRange,[RealTimeRanking]=@RealTimeRanking,[SZRPRTime]=@SZRPRTime,[SZSSTime]=@SZSSTime,[RangeType]=@RangeType,[AdultTime]=@AdultTime,[SZRPRRangeTime]=@SZRPRRangeTime,[SZSSRangeTime]=@SZSSRangeTime,[RangeTime]=@RangeTime,[StrRangeTime]=@StrRangeTime,[SZSSCCY]=@SZSSCCY,[OtherInformation]=@OtherInformation,[PermanentAddress]=@PermanentAddress,[Remarks]=@Remarks,[GiveupSelectNum]=@GiveupSelectNum,[SelectProject]=@SelectProject,[AJHouseType]=@AJHouseType,[operationTime]=@operationTime,[GiveupContractNum]=@GiveupContractNum,[GiveupContractProject]=@GiveupContractProject,[XZQ]=@XZQ,[AREARank]=@AREARank,[LastRank]=@LastRank,[LastAREARank]=@LastAREARank WHERE [Id] = @Id";
        private const string C_SP_ANJU_AJFWAITINGLIST_DELETE = "DELETE [Anju_AJFWaitinglist] WHERE [Id] = @Id";
        private const string C_SP_ANJU_AJFWAITINGLIST_GET = "SELECT [Id],[WaterID],[BGNo],[Name],[Category],[ParentID],[SearchName],[SearchIDCardNo],[SearchFamilyType],[SearchALL],[IDCardNo],[FamilyCount],[Range],[FamilyRange],[RealTimeRanking],[SZRPRTime],[SZSSTime],[RangeType],[AdultTime],[SZRPRRangeTime],[SZSSRangeTime],[RangeTime],[StrRangeTime],[SZSSCCY],[OtherInformation],[PermanentAddress],[Remarks],[GiveupSelectNum],[SelectProject],[AJHouseType],[operationTime],[GiveupContractNum],[GiveupContractProject],[XZQ],[AREARank],[LastRank],[LastAREARank] FROM [Anju_AJFWaitinglist] WHERE [Id] = @Id";
        #endregion

        private static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            }
        }

        public static DbRawSqlQuery<Anju_AJFWaitinglistEntity> GetAll()
        {
            //MyDbContext db = new MyDbContext();
            //return db.AjFWaitinglist;
            MyDbContext db = new MyDbContext();
            var result = db.Database.SqlQuery<Anju_AJFWaitinglistEntity>("select * from \"Anju_AJFWaitinglist\"");
            return result;
        }

        /// <summary>
        /// 获取数据库一条记录实体，根据主键
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Anju_AJFWaitinglistEntity GetById(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                //var entity = db.AjFWaitinglist.Where(e => e.Id == id).SingleOrDefault();
                var entity = db.Database.SqlQuery<Anju_AJFWaitinglistEntity>("select * from \"Anju_AJFWaitinglist\" where \"Id\"=" + id).First();
                if (entity == null)
                    return null;
                return entity;
            }
        }

        /// <summary>
        /// 获取数据库一条记录实体(根据备案回执号)
        /// </summary>
        /// <param name="BGNo"></param>
        /// <returns></returns>
        public static Anju_AJFWaitinglistEntity GetByBGNo(string BGNo)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var entity = db.AjFWaitinglist.Where(e => e.BGNo == BGNo).SingleOrDefault();
                if (entity == null)
                    return null;
                return entity;
            }
        }

        public static int SearchCount(string whereClause)
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Database.SqlQuery<int>("select count(1) from \"Anju_AJFWaitinglist\" where " + whereClause).First();
            }
        }

        public static List<Anju_AJFWaitinglistEntity> Search(string whereClause, string orderby, int skip, int pageSize)
        {
            using (MyDbContext db = new MyDbContext())
            {
                return db.Database.SqlQuery<Anju_AJFWaitinglistEntity>("select * from \"Anju_AJFWaitinglist\" where " + whereClause + " order by " + orderby + " limit " + pageSize + " offset " + skip).ToList();
            }
        }

        public static void test()
        {

        }


        /// <summary>
        /// 向数据表中插入一条新记录
        /// </summary>
        /// <param name="entity">Entity.Anju_AJFWaitinglistEntity实体类</param>
        /// <remarks>如果表存在自增长字段，插入记录成功后自增长字段值会更新至实体</remarks>
        public static int Insert(Anju_AJFWaitinglistEntity entity)
        {
            List<NpgsqlParameter> commandParms = new List<NpgsqlParameter>();
            commandParms.Add(SqlHelper.CreateParam("@WaterID", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.WaterID));
            commandParms.Add(SqlHelper.CreateParam("@BGNo", NpgsqlDbType.Varchar, 15, ParameterDirection.Input, entity.BGNo));
            commandParms.Add(SqlHelper.CreateParam("@Name", NpgsqlDbType.Varchar, 20, ParameterDirection.Input, entity.Name));
            commandParms.Add(SqlHelper.CreateParam("@Category", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.Category));
            commandParms.Add(SqlHelper.CreateParam("@ParentID", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.ParentID));
            commandParms.Add(SqlHelper.CreateParam("@SearchName", NpgsqlDbType.Varchar, 100, ParameterDirection.Input, entity.SearchName));
            commandParms.Add(SqlHelper.CreateParam("@SearchIDCardNo", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.SearchIDCardNo));
            commandParms.Add(SqlHelper.CreateParam("@SearchFamilyType", NpgsqlDbType.Varchar, 30, ParameterDirection.Input, entity.SearchFamilyType));
            commandParms.Add(SqlHelper.CreateParam("@SearchALL", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.SearchALL));
            commandParms.Add(SqlHelper.CreateParam("@IDCardNo", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.IDCardNo));
            commandParms.Add(SqlHelper.CreateParam("@FamilyCount", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.FamilyCount));
            commandParms.Add(SqlHelper.CreateParam("@Range", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.Range));
            commandParms.Add(SqlHelper.CreateParam("@FamilyRange", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.FamilyRange));
            commandParms.Add(SqlHelper.CreateParam("@RealTimeRanking", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.RealTimeRanking));
            commandParms.Add(SqlHelper.CreateParam("@SZRPRTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.SZRPRTime));
            commandParms.Add(SqlHelper.CreateParam("@SZSSTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.SZSSTime));
            commandParms.Add(SqlHelper.CreateParam("@RangeType", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.RangeType));
            commandParms.Add(SqlHelper.CreateParam("@AdultTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.AdultTime));
            commandParms.Add(SqlHelper.CreateParam("@SZRPRRangeTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.SZRPRRangeTime));
            commandParms.Add(SqlHelper.CreateParam("@SZSSRangeTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.SZSSRangeTime));
            commandParms.Add(SqlHelper.CreateParam("@RangeTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.RangeTime));
            commandParms.Add(SqlHelper.CreateParam("@StrRangeTime", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.StrRangeTime));
            commandParms.Add(SqlHelper.CreateParam("@SZSSCCY", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.SZSSCCY));
            commandParms.Add(SqlHelper.CreateParam("@OtherInformation", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.OtherInformation));
            commandParms.Add(SqlHelper.CreateParam("@PermanentAddress", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.PermanentAddress));
            commandParms.Add(SqlHelper.CreateParam("@Remarks", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.Remarks));
            commandParms.Add(SqlHelper.CreateParam("@GiveupSelectNum", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.GiveupSelectNum));
            commandParms.Add(SqlHelper.CreateParam("@SelectProject", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.SelectProject));
            commandParms.Add(SqlHelper.CreateParam("@AJHouseType", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.AJHouseType));
            commandParms.Add(SqlHelper.CreateParam("@operationTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.operationTime));
            commandParms.Add(SqlHelper.CreateParam("@GiveupContractNum", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.GiveupContractNum));
            commandParms.Add(SqlHelper.CreateParam("@GiveupContractProject", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.GiveupContractProject));
            commandParms.Add(SqlHelper.CreateParam("@XZQ", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.XZQ));
            commandParms.Add(SqlHelper.CreateParam("@AREARank", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.AREARank));
            commandParms.Add(SqlHelper.CreateParam("@LastRank", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.LastRank));
            commandParms.Add(SqlHelper.CreateParam("@LastAREARank", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.LastAREARank));

            return SqlHelper.PostgresqlExecuteUpdate(ConnectionString, CommandType.Text, C_SP_ANJU_AJFWAITINGLIST_INSERT, commandParms);
        }

    }
}
//NpgsqlParameter[] commandParms = new NpgsqlParameter[]
//            {
//                //SqlHelper.CreateParam("@Id", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.Id),
//                SqlHelper.CreateParam("@WaterID", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.WaterID),
//                SqlHelper.CreateParam("@BGNo", NpgsqlDbType.Varchar, 15, ParameterDirection.Input, entity.BGNo),
//                SqlHelper.CreateParam("@Name", NpgsqlDbType.Varchar, 20, ParameterDirection.Input, entity.Name),
//                SqlHelper.CreateParam("@Category", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.Category),
//                SqlHelper.CreateParam("@ParentID", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.ParentID),
//                SqlHelper.CreateParam("@SearchName", NpgsqlDbType.Varchar, 100, ParameterDirection.Input, entity.SearchName),
//                SqlHelper.CreateParam("@SearchIDCardNo", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.SearchIDCardNo),
//                SqlHelper.CreateParam("@SearchFamilyType", NpgsqlDbType.Varchar, 30, ParameterDirection.Input, entity.SearchFamilyType),
//                SqlHelper.CreateParam("@SearchALL", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.SearchALL),
//                SqlHelper.CreateParam("@IDCardNo", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.IDCardNo),
//                SqlHelper.CreateParam("@FamilyCount", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.FamilyCount),
//                SqlHelper.CreateParam("@Range", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.Range),
//                SqlHelper.CreateParam("@FamilyRange", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.FamilyRange),
//                SqlHelper.CreateParam("@RealTimeRanking", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.RealTimeRanking),
//                SqlHelper.CreateParam("@SZRPRTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.SZRPRTime),
//                SqlHelper.CreateParam("@SZSSTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.SZSSTime),
//                SqlHelper.CreateParam("@RangeType", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.RangeType),
//                SqlHelper.CreateParam("@AdultTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.AdultTime),
//                SqlHelper.CreateParam("@SZRPRRangeTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.SZRPRRangeTime),
//                SqlHelper.CreateParam("@SZSSRangeTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.SZSSRangeTime),
//                SqlHelper.CreateParam("@RangeTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.RangeTime),
//                SqlHelper.CreateParam("@StrRangeTime", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.StrRangeTime),
//                SqlHelper.CreateParam("@SZSSCCY", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.SZSSCCY),
//                SqlHelper.CreateParam("@OtherInformation", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.OtherInformation),
//                SqlHelper.CreateParam("@PermanentAddress", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.PermanentAddress),
//                SqlHelper.CreateParam("@Remarks", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.Remarks),
//                SqlHelper.CreateParam("@GiveupSelectNum", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.GiveupSelectNum),
//                SqlHelper.CreateParam("@SelectProject", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.SelectProject),
//                SqlHelper.CreateParam("@AJHouseType", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.AJHouseType),
//                SqlHelper.CreateParam("@operationTime", NpgsqlDbType.Timestamp, 6, ParameterDirection.Input, entity.operationTime),
//                SqlHelper.CreateParam("@GiveupContractNum", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.GiveupContractNum),
//                SqlHelper.CreateParam("@GiveupContractProject", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.GiveupContractProject),
//                SqlHelper.CreateParam("@XZQ", NpgsqlDbType.Varchar, 255, ParameterDirection.Input, entity.XZQ),
//                SqlHelper.CreateParam("@AREARank", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.AREARank),
//                SqlHelper.CreateParam("@LastRank", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.LastRank),
//                SqlHelper.CreateParam("@LastAREARank", NpgsqlDbType.Integer, 32, ParameterDirection.Input, entity.LastAREARank),
//           };