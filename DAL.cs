using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ShopBridge.Models;
using Newtonsoft.Json;

namespace ShopBridge.Models
{
    public class DAL
    {

        string Constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        public string GetDetails()
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)//Check for connection status
                        con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ShopBridge", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Task", "Get");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return JsonConvert.SerializeObject(dt);
                    }
                    else
                    {
                        return "No data found";
                    }
                }
                catch (Exception ex)
                {
                    //// show error and store error in DB
                    //if (con.State == ConnectionState.Closed)
                    //    con.Open();

                    //SqlCommand cmd1 = new SqlCommand("SP_ErrorLog", con);
                    //cmd1.CommandType = CommandType.StoredProcedure;
                    //cmd1.Parameters.AddWithValue("@Message", ex.Message);
                    //cmd1.Parameters.AddWithValue("@Stacktrace", ex.StackTrace);
                    //cmd1.Parameters.AddWithValue("@Source", ex.Source);
                    //cmd1.Parameters.AddWithValue("@Target", ex.TargetSite);

                    //cmd1.ExecuteNonQuery();

                    ErrorLog(ex);//Store exception or error details

                    return "Some error occurs while fetching record";
                }
            }
        }

        public string GetDetails(int id)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ShopBridge", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Task", "GetById");
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return JsonConvert.SerializeObject(dt);
                    }
                    else
                    {
                        return "No data found";
                    }
                }
                catch (Exception ex)
                {
                    //// show error and store error in DB
                    //if (con.State == ConnectionState.Closed)
                    //    con.Open();

                    //SqlCommand cmd1 = new SqlCommand("SP_ErrorLog", con);
                    //cmd1.CommandType = CommandType.StoredProcedure;
                    //cmd1.Parameters.AddWithValue("@Message", ex.Message);
                    //cmd1.Parameters.AddWithValue("@Stacktrace", ex.StackTrace);
                    //cmd1.Parameters.AddWithValue("@Source", ex.Source);
                    //cmd1.Parameters.AddWithValue("@Target", ex.TargetSite);

                    //cmd1.ExecuteNonQuery();

                    ErrorLog(ex);//Store error details

                    return "Some error occurs while fetching record";
                }

            }
        }

        public string Post(Entity En)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ShopBridge", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Task", "Insert");
                    cmd.Parameters.AddWithValue("@Name", En.Name);
                    cmd.Parameters.AddWithValue("@Description", En.Description);
                    cmd.Parameters.AddWithValue("@Price", En.Price);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                            return "Data Inserted Successfully";
                        else if (dt.Rows[0][0].ToString() == "0")
                            return "Data Not Inserted due to some error";
                        else
                            return "Duplicate records can not be allow to insert";
                        
                        //return JsonConvert.SerializeObject(dt);

                    }
                    else
                    {
                        return "Data Not Inserted";
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog(ex);// store error details

                    return "Some error occurs while Inserting record";
                }

            }
        }

        public string Put(int id, Entity En)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ShopBridge", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Task", "Update");
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", En.Name);
                    cmd.Parameters.AddWithValue("@Description", En.Description);
                    cmd.Parameters.AddWithValue("@Price", En.Price);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                            return "Data Updated Successfully";
                        else if (dt.Rows[0][0].ToString() == "0")
                            return "Data Not Updated";
                        else 
                            return "Record is not available for update";
                        //return JsonConvert.SerializeObject(dt);

                    }
                    else
                    {
                        return "Data Not Updated";
                    }
                }
                catch (Exception ex)
                {
                    //// show error and store error in DB

                    ErrorLog(ex);//store error details

                    return "Some error occurs while updating record";
                }

            }
        }

        public string delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlCommand cmd = new SqlCommand("SP_ShopBridge", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Task", "Delete");
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                            return "Data Deletd Successfully";
                        else if (dt.Rows[0][0].ToString() == "0")
                            return "Data Not Deleted";
                        else 
                            return "Record is not available for delete";
                        //return JsonConvert.SerializeObject(dt);

                    }
                    else
                    {
                        return "Data Not Deleted";
                    }
                }
                catch (Exception ex)
                {
                    //// show error and store error in DB

                    ErrorLog(ex);//store error details

                    return "Some error occurs while deleting record";
                }

            }
        }

        public void ErrorLog(Exception ex)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd1 = new SqlCommand("SP_ErrorLog", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Message", ex.Message);
                cmd1.Parameters.AddWithValue("@Stacktrace", ex.StackTrace);
                cmd1.Parameters.AddWithValue("@Source", ex.Source);
                cmd1.Parameters.AddWithValue("@Target", ex.TargetSite);

                cmd1.ExecuteNonQuery();
            }
        }

    }
}