using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.DB;
using System.Data.SqlClient;

namespace WebApplication1.DB
{
    public class Database
    {
        string connectString = Database_connecting.connectString;
        public List<EMP> EMP_List()
        {
            

            List<EMP> DBase = new List<EMP>();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Employee", conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EMP teach = new EMP();
                        if (reader["id"] != DBNull.Value)
                        {
                            teach.id = Convert.ToInt16(reader["id"]);
                        }
                        if (reader["E_name"] != DBNull.Value)
                        {
                            teach.E_name = Convert.ToString(reader["E_name"]);
                        }
                        if (reader["E_age"] != DBNull.Value)
                        {
                            teach.E_age = Convert.ToInt16(reader["E_age"]);
                        }

                        if (reader["E_Email"] != DBNull.Value)
                        {
                            teach.E_Email = reader["E_Email"].ToString();
                        }
                        DBase.Add(teach);

                    }
                }
            }
            return DBase;
        }


        public void InsertEMP(EMP e)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand("insert into Employee values(@E_name,@E_age,@E_Email)", conn))
                {

                    conn.Open();

                    cmd.Parameters.AddWithValue("@E_name", e.E_name);
                    cmd.Parameters.AddWithValue("@E_age", e.E_age);
                    cmd.Parameters.AddWithValue("@E_Email", e.E_Email);
                    cmd.ExecuteNonQuery();
                }
            }

        }


        public void DeleteEMP(int id)
        {

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand("delete from Employee where id = @id", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateEMP(EMP e)
        {

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand("update Employee set E_name= @E_name , E_age = @E_age, E_Email = @E_Email where id = @id", conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@id", e.id);
                    cmd.Parameters.AddWithValue("@E_name", e.E_name);
                    cmd.Parameters.AddWithValue("@E_age", e.E_age);
                    cmd.Parameters.AddWithValue("@E_Email", e.E_Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public EMP get_data(int id)
        {
            EMP employee = new EMP();

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Employee where id = @id", conn))
                {

                    conn.Open();

                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    if (reader["id"] != DBNull.Value)
                    {
                        employee.id = Convert.ToInt32(reader["id"]);
                    }

                    if (reader["E_name"] != DBNull.Value)
                    {
                        employee.E_name = Convert.ToString(reader["E_name"]);
                    }
                    if (reader["E_Email"] != DBNull.Value)
                    {
                        employee.E_Email = Convert.ToString(reader["E_Email"]);
                    }
                    if (reader["E_age"] != DBNull.Value)
                    {
                        employee.E_age = Convert.ToInt32(reader["E_age"]);
                    }

                }
            }
            return employee;
        }
    }
}