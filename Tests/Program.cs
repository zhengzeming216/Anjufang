using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using Entity;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //using(MyDbContext db = new MyDbContext())
            // {
            //     for (int i = 0; i < 100; i++)
            //     {
            //         db.Database.ExecuteSqlCommand("INSERT INTO \"Anju_AJFWaitinglist\" ( \"WaterID\", \"BGNo\", \"Name\", \"Category\", \"ParentID\", \"SearchName\", \"SearchIDCardNo\", \"SearchALL\", \"IDCardNo\", \"FamilyCount\", \"Range\", \"FamilyRange\", \"RealTimeRanking\",\"SZSSCCY\",\"XZQ\",\"AREARank\",\"LastRank\",\"LastAREARank\") VALUES(9439811, 'SQR0010405211', '叶丹丹333', 1, 321764, '李勇,韩妍妍,李昱儒', '22010519700416****,22010519821027****,22010520110720****', '李勇,韩妍妍,李昱儒,22010519700416****,22010519821027****,22010520110720****,SQR00121490', '22010519700416****', 1, 94398, 94398, 94398, '五年以上', '福田区', 31348, 123855, 123855)");
            //     }
            //     Console.WriteLine("ok");
            //     Console.ReadKey();
            // }


            Anju_AJFWaitinglistEntity entity = new Anju_AJFWaitinglistEntity();
            entity.WaterID = 11;
            entity.BGNo = "SSSSSEE111";
            entity.Name = "123";
            entity.Category = 2;
            entity.ParentID = 1;
            entity.SearchName = "fffftesttte";
            entity.SearchIDCardNo = "11111";
            entity.SearchFamilyType = "eee";
            entity.SearchALL = "111111111,2222,333";
            entity.IDCardNo = "4045555555";
            entity.FamilyCount = 1;
            entity.Range = 11;
            entity.FamilyRange = 11;
            entity.RealTimeRanking = 11;
            entity.SZRPRTime = DateTime.Now;
            entity.SZSSTime = DateTime.Now;
            entity.RangeType = 1;
            entity.AdultTime = DateTime.Now;
            entity.SZRPRRangeTime = DateTime.Now;
            entity.SZSSRangeTime = DateTime.Now;
            entity.RangeTime = DateTime.Now;
            entity.StrRangeTime = "123";
            entity.SZSSCCY = "11";
            entity.OtherInformation = "2222";
            entity.PermanentAddress = "11111111111";
            entity.Remarks = "11111111111";
            entity.GiveupSelectNum = 11;
            entity.SelectProject = "22";
            entity.AJHouseType = 11;
            entity.operationTime = DateTime.Now;
            entity.GiveupContractNum = 11;
            entity.GiveupContractProject = "1111";
            entity.XZQ = "福田区";
            entity.AREARank = 11;
            entity.LastRank = 11;
            entity.LastAREARank = 11;
            Console.WriteLine(Anju_AJFWaitinglistDAL.Insert(entity));
            Console.ReadKey();

        }
    }
}
