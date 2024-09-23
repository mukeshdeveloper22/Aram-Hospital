using Aram_Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Aram_Hospital.Controllers
{
    public class AdminController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult AdminSignin()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult AdminSignin(AdminLogin AdminLogin_obj)
        {
            


                try
                {
                    using (SqlConnection conn = new SqlConnection(constr))
                    {
                        string Employee_Username = "";
                        SqlCommand cmd = new SqlCommand("sp_adminlogin" + "'" + AdminLogin_obj.Employee_Username + "','" + AdminLogin_obj.Password + "'", conn);
                        conn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            Employee_Username = sdr[0].ToString();
                            Session["Employee_Username"] = Employee_Username;
                        }
                        conn.Close();

                        if (Employee_Username != "")
                        {
                            
                            return RedirectToAction("Index", "Appointment");
                        }
                        else
                        {
                            
                            return RedirectToAction("signin", "Appointment");

                        }
                        //return View();
                    }
                }
                catch
                {
                    return View();
                }

            
            
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
