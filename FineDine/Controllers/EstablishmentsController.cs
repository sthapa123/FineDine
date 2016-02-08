﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FineDine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FineDine.Controllers
{
    public class EstablishmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        
        // GET: Establishments
        public ActionResult Index()
        {            
            return View(db.Establishments.ToList());
        }

        // GET: Establishments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            return View(establishment);
        }

        // GET: Establishments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Establishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,WorkingHours,MainRating,Description,PhoneNumber,Owner")] Establishment establishment, string Tags)
        {
            if (ModelState.IsValid)
            {
                
                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var currentUser = manager.FindById(User.Identity.GetUserId());

                //while (var tag in establishment.Tags)
                //{ }


                establishment.Owner = currentUser;
                Tags = " " + Tags;
                string[] parsedTags = Tags.Split(new char[] { ' ', '#' });
                //string[] parsedTags = Tags.Split(" #",0);
                establishment.Tags = new List<Tag>();   
                var tagsList = db.Tags.ToList();

                foreach (var enteredTag in parsedTags)
                {
                    if (enteredTag != " " && enteredTag != "")
                    {
                        var newTag = new Tag() { Name = enteredTag };
                        Tag databaseTag = newTag;
                        bool flag = true;
                        foreach (var tag in tagsList)
                        {
                            if (enteredTag == tag.Name)
                            {
                                databaseTag = tag;
                                flag = false;
                                break;
                            }
                        }

                        if (flag)
                            db.Tags.Add(databaseTag);

                        establishment.Tags.Add(databaseTag);
                    }
                }

                

                db.Establishments.Add(establishment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(establishment);
        }

        // GET: Establishments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            return View(establishment);
        }

        // POST: Establishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,WorkingHours,MainRating,Description,PhoneNumber")] Establishment establishment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establishment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(establishment);
        }

        // GET: Establishments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            return View(establishment);
        }

        // POST: Establishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Establishment establishment = db.Establishments.Find(id);
            db.Establishments.Remove(establishment);
            db.SaveChanges();
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
