using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Core2Base.Models;

namespace Core2Base.Data
{
    public class SearchData : Data
    {
        public static List<Product> GetSearchInfo(string searchtext)
        {

        List<Product> searches = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();


                //string sql = @"Select * FROM Product where Name like" + searchtext;

                /*
                string sql = @"SELECT ProductID,ProductName,ProductDesc,ProductCat,Price,ProductImg,Group_ConCat(ProductTag.Tags) as ""tags"" 
                                FROM[Product] 
                                OuterJoin Product.ProductId = ProductTag.ProductId";
                */

                string sql = @" SELECT * 
                                FROM Product 
                                Where concat(ProductName,ProductDesc)
                                LIKE '% "+ searchtext +" %'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        Id = Convert.ToString(reader["ProductId"]),
                        Name = (string)reader["ProductName"],
                        Description = (string)reader["ProductDesc"],
                        Category = (string)reader["ProductCat"],
                        UnitPrice = (double)reader["Price"],
                        Image = (string)reader["ProductImg"],
                    };
                    searches.Add(product);
                }
                return searches;
            }
        }
    }
}