﻿using Garden.DAL.Core;
using Garden.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL
{
    public class GardenDAL
    {

        private static GardenEntity ToModel(DataRow row)
        {
            GardenEntity garden = new();
            garden.GardenId = row["garden_id"].ToString();
            garden.OwnerId = row["owner_id"].ToString();
            garden.Pictures = row["pictures"].ToString();
            garden.CreateTime = Convert.ToDateTime(row["create_time"]);
            garden.Description = row["description"].ToString();
            garden.Position = row["position"].ToString();
            garden.Stars = Convert.ToInt32(row["stars"]);
            garden.Status = Convert.ToInt32(row["status"]);

            return garden;
        }

        private static List<GardenEntity> ToModelList(DataTable dt)
        {
            List<GardenEntity> G = new();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                GardenEntity garden = ToModel(dr);
                G.Add(garden);
            }
            return G;
        }


        public GardenEntity GetGardenById(string garden_id, out int status)
        {

            try
            {
                string sql = "SELECT * FROM garden WHERE garden_id=:id";
<<<<<<< HEAD
                DataTable dt = OracleHelper.ExecuteTable(sql,
                    new OracleParameter("id", OracleDbType.Char) { Value = id });
=======
                DataTable dt = OracleHelper.ExecuteTable(sql, 
                    new OracleParameter("id", OracleDbType.Char) { Value = garden_id });
>>>>>>> f33fe834c1bbbd939f68b35c9e89abaac44e8d53
                if (dt.Rows.Count != 1)
                {
                    status = 2;
                    return null;
                }
                status = 0;
                DataRow dr = dt.Rows[0];
                return ToModel(dr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 1;
                return null;
            }
        }

        public bool Insert(GardenEntity garden)
        {
            try
            {
                string sql = "INSERT INTO garden(garden_id, owner_id, pictures, create_time, description, position, stars, status) VALUES(garden_seq.NEXTVAL, :garden_id, :owner_id, :pictures, :create_time, :description, :position, :stars, :status)";
                OracleParameter[] oracleParameters = new OracleParameter[]
                {
                    new OracleParameter("garden_id", OracleDbType.Char) { Value = garden.GardenId },
                    new OracleParameter("owner_id", OracleDbType.Char) { Value = garden.OwnerId },
                    new OracleParameter("pictures", OracleDbType.Varchar2) { Value = garden.Pictures },
                    new OracleParameter("create_time", OracleDbType.Date) { Value = garden.CreateTime},
                    new OracleParameter("description", OracleDbType.Clob) { Value = garden.Description },
<<<<<<< HEAD
                    new OracleParameter("position", OracleDbType.Varchar20) { Value =  garden.Position },
=======
                    new OracleParameter("position", OracleDbType.Varchar2) { Value =  garden.Position },
>>>>>>> f33fe834c1bbbd939f68b35c9e89abaac44e8d53
                    new OracleParameter("stars", OracleDbType.Int32) { Value = garden.Stars },
                    new OracleParameter("status", OracleDbType.Int32) { Value = garden.Status }
                };
                OracleHelper.ExecuteNonQuery(sql, oracleParameters);
                OracleHelper.ExecuteNonQuery("commit;");
                return true;
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("ORA-02185"))
                {
                    return true;
                }
                return false;
            }
        }
    }

}
