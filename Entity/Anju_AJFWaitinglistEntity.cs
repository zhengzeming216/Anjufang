using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Anju_AJFWaitinglistEntity
    {
        public int Id { get; set; }
        public int WaterID { get; set; }
        public string BGNo { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int ParentID { get; set; }
        public string SearchName { get; set; }
        public string SearchIDCardNo { get; set; }
        public string SearchFamilyType { get; set; }
        public string SearchALL { get; set; }
        public string IDCardNo { get; set; }
        public int FamilyCount { get; set; }
        public int Range { get; set; }
        public int FamilyRange { get; set; }
        public int RealTimeRanking { get; set; }
        public DateTime? SZRPRTime { get; set; }
        public DateTime? SZSSTime { get; set; }
        public int RangeType { get; set; }
        public DateTime? AdultTime { get; set; }
        public DateTime? SZRPRRangeTime { get; set; }
        public DateTime? SZSSRangeTime { get; set; }
        public DateTime? RangeTime { get; set; }
        public string StrRangeTime { get; set; }
        public string SZSSCCY { get; set; }
        public string OtherInformation { get; set; }
        public string PermanentAddress { get; set; }
        public string Remarks { get; set; }
        public int GiveupSelectNum { get; set; }
        public string SelectProject { get; set; }
        public int AJHouseType { get; set; }
        public DateTime? operationTime { get; set; }
        public int GiveupContractNum { get; set; }
        public string GiveupContractProject { get; set; }
        public string XZQ { get; set; }
        public int? AREARank { get; set; }
        public int? LastRank { get; set; }
        public int? LastAREARank { get; set; }
    }
}
