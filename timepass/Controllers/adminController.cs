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
    public class adminController : Controller
    {
        //
        // GET: /admin/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ulogin()
        {
           
            
            return View();

        }
        [HttpPost]
        public ActionResult ulogin(string UNAME, string OPASS, string NPASS, string CNPASS, string sr)
        {
           
            DBmanager db = new DBmanager();
            string cmd = "update LOGIN set PASSWORD='" + NPASS + "'WHERE USERID='" + UNAME + "'AND PASSWORD='"+OPASS+"'";
            if (NPASS==CNPASS)
            { 
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Update Successfully');window.location.href='/Admin/ULOGIN';</script>");
            else
                Response.Write("<script>alert('Unable to Update');window.location.href='/Admin/ULOGIN';</script>");
            }
            return View();
        }

        public ActionResult uUSER()
        {


            return View();

        }
        [HttpPost]
        public ActionResult uUSER(string OUSER, string PASS, string USER, string CUSER, string sr)
        {

            DBmanager db = new DBmanager();
            string cmd = "update LOGIN set USERID='" + USER + "'WHERE USERID='" + OUSER + "'AND PASSWORD='" + PASS + "'";
            if (USER == CUSER)
            {
                if (db.MyInsertUpdateDelete(cmd))
                    Response.Write("<script>alert('Update Successfully');window.location.href='/Admin/ULOGIN';</script>");
                else
                    Response.Write("<script>alert('Unable to Update');window.location.href='/Admin/ULOGIN';</script>");
            }
            return View();
        }

        public ActionResult gallery()
        {
            return View();
        }
        public ActionResult addgallery()
        {
            return View();
        }
             [HttpPost]
        public ActionResult addgallery(HttpPostedFileBase TXTphoto)
        {
                {
                    string path = Path.Combine(Server.MapPath("~/content/notice/"),TXTphoto.FileName);
                    TXTphoto.SaveAs(path);
                    string cmd = "insert into gallery  values('" + TXTphoto.FileName + "')";
                   
                    DBmanager db = new DBmanager();
                    if (db.MyInsertUpdateDelete(cmd))
                    {
                        Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/gallery';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/gallery';</script>");
                    }
                }
               

            return View();
        }
        
        public ActionResult viewcontact()
        {
            return View();
        }
        public ActionResult logout()
        {
            string id = Session["userID"] + "";
            if (id != null || id != "")
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("/Home/Index");
            }
            else
            {
                Response.Redirect("/Home/login");
            }
            return View();
        }
        public ActionResult DeleteContact(string del)
        {
            string cmd = "delete from contactus where nom='" + del + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/viewcontact';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/viewcontact';</script>");

            return View();
        }
        public ActionResult DeleteGALLERY(string del)
        {
            string cmd = "delete from GALLERY where NUMBER='" + del + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/GALLERY';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/GALLERY';</script>");

            return View();
        }



        public ActionResult viewnotice()
        {
            return View();

        }
     
        public ActionResult Deletenotice(string del)
        {
            string cmd = "delete from NOTICE where NN='" + del + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/viewnotice';</script>");
                
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/viewnotice';</script>");

            return View();
        }

        public ActionResult ADDNOTICE()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addnotice(string txtname1, HttpPostedFileBase TXTMSG1)
        {
                {
                    string path = Path.Combine(Server.MapPath("~/content/notice/"),TXTMSG1.FileName);
                    TXTMSG1.SaveAs(path);
                    string cmd = "insert into Notice  values(N'" + txtname1 + "',N'" + TXTMSG1.FileName + "','" + DateTime.Now.ToString() + "')";
                   
                    DBmanager db = new DBmanager();
                    if (db.MyInsertUpdateDelete(cmd))
                    {
                        Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/viewnotice';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/viewnotice';</script>");
                    }
                }
               

            return View();
        }
        public ActionResult Alogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult alogin(string login, string password)
        {
            {
                
                string cmd = "insert into login  values(N'" + login + "','" + password+ "')";

                DBmanager db = new DBmanager();
                if (db.MyInsertUpdateDelete(cmd))
                {
                    Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/viewlogin';</script>");
                }
                else
                {
                    Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/viewlogin';</script>");
                }
            }


            return View();
        }

        public ActionResult stafflistedit()
        {
            return View();

        }


        public ActionResult coursesofferededit()
        {
            return View();

        }
        public ActionResult viewlogin()
        {
            return View();

        }
        public ActionResult academiccalenderedit()
        {
            return View();

        }
        public ActionResult facaultyedit()
        {
            return View();

        }
        public ActionResult ADDSTAFF()
        {
            return View();

        }
        [HttpPost]
        public ActionResult ADDSTAFF(string NAME, string DESIGNATION, string QUALIFICATION,string EMAIL)
        {
            {

                string cmd = "insert into STAFFlist values('" + NAME + "','" + DESIGNATION + "','" + QUALIFICATION + "','" + EMAIL + "')";

                DBmanager db = new DBmanager();
                if (db.MyInsertUpdateDelete(cmd))
                {
                    Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/stafflistedit';</script>");
                }
                else
                {
                    Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/stafflistedit';</script>");
                }
            }


            return View();
        }
        public ActionResult DeletSTAFF(string delstaff)
        {
            string cmd = "delete from stafflist where sr='" + delstaff + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/stafflistedit';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/stafflistedit';</script>");

            return View();
        }
        public ActionResult Deletelogin(string del)
        {
            string cmd = "delete from login where sr='" + del + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/viewlogin';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/viewlogin';</script>");

            return View();
        }

        public ActionResult updatestaff(string edit)
        {
            string cmd = "select * from stafflist where sr='" + edit + "'";

            DBmanager db = new DBmanager();
            DataTable dt = db.GetAllRecords(cmd);
            if (dt.Rows.Count > 0)
            {
                ViewBag.SR = dt.Rows[0]["sr"];
                ViewBag.NAME = dt.Rows[0]["name"];
                ViewBag.DESIGNATION = dt.Rows[0]["designation"];
                ViewBag.QUALIFICATION = dt.Rows[0]["qualification"];
                ViewBag.EMAIL = dt.Rows[0]["email"];


            }
            return View();

        }
        [HttpPost]
        public ActionResult updatestaff(string NAME, string DESIGNATION, string QUALIFICATION , string EMAIL,string sr)
        {
            DBmanager db = new DBmanager();
            string cmd = "update STAFFLIST set NAME='" + NAME + "',DESIGNATION='" + DESIGNATION + "',QUALIFICATION='" + QUALIFICATION + "',EMAIL='" + EMAIL+ "'WHERE sr='"+ sr + "'";
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Update Successfully');window.location.href='/Admin/stafflistedit';</script>");
            else
                Response.Write("<script>alert('Unable to Update');window.location.href='/Admin/stafflistedit';</script>");
            return View();
        }

        public ActionResult addcourses()
        {
            return View();

        }
        [HttpPost]
        public ActionResult addcourses(string NAME, string course, string QUALIFICATION, string duration)
        {
            {

                string cmd = "insert into course values('" + NAME + "','" + course + "','" + QUALIFICATION + "','" + duration + "')";

                DBmanager db = new DBmanager();
                if (db.MyInsertUpdateDelete(cmd))
                {
                    Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/coursesofferededit';</script>");
                }
                else
                {
                    Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/coursesofferededit';</script>");
                }
            }


            return View();
        }
        public ActionResult Deletcourses(string delcourses)
        {
            string cmd = "delete from course where name='" + delcourses + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/coursesofferededit';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/coursesofferededit';</script>");

            return View();
        }
        public ActionResult addantiraging()
        {
            return View();

        }
        [HttpPost]
        public ActionResult addantiraging(string NAME)
        {
            {

                string cmd = "insert into antiraggin values('" + NAME + "')";

                DBmanager db = new DBmanager();
                if (db.MyInsertUpdateDelete(cmd))
                {
                    Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/facaultyedit';</script>");
                }
                else
                {
                    Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/facaultyedit';</script>");
                }
            }


            return View();
        }   
        public ActionResult Delantiranging(string delanti)
        {
            string cmd = "delete from antiraggin where name='" + delanti + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/facaultyedit';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/facaultyedit';</script>");

            return View();
        }
        public ActionResult addwoman()
        {
            return View();

        }
        [HttpPost]
        public ActionResult addwoman(string NAME)
        {
            {

                string cmd = "insert into womanharassment values('" + NAME + "')";

                DBmanager db = new DBmanager();
                if (db.MyInsertUpdateDelete(cmd))
                {
                    Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/facaultyedit';</script>");
                }
                else
                {
                    Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/facaultyedit';</script>");
                }
            }


            return View();
        }
        public ActionResult Delwoman(string delwoman)
        {
            string cmd = "delete from womanharassment where name='" + delwoman + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/facaultyedit';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/facaultyedit';</script>");

            return View();
        }
        public ActionResult addscst()
        {
            return View();

        }
        [HttpPost]
        public ActionResult addscst(string NAME)
        {
            {

                string cmd = "insert into scst values('" + NAME + "')";

                DBmanager db = new DBmanager();
                if (db.MyInsertUpdateDelete(cmd))
                {
                    Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/facaultyedit';</script>");
                }
                else
                {
                    Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/facaultyedit';</script>");
                }
            }


            return View();
        }
        public ActionResult delscst(string delscst)
        {
            string cmd = "delete from scst where name='" + delscst + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/facaultyedit';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/facaultyedit';</script>");

            return View();
        }
        public ActionResult MANDATORYDISCLOSUREEDIT()
        {
            return View();

        }

        public ActionResult DelMANDATORYDISCLOSUREEDIT(string del)
        {
            string cmd = "delete from AICTELETTER where NAME='" + del + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/MANDATORYDISCLOSUREEDIT';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/MANDATORYDISCLOSUREEDIT';</script>");

            return View();
        }

        public ActionResult ADDMANDATORYDISCLOSUREEDIT()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addMANDATORYDISCLOSUREEDIT(string txtname1, HttpPostedFileBase TXTMSG1,string YEAR)
        {
            {
                string path = Path.Combine(Server.MapPath("~/content/notice/"), TXTMSG1.FileName);
                TXTMSG1.SaveAs(path);
                string cmd = "insert into AICTELETTER(name,year,letter) values('" + txtname1 + "','" + YEAR + "','" + TXTMSG1.FileName + "')";

                DBmanager db = new DBmanager();
                if (db.MyInsertUpdateDelete(cmd))
                {
                    Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/MANDATORYDISCLOSUREEDIT';</script>");
                }
                else
                {
                    Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/MANDATORYDISCLOSUREEDIT';</script>");
                }
            }


            return View();
        }

        public ActionResult viewFEEDBACK()
        {
            return View();

        }

        public ActionResult Deletefeedback(string del)
        {
            string cmd = "delete from feedback where cid='" + del + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/viewfeedback';</script>");
            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/viewfeedback';</script>");

            return View();
        }
        public ActionResult viewfee()
        {
            return View();

        }

        public ActionResult Delfee(string del)
        {
            string cmd = "delete from fee where sr='" + del + "'";
            DBmanager db = new DBmanager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Data Delete Successfully');window.location.href='/Admin/viewfee';</script>");

            else

                Response.Write("<script>alert('Unable to delete');window.location.href='/Admin/viewfee';</script>");

            return View();
        }

        public ActionResult ADDfee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addfee(string year,string fee)
        {
            {
                
                string cmd = "insert into fee  values('" + year + "',N'" + fee + "')";

                DBmanager db = new DBmanager();
                if (db.MyInsertUpdateDelete(cmd))
                {
                    Response.Write("<script>alert('your details succesfully saved.');window.location.href='/Admin/viewfee';</script>");
                }
                else
                {
                    Response.Write("<script>alert('unable to save details.');window.location.href='/Admin/viewfee';</script>");
                }
            }


            return View();
        }


    }
}
