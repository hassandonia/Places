using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Places.Backend.Models;
using Places.Domain;
using Places.Backend.Helpers;
using System;

namespace Places.Backend.Controllers
{
    
    public class PlacesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Places
        public async Task<ActionResult> Index()
        {
            var places = db.Places.Include(p => p.Category);
            return View(await places.ToListAsync());
        }

        // GET: Places/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var place = await db.Places.FindAsync(id);

            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlaceView view)
        {
            if (ModelState.IsValid)
            {
                
                var pic = string.Empty;
                var folder = "~/Content/Images";

                if(view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }
                var place = ToPlace(view);

                place.Image = pic;

                db.Places.Add(place);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", view.CategoryId);
            return View(view);
        }

        private Place ToPlace(PlaceView view)
        {
            return new Place {
                Category = view.Category,
                CategoryId = view.CategoryId,
                Description = view.Description,
                Image = view.Image,
                IsActive = view.IsActive,
                LastPurchase = view.LastPurchase,
                Price = view.Price,
                PlaceId = view.PlaceId,
                Remarks = view.Remarks,
                Stock = view.Stock,
            };
        }

        // GET: Places/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var place = await db.Places.FindAsync(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", place.CategoryId);

            var view = ToView(place);
            return View(view);
        }

        private PlaceView ToView(Place place)
        {
            return new PlaceView {
                Category = place.Category,
                CategoryId = place.CategoryId,
                Description = place.Description,
                Image = place.Image,
                IsActive = place.IsActive,
                LastPurchase = place.LastPurchase,
                Price = place.Price,
                PlaceId = place.PlaceId,
                Remarks = place.Remarks,
                Stock = place.Stock,
            };

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PlaceView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.Image;
                var folder = "~/Content/Images";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var place = ToPlace(view);
                place.Image = pic;
                db.Entry(place).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", view.CategoryId);
            return View(view);
        }

        // GET: Places/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = await db.Places.FindAsync(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Place place = await db.Places.FindAsync(id);
            db.Places.Remove(place);
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
