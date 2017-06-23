using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication3.Models
{
    public class CustomerService
    {
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
        }
        /// <summary>
        /// 依照customerId取得客戶資料(首頁顯示全部資料用)
        /// </summary>
        /// <returns></returns>
        public List<Models.Customer> GetCustomerById(string customerId)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT CustomerID,CompanyName,ContactName,ContactTitle			
					from Sales.Customers					
					Where  (CustomerID=@CustomerID OR @CustomerID='')";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId == null ? string.Empty : customerId));

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapOrderDataToList(dt);
        }
        /// <summary>
        /// 依照條件取得客戶資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Customer> GetOrderByCondtioin(Models.CustomerSearchArg arg)
        {

            DataTable dt = new DataTable();
            string sql = @"SELECT CustomerID,CompanyName,ContactName,ContactTitle			
					from Sales.Customers				
					Where (CustomerID=@CustomerID or @CustomerID='') AND (CompanyName Like @CompanyName Or @CompanyName='') and (ContactName = @ContactName Or @ContactName='') and (ContactTitle = @ContactTitle Or @ContactTitle=''))";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", arg.CustomerID == null ? string.Empty : '%' + arg.CustomerID + '%'));
                cmd.Parameters.Add(new SqlParameter("@CompanyName", arg.CompanyName == null ? string.Empty : arg.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@ContactName", arg.ContactName == null ? string.Empty : arg.ContactName));
                cmd.Parameters.Add(new SqlParameter("@ContactTitle", arg.ContactTitle == null ? string.Empty : arg.ContactTitle));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }


            return this.MapOrderDataToList(dt);
        }
        /// <summary>
        /// 依照id刪除訂單
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int DeleteOrderCustomerById(string customerId)
        {
            try
            {
                string sql = "Delete FROM Sales.Customers Where CustomerID=@CustomerID";
                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }               
                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<Models.Customer> MapOrderDataToList(DataTable dt)
        {
            List<Models.Customer> result = new List<Customer>();


            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Customer()
                {
                    CustomerID = (int)row["CustomerID"],
                    CompanyName = row["CompanyName"].ToString(),
                    ContactName = row["ContactName"].ToString(),
                    ContactTitle = row["ContactTitle"].ToString()

                }
                );
            }
            return result;
        }
    }
}