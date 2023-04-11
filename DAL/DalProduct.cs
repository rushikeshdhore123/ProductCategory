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
    public class DalProduct
    {
        public void Insert(Product p)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
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

        public void Update(Product p)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("PROC_UpdateProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@a",p.ProductID);
                    cmd.Parameters.AddWithValue("@b", p.ProductName);
                    cmd.Parameters.AddWithValue("@c", p.CategoryID);
                    cmd.ExecuteNonQuery();
                }
                con.Close();

            }
        }
        public void Delete(Product p)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
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
        public DataTable Display()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("Select * from Products ", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }

            }
        }
        public DataTable DisplayProductList()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ToString()))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("Select P.ProductID, P.ProductName, P.CategoryID, C.CategoryName from Products P inner join Category C on P.CategoryID = C.CategoryID; ", con))
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