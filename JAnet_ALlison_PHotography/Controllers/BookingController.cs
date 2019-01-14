using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JAnet_ALlison_PHotography.Models;
using Microsoft.AspNet.Identity;

namespace JAnet_ALlison_PHotography.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Booking
        public async Task<ActionResult> Index()
        {
            return View(await db.Bookings.ToListAsync());
        }

        // GET: Booking/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            List<SelectListItem> timeSlot = new List<SelectListItem>(); // list for time slot

            timeSlot.Add(new SelectListItem() { Value = "8", Text = "8 AM" });
            timeSlot.Add(new SelectListItem() { Value = "9", Text = "9 AM" });
            timeSlot.Add(new SelectListItem() { Value = "10", Text = "10 AM" });
            timeSlot.Add(new SelectListItem() { Value = "11", Text = "11 AM" });
            timeSlot.Add(new SelectListItem() { Value = "1", Text = "1 PM" });
            timeSlot.Add(new SelectListItem() { Value = "2", Text = "2 PM" });
            timeSlot.Add(new SelectListItem() { Value = "3", Text = "3 PM" });
            timeSlot.Add(new SelectListItem() { Value = "4", Text = "4 PM" });
            ViewBag.timeSlot = timeSlot;

            List<SelectListItem> list = new List<SelectListItem>(); // greate a list to populate with employee user

            var usersWithRoles = (from user in db.Users
                                  from userRole in user.Roles
                                  join role in db.Roles on userRole.RoleId equals
                                  role.Id
                                  select new { user.Id, user.FirstName, user.LastName, role.Name }).ToList();
            foreach (var item in usersWithRoles)
            {
                if (item.Name.Equals("Employee"))
                {
                    list.Add(new SelectListItem() { Value = item.Id, Text = item.FirstName + " " + item.LastName });
                }
            }


            ViewBag.Employee = list;

            //List<SelectListItem> userNamelist = new List<SelectListItem>();
            //var currentUser = System.Web.HttpContext.Current.User.Identity.GetUserName();
            //timeSlot.Add(new SelectListItem() { Value = currentUser, Text = currentUser});
            //ViewBag.UserName = userNamelist;

            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "booking_Id,customer_Id,UserName,dateTime,TimeSlot,PhotoDetail")] Booking booking)
        {
            List<SelectListItem> timeSlot = new List<SelectListItem>(); // list for time slot

            timeSlot.Add(new SelectListItem() { Value = "8", Text = "8 AM" });
            timeSlot.Add(new SelectListItem() { Value = "9", Text = "9 AM" });
            timeSlot.Add(new SelectListItem() { Value = "10", Text = "10 AM" });
            timeSlot.Add(new SelectListItem() { Value = "11", Text = "11 AM" });
            timeSlot.Add(new SelectListItem() { Value = "1", Text = "1 PM" });
            timeSlot.Add(new SelectListItem() { Value = "2", Text = "2 PM" });
            timeSlot.Add(new SelectListItem() { Value = "3", Text = "3 PM" });
            timeSlot.Add(new SelectListItem() { Value = "4", Text = "4 PM" });
            ViewBag.timeSlot = timeSlot;

            List<SelectListItem> list = new List<SelectListItem>(); // greate a list to populate with employee user

            var usersWithRoles = (from user in db.Users
                                  from userRole in user.Roles
                                  join role in db.Roles on userRole.RoleId equals
                                  role.Id
                                  select new { user.Id, user.FirstName, user.LastName, role.Name }).ToList();
            foreach (var item in usersWithRoles)
            {
                if (item.Name.Equals("Employee"))
                {
                    list.Add(new SelectListItem() { Value = item.Id, Text = item.FirstName + " " + item.LastName });
                }
            }
            ViewBag.Employee = list;

            //List<SelectListItem> userNamelist = new List<SelectListItem>();
            //var currentUser = System.Web.HttpContext.Current.User.Identity.GetUserName();
            //timeSlot.Add(new SelectListItem()
            //{
            //    Value = currentUser,
            //    Text = currentUser
            //});
            //ViewBag.UserName = userNamelist;
            if (ModelState.IsValid)
            {
               
                db.Bookings.Add(booking);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Booking/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            List<SelectListItem> timeSlot = new List<SelectListItem>(); // list for time slot

            timeSlot.Add(new SelectListItem() { Value = "8", Text = "8 AM" });
            timeSlot.Add(new SelectListItem() { Value = "9", Text = "9 AM" });
            timeSlot.Add(new SelectListItem() { Value = "10", Text = "10 AM" });
            timeSlot.Add(new SelectListItem() { Value = "11", Text = "11 AM" });
            timeSlot.Add(new SelectListItem() { Value = "1", Text = "1 PM" });
            timeSlot.Add(new SelectListItem() { Value = "2", Text = "2 PM" });
            timeSlot.Add(new SelectListItem() { Value = "3", Text = "3 PM" });
            timeSlot.Add(new SelectListItem() { Value = "4", Text = "4 PM" });
            ViewBag.timeSlot = timeSlot;

            List<SelectListItem> list = new List<SelectListItem>(); // greate a list to populate with employee user

            var usersWithRoles = (from user in db.Users
                                  from userRole in user.Roles
                                  join role in db.Roles on userRole.RoleId equals
                                  role.Id
                                  select new { user.Id, user.FirstName, user.LastName, role.Name }).ToList();
            foreach (var item in usersWithRoles)
            {
                if (item.Name.Equals("Employee"))
                {
                    list.Add(new SelectListItem() { Value = item.Id, Text = item.FirstName + " " + item.LastName });
                }
            }


            ViewBag.Employee = list;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "booking_Id,customer_Id,UserName,dateTime,TimeSlot,PhotoDetail")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Booking/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Booking booking = await db.Bookings.FindAsync(id);
            db.Bookings.Remove(booking);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
