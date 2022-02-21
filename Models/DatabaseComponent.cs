using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Bootique.Models
{
    public class DatabaseComponent : Controller
    {
        public class DatabaseConnection
        {
            static string CONNECTIONSTRING = @"Data Source=RILPT188;Initial Catalog=shop;User ID=sa;Password=sa123";

            public List<shop> GetAllshop()
            {
                var list = new List<shop>();
                using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
                {
                    try
                    {
                        var query = "SELECT * FROM bootique";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var shop = new shop();
                            shop.shopIdID = Convert.ToInt32(reader[0]);
                            shop.shopName = reader[1].ToString();
                            shop.shopAddress = reader[2].ToString();

                            list.Add(shop);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                    return list;
                }
            }

            public void AddNewshop(shop shop)
            {
                using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
                {
                    var query = "INSERT INTO bootique VALUES(@shopId,@shopName,@shopAddress)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", shop.shopIdID);
                    cmd.Parameters.AddWithValue("@name", shop.shopName);
                    cmd.Parameters.AddWithValue("@actor", shop.shopAddress);

                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new Exception("Details not added!");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            public shop Findshop(int id)
            {
                shop shop = new shop();
                using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
                {
                    try
                    {
                        con.Open();
                        var query = "SELECT * FROM bootique WHERE shopId =  " + id;
                        SqlCommand cmd = new SqlCommand(query, con);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            shop.shopIdID = Convert.ToInt32(reader[0]);
                            shop.shopName = reader[1].ToString();
                            shop.shopAddress = reader[2].ToString();

                        }
                        else
                            throw new Exception("shop not found!");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                    return shop;
                }
            }
            public void Updateshop(shop shop)
            {
                using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
                {
                    var query = $"UPDATE bootique set shopName = '{shop.shopName  }', Id = '{shop.shopIdID}', Address = '{shop.shopAddress}'" +
                        $"" +
                        $" WHERE shopId = {shop.shopIdID}";
                    SqlCommand cmd = new SqlCommand(query, con);
                    try
                    {
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            throw new Exception("No Details were updated");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            public void Deleteshop(int id)
            {
                shop shop = new shop();
                using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
                {
                    try
                    {
                        con.Open();
                        var cmd = con.CreateCommand();
                        cmd.CommandText = "DELETE FROM bootique WHERE shopId = " + id;
                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows == 0)
                            throw new Exception("Cannot Delete shop");
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }


        }

        internal void Deleteshop(int shopId)
        {
            throw new NotImplementedException();
        }

        internal void Updateshop(shop shop)
        {
            throw new NotImplementedException();
        }

        internal object Findshop(int shopId)
        {
            throw new NotImplementedException();
        }

        internal object GetAllshop()
        {
            throw new NotImplementedException();
        }

        internal void AddNewshop(shop shop)
        {
            throw new NotImplementedException();
        }
    }
}

