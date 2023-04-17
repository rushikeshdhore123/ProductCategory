using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Master_With_CURD_Operations.Models;

namespace Master_With_CURD_Operations.Models
{
    //Create Database MachineTest 
    //Create Table Category with 2 columns CategoryID and CategoryName
    public class DalCategory
    {

        string conString = ConfigurationManager.ConnectionStrings["abc"].ToString();
        public void Insert(Category c)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                //Create Stored Procedure to Insert or Add records
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

        //Create Strored Procedure To Update records
        public void Update(Category c)
        {
            using (SqlConnection con = new SqlConnection(conString))
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
        //Create Strored Procedure To Delete records
        public void Delete(Category c)
        {
            using (SqlConnection con = new SqlConnection(conString))
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

        //Count total records available in Category Table
        public int CountTotalRecords()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Category", con);
                int totalRecords = (int)cmd.ExecuteScalar();
                con.Close();
                return totalRecords;
            }
        }
        //Display records in paging
        public DataTable Display(int page)
        {
            int pageSize = 5;
            int offset = ((page - 1) * pageSize);
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Category order by CategoryID offset @offset rows fetch next @pagesize rows only", con);
                cmd.Parameters.AddWithValue("@offset", offset);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

    }
}

                