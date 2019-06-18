using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SqlHelper
    {
        public static NpgsqlParameter CreateParam(string parameterName, NpgsqlDbType parameterType, int size, ParameterDirection direction, object value)
        {
            NpgsqlParameter param = new NpgsqlParameter()
            {
                ParameterName = parameterName,
                NpgsqlDbType = parameterType,
                Size = size,
                Direction = direction,
                Value = value
            };
            return param;
        }

        public static int PostgresqlExecuteUpdate(string conn, CommandType type, string sqlStr, List<NpgsqlParameter> para)      //用于增删改;
        {
            using (NpgsqlConnection con = new NpgsqlConnection(conn))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlStr;
                NpgsqlParameter[] paras = para.ToArray();
                cmd.Parameters.AddRange(paras);
                int iud = 0;
                iud = cmd.ExecuteNonQuery();
                con.Close();
                return iud;
            }
        }
    }
}
