using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace mvc100923.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-AO7U188\\SQLEXPRESS; initial catalog=db100923;integrated security=true");
        public ActionResult EmployeeForm()
        {
            return View();
        }
        public void EmployeeInsert(string A, long B, int C)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employeeInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", A);
            cmd.Parameters.AddWithValue("@mobile", B);
            cmd.Parameters.AddWithValue("@age", C);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public JsonResult EmployeeDisplay()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employeeSelect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            con.Close();
            string data=JsonConvert.SerializeObject(dt);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
          
    }
}