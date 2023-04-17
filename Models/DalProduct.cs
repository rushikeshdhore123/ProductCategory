using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Master_With_CURD_Operations.Models
{
    public class DalProduct
    {
        //Create table with name Products 
        string conString = ConfigurationManager.ConnectionStrings["abc"].ToString();
        
        //create stored procedure to add records
        public void Insert(Product p)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("PROC_AddProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", p.ProductID);
                    cmd.Parameters.AddWithValue("@b", p.ProductName);
                    cmd.Parameters.AddWithValue("@c", p.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                con.Close();

            }
        }
        //Create Strored Procedure To Update records

        public void Update(Product p)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("PROC_UpdateProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", p.ProductID);
                    cmd.Parameters.AddWithValue("@b", p.ProductName);
                    cmd.Parameters.AddWithValue("@c", p.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                con.Close();

            }
        }

        //Create Strored Procedure To Delete records
        public void Delete(Product p)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("PROC_DeleteProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a", p.ProductID);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        
        public DataTable Display(int page)
        {
            int pageSize = 5;
            int offset = (page - 1) * pageSize;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Products order by ProductID offset @offset rows fetch next @pageSize rows only", con);
                cmd.Parameters.AddWithValue("@offset", offset);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public int CountTotalRecords()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Products", con);
                int totalRecords = (int)cmd.ExecuteScalar();
                con.Close();
                return totalRecords;
            }
        }
        //Display records in paging format
        public DataTable DisplayProductList(int page)
        {
            int pageSize = 5;
            int offset = (page - 1) * pageSize;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select P.ProductID, P.ProductName, P.CategoryID, C.CategoryName from Products P inner join Category C on P.CategoryID = C.CategoryID order by ProductID Offset @offset rows Fetch Next @pageSize rows only ", con);
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