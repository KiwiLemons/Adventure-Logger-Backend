using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureLoggerBackend.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        // GET: routes
        public ActionResult Index()
        {
            return Content("Home");
        }

        // GET: routes/Details/5
        [Route("details")]
        public ActionResult Details(int id)
        {
            return Content($"id is {id}");
        }

        // GET: routes/Create
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: routes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: routes/Edit/5
        [Route("edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: routes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: routes/Delete/5
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: routes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
