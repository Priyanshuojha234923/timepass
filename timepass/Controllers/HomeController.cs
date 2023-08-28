using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using timepass.Models;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace timepass.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult team()
        {
            return View();
        }
        public ActionResult gallery()
        {
            return View();
        }
        public ActionResult ComputerCenter()
        {
            return View();
        }
        public ActionResult Laboratories()
        {
            return View();
        }
        public ActionResult Library()
        {
            return View();
        }
        public ActionResult Workshop()
        {
            return View();
        }
        public ActionResult Hostel()
        {
            return View();
        }
        public ActionResult stafflist()
        {
            return View();
        }
        public ActionResult principal()
        {
            return View();
        }
        public ActionResult vision()
        {
            return View();
        }
        public ActionResult mission()
        {
            return View();
        }
        public ActionResult fee()
        {
            return View();
        }
        public ActionResult committee()
        {
            return View();
        }
        public ActionResult cse()
        {
            return View();
        }
        public ActionResult civil()
        {
            return View();
        }
        public ActionResult ee()
        {
            return View();
        }
        public ActionResult aicteeoaletters()
        {
            return View();
        }
        public ActionResult coursesoffered()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtname, string txtpass)
        {
            string cmd = "select * from login where userID='" + txtname + "'and password='" + txtpass + "'";
            DBmanager db = new DBmanager();
            DataTable dt = db.GetAllRecords(cmd);
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("/Admin/index");
            }
            else
            {
                Response.Write("<script>alert('Invalid user id and Password')</script>");
            }

            return View();

        }
        public ActionResult contactus()
        {
            return View();
        }
        
   
     [HttpPost]
        public ActionResult contactus(string txtname, string txtemail, string txtmobile, string txtmsg)
        {
            DBmanager db = new DBmanager();
            string cmd = "insert into contactus values(N'" + txtname + "','" + txtemail + "','" + txtmobile + "',N'" + txtmsg + "','" + DateTime.Now.ToString() + "')";
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data save successfully')</script>");
            else
                Response.Write("<script>alert('unable to save data')</script>");
            return View();
        }
     public ActionResult MANDATORYDISCLOSURE()
     {
         return View();
     }
     public ActionResult feedback()
     {
         return View();
     }
     [HttpPost]
     public ActionResult feedback(string sname, string semail, string smobile, string sbranch,string senrollment,string saddress,string sfeedback)
     {
         DBmanager db = new DBmanager();
         string cmd = "insert into feedback values(N'" + sname + "','" + semail + "','" + smobile + "',N'" + sbranch + "','" + senrollment + "',N'" + saddress + "',N'" + sfeedback + "','" + DateTime.Now.ToString() + "')";
         if (db.MyInsertUpdateDelete(cmd))
             Response.Write("<script>alert('Data save successfully')</script>");
         else
             Response.Write("<script>alert('unable to save data')</script>");
         return View();
     }
    }
        
}
