using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamSports.Models;
using Microsoft.AspNet.Identity;
using TeamSports.ViewModels;

namespace TeamSports.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index(string message)
        {
            var events = db.Events
                .Include(a => a.Level)
                .Include(b => b.Sport)
                .Include(c => c.User);
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.message = message;
            }

            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(Guid id)
        {
            var events = db.Events.Find(id);
            var participants = db.UserEvents.Where(p => p.EventID == id).Select(p => p.User.UserName);

            EventsUserViewModel UsersEvents = new EventsUserViewModel();
            UsersEvents.Event = events;
            UsersEvents.Username = participants.ToList();
            return View(UsersEvents);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.LevelId = new SelectList(db.Levels.OrderBy(i => i.Name), "Id", "Name");
            ViewBag.SportID = new SelectList(db.Sports.OrderBy(i => i.Name), "Id", "name");
            ViewBag.CityID = new SelectList(db.Cities.OrderBy(i => i.Name), "ID", "Name");

            List<City> cities = db.Cities.OrderBy(i => i.Name).ToList();

            ViewBag.CitiesGeo = cities;
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Place,CreatorID,SportID,LevelId,CityID,MaxSlots,AvailableSlots,CurrentSlots,GeoLat,GeoLng,EventDate,EventTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.ID = Guid.NewGuid();
                @event.Owner = User.Identity.GetUserId();
                @event.CurrentSlots = 1;
                @event.AvailableSlots = @event.MaxSlots - 1;

                UserEvent UserEvent = new UserEvent();

                UserEvent.ID = Guid.NewGuid();
                UserEvent.UserID = User.Identity.GetUserId();
                UserEvent.EventID = @event.ID;
                db.Events.Add(@event);
                db.UserEvents.Add(UserEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<City> cities = db.Cities.ToList();

            ViewBag.CitiesGeo = cities;

            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", @event.LevelID);
            ViewBag.SportID = new SelectList(db.Sports, "Id", "name", @event.SportID);
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", @event.CityID);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", @event.LevelID);
            ViewBag.SportID = new SelectList(db.Sports, "Id", "name", @event.SportID);
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", @event.CityID);

            List<City> cities = db.Cities.ToList();

            ViewBag.CitiesGeo = cities;
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Place,Owner,SportID,LevelId,CityID,MaxSlots,AvailableSlots,CurrentSlots,GeoLat,GeoLng")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LevelId = new SelectList(db.Levels, "Id", "Name", @event.LevelID);
            ViewBag.SportID = new SelectList(db.Sports, "Id", "name", @event.SportID);
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", @event.CityID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Join(UserEvent UserEvent, Guid id)
        {
            string CurrentUser = User.Identity.GetUserId();
            int isRegistered = db.UserEvents.Where(r => r.UserID == CurrentUser).Where(r => r.EventID == id).Count();
            int isOwner = db.Events.Where(o => o.Owner == CurrentUser).Where(o => o.ID == id).Count();
            Event Event = db.Events.Find(id);

            if (isRegistered < 1 && isOwner < 1 && Event.AvailableSlots > 0)
            {
                UserEvent.ID = Guid.NewGuid();
                UserEvent.EventID = id;
                UserEvent.UserID = User.Identity.GetUserId();
                db.UserEvents.Add(UserEvent);

                Event.AvailableSlots = Event.AvailableSlots - 1;
                Event.CurrentSlots = Event.CurrentSlots + 1;

                db.SaveChanges();

                return RedirectToAction("Details/" + id);
            }

            return RedirectToAction("Details/" + id);
        }

        public ActionResult Leave(UserEvent UserEvent, Guid id)
        {
            string CurrentUser = User.Identity.GetUserId();
            int isOwner = db.Events.Where(o => o.Owner == CurrentUser).Where(o => o.ID == id).Count();
            int isRegistered = db.UserEvents.Where(r => r.UserID == CurrentUser).Where(r => r.EventID == id).Count();
            UserEvent = db.UserEvents.Where(i => i.EventID == id).Where(u => u.UserID == CurrentUser).First();

            Event Event = db.Events.Find(id);



            if (isRegistered == 1 && isOwner < 1)
            {
                db.UserEvents.Remove(UserEvent);

                Event.AvailableSlots = Event.AvailableSlots + 1;
                Event.CurrentSlots = Event.CurrentSlots - 1;

                db.SaveChanges();
            }

            return RedirectToAction("Details/" + id);
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
