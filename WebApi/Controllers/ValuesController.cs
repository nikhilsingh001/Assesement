using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;
namespace WebApi.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        public List<City> GetCity()
        {
            List<City> cityData = new List<City>();
            DataTable dt = new DataTable();

            try
            {
                SqlConnection conn = new SqlConnection("data source=LAPTOP-0J6EU6I9\\SQLEXPRESS;database=practices;user id=sa;password=Pass@123;");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select *from City";
                cmd.Connection = conn;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow item in dt.Rows)
                    {

                        cityData.Add(new City() { cityID = Convert.ToInt32(item["CityID"]), Cityname = Convert.ToString(item["CITY_Name"]), StateID = Convert.ToInt32(item["StateID"]) });
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return cityData;

        }


        [HttpGet]
        public List<State> GetState(int StateID)
        {
            List<State> StateData = new List<State>();
            DataTable dt = new DataTable();

            try
            {
                SqlConnection conn = new SqlConnection("data source=LAPTOP-0J6EU6I9\\SQLEXPRESS;database=practices;user id=sa;password=Pass@123;");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@id", StateID);
                cmd.CommandText = "select *from State where StateID=@id";
                cmd.Connection = conn;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow item in dt.Rows)
                    {
                        StateData.Add(new State() { StateID = Convert.ToInt32(item["StateID"]), StateName = Convert.ToString(item["State_Name"]) });
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return StateData;

        }
        [HttpGet]
        public List<Product> GetProduct()
        {
            List<Product> ProductData = new List<Product>();
            DataTable dt = new DataTable();

            try
            {
                SqlConnection conn = new SqlConnection("data source=LAPTOP-0J6EU6I9\\SQLEXPRESS;database=practices;user id=sa;password=Pass@123;");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select *from Product";
                cmd.Connection = conn;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow item in dt.Rows)
                    {
                        ProductData.Add(new Product() { productid = Convert.ToInt32(item["ProductID"]), ProductName = Convert.ToString(item["Product_Name"]) });
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return ProductData;

        }
        [HttpGet]
        public int GetPincode(int cityid) {
            int pincode = 0;
            try
            {
                SqlConnection conn = new SqlConnection("data source=LAPTOP-0J6EU6I9\\SQLEXPRESS;database=practices;user id=sa;password=Pass@123;");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@id", cityid);
                cmd.CommandText = "select Pincode from Pincode where CItyid=@id";
                cmd.Connection = conn;

                return pincode = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                
            }

            return pincode;

        }
        [HttpPost]
        public string AddCustomer(customer cus)
        {
            string message = string.Empty;

            try
            {
                SqlConnection conn = new SqlConnection("data source=LAPTOP-0J6EU6I9\\SQLEXPRESS;database=practices;user id=sa;password=Pass@123;");
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in cus.ProductId)
                {
                    cmd.Parameters.Add("@CustomerName", cus.Name);
                    cmd.Parameters.Add("@ProductID",item);
                    cmd.Parameters.Add("@Address", cus.Address);
                    cmd.Parameters.Add("@CityID", cus.City);
                    cmd.Parameters.Add("@StateID", cus.State);
                    cmd.Parameters.Add("@Pincode", cus.Pincode);
                    cmd.Parameters.Add("@DOB", cus.DOB);
                    cmd.CommandText = "sp_AddCustomer";
                    cmd.Connection = conn;
                    if (cmd.ExecuteScalar().ToString().Equals("Customer succfully inserted in database"))
                    {

                         message = "Customer succfully inserted in database";
                        cmd.Parameters.Clear();
                        ;
                    }
                    else if (cmd.ExecuteScalar().ToString().Equals("Data is already Present in database"))
                    {
                        return message = "Data is already Present in database";
                    }
                    else
                    {

                        return message = "some error has been occured";
                    }


                }



            }
            catch (Exception ex)
            {
                return message = "some error has been occured";

            }
            return message;
        }

    }
}
