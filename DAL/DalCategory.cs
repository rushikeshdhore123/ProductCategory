using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Master_With_CURD_Operations.Models;


namespace Master_With_CURD_Operations.DAL
{
    public class DalCategory
    {
        public void Insert(Category c)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("PROC_AddCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", c.CategoryID);
                    cmd.Parameters.AddWithValue("@b", c.CategoryName);
                    cmd.ExecuteNonQuery();
                }
                con.Close();

            }
        }

        public void Update(Category c)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("PROC_UpdateCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", c.CategoryID);
                    cmd.Parameters.AddWithValue("@b", c.CategoryName);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                
            }
        }
        public void Delete(Category c)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("PROC_DeleteCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", c.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                
            }
        }
        public DataTable Display()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("Select * from Category", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }

            }
        }
    }
}