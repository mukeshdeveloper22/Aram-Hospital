using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Aram_Hospital.Extensions;
using Aram_Hospital.Models;

namespace Aram_Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        string constr = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        // GET: Appointment
        public ActionResult Index()
        {
            if ((string)Session["Employee_Username"] == null)
            {
                return RedirectToAction("AdminSignin","Admin");   
            }
            else
            {
                @ViewBag.Loggedinuser = Session["Employee_Username"];
            }
            ViewBag.Loggedinuser = Session["Employee_Username"];
            List<BookAppointment> BookAppointment_obj = new List<BookAppointment>();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_fetch_appointments", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    BookAppointment_obj.Add(new BookAppointment
                    {
                        Id = Convert.ToInt32(sdr[0].ToString()),
                        Name = sdr[1].ToString(),
                        Date = Convert.ToDateTime(sdr[2].ToString()),
                        Mobile_Number = sdr[3].ToString(),
                        Email = sdr[4].ToString(),

                    });
                }
                conn.Close();
                return View(BookAppointment_obj);
            }











            
            
        }

        // GET: Appointment/Details/5
        public ActionResult Logout()
        {
            Session.Remove("Employee_Username");
            return RedirectToAction("AdminSignin","Admin");
            
            return View();
        }
        public ActionResult Details(int id)
        {
            BookAppointment BookAppointment_obj = new BookAppointment();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_fetch_appointment_id " + id, conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    BookAppointment_obj = new BookAppointment
                    {
                        Id = Convert.ToInt32(sdr[0].ToString()),
                        Name = sdr[1].ToString(),
                        Date = Convert.ToDateTime(sdr[2].ToString()),
                        Mobile_Number = sdr[3].ToString(),
                        Email = sdr[4].ToString(),

                    };
                }
                conn.Close();
                return View(BookAppointment_obj);
            }












        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(BookAppointment BookAppointment_obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_insert_apointment" + "'" + BookAppointment_obj.Name + "','" + BookAppointment_obj.Date + "','" + BookAppointment_obj.Mobile_Number + "','" + BookAppointment_obj.Email + "'", conn);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return RedirectToAction("Index");
                }


            }
            catch
            {
                return View();
            }
        }
        public ActionResult Bookappointment1()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Bookappointment1(BookAppointment BookAppointment_obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_insert_apointment" + "'" + BookAppointment_obj.Name + "','" + BookAppointment_obj.Date + "','" + BookAppointment_obj.Mobile_Number + "','" + BookAppointment_obj.Email + "'", conn);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    ViewBag.AlertMessage = "Your Request for Appointment has been received successfully. One of our Patient Management Representatives will contact you shortly.";
                    //TempData["AlertMessage"] = "Your Request for Appointment has been received successfully. One of our Patient Management Representatives will contact you shortly.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }











        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            BookAppointment BookAppointment_obj = new BookAppointment();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_fetch_appointment_id " + id, conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    BookAppointment_obj = new BookAppointment
                    {
                        Id = Convert.ToInt32(sdr[0].ToString()),
                        Name = sdr[1].ToString(),
                        Date = Convert.ToDateTime(sdr[2].ToString()),
                        Mobile_Number = sdr[3].ToString(),
                        Email = sdr[4].ToString(),

                    };
                }
                conn.Close();
                return View(BookAppointment_obj);
            }
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BookAppointment BookAppointment_obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_edit_appointment " + id + ",'" + BookAppointment_obj.Name + "','" + BookAppointment_obj.Date + "','" + BookAppointment_obj.Mobile_Number + "','" + BookAppointment_obj.Email + "'", conn);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return RedirectToAction("Index");
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            BookAppointment BookAppointment_obj = new BookAppointment();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_fetch_appointment_id " + id, conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    BookAppointment_obj = new BookAppointment
                    {
                        Id = Convert.ToInt32(sdr[0].ToString()),
                        Name = sdr[1].ToString(),
                        Date = Convert.ToDateTime(sdr[2].ToString()),
                        Mobile_Number = sdr[3].ToString(),
                        Email = sdr[4].ToString(),

                    };
                }
                conn.Close();
                return View(BookAppointment_obj);
            }
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BookAppointment BookAppointment_obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_delete_appointments " + id, conn);
                    conn.Open ();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    return RedirectToAction("Index");
                }

                    
            }
            catch
            {
                return View();
            }
        }
    }
}
