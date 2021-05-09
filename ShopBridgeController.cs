using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ShopBridge.Models;
using Newtonsoft.Json;


namespace ShopBridge.Controllers
{
    
   
    public class ShopBridgeController : ApiController
    {
        string Constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        // GET api/ShopBridge
        public string Get()
        {
            string result = "";
            DAL objDal = new DAL();

            result=objDal.GetDetails();

            return result;
           
        }

        // GET api/ShopBridge/5
        public string Get(int id)
        {
            string result = "";
            DAL objDal = new DAL();

            result = objDal.GetDetails(id);

            return result;
            //using (SqlConnection con = new SqlConnection(Constr))
            //{
            //    try
            //    {
            //        if (con.State == ConnectionState.Closed)
            //            con.Open();

            //        SqlCommand cmd = new SqlCommand("SP_ShopBridge", con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@Task", "GetById");
            //        cmd.Parameters.AddWithValue("@Id", id);
            //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        sda.Fill(dt);

            //        if (dt.Rows.Count > 0)
            //        {
            //            return JsonConvert.SerializeObject(dt);
            //        }
            //        else
            //        {
            //            return "No data found";
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // show error and store error in DB
            //        if (con.State == ConnectionState.Closed)
            //            con.Open();

            //        SqlCommand cmd1 = new SqlCommand("SP_ErrorLog", con);
            //        cmd1.CommandType = CommandType.StoredProcedure;
            //        cmd1.Parameters.AddWithValue("@Message", ex.Message);
            //        cmd1.Parameters.AddWithValue("@Stacktrace", ex.StackTrace);
            //        cmd1.Parameters.AddWithValue("@Source", ex.Source);
            //        cmd1.Parameters.AddWithValue("@Target", ex.TargetSite);

            //        cmd1.ExecuteNonQuery();

            //        return "Some error occurs while fetching record";
            //    }

            //}
        }

        // POST api/ShopBridge
        public string Post([FromBody] Entity En)
        {

            Validation objvalidation = new Validation();

            string IsValidString = objvalidation.Validate(En);

            if (string.IsNullOrEmpty(IsValidString))
            {
                string result = "";
                DAL objDal = new DAL();

                result = objDal.Post(En);

                return result;

                
            }
            else
            {
                return IsValidString;
            }
        }

        // PUT api/ShopBridge/5
        public string Put(int id, [FromBody] Entity En)
        {
            Validation objvalidation = new Validation();

            string IsValidString = objvalidation.Validate(En);

            if (string.IsNullOrEmpty(IsValidString))
            {
                string result = "";
                DAL objDal = new DAL();

                result = objDal.Put(id,En);

                return result;

                //using (SqlConnection con = new SqlConnection(Constr))
                //{
                //    try
                //    {
                //        if (con.State == ConnectionState.Closed)
                //            con.Open();

                //        SqlCommand cmd = new SqlCommand("SP_ShopBridge", con);
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.AddWithValue("@Task", "Update");
                //        cmd.Parameters.AddWithValue("@Id", id);
                //        cmd.Parameters.AddWithValue("@Name", En.Name);
                //        cmd.Parameters.AddWithValue("@Description", En.Description);
                //        cmd.Parameters.AddWithValue("@Price", En.Price);
                //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //        DataTable dt = new DataTable();
                //        sda.Fill(dt);

                //        if (dt.Rows.Count > 0)
                //        {
                //            if (dt.Rows[0][0].ToString() == "1")
                //                return "Data Updated Successfully";
                //            else
                //                return "Data Not Updated";
                //            //return JsonConvert.SerializeObject(dt);

                //        }
                //        else
                //        {
                //            return "Data Not Updated";
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        // show error and store error in DB
                //        if (con.State == ConnectionState.Closed)
                //            con.Open();

                //        SqlCommand cmd1 = new SqlCommand("SP_ErrorLog", con);
                //        cmd1.CommandType = CommandType.StoredProcedure;
                //        cmd1.Parameters.AddWithValue("@Message", ex.Message);
                //        cmd1.Parameters.AddWithValue("@Stacktrace", ex.StackTrace);
                //        cmd1.Parameters.AddWithValue("@Source", ex.Source);
                //        cmd1.Parameters.AddWithValue("@Target", ex.TargetSite);

                //        cmd1.ExecuteNonQuery();

                //        return "Some error occurs while updating record";
                //    }

                //}
            }
            else
            {
                return IsValidString; 
            }
        }

        // DELETE api/ShopBridge/5
        public string Delete(int id)
        {
            string result = "";
            DAL objDal = new DAL();

            result = objDal.delete(id);

            return result;

            
        }
    }
}
