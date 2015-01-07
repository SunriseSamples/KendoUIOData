using OData.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
// OData v3
//using System.Web.Http.OData;
// OData v4
using System.Web.OData;

namespace OData.Controllers
{
    [EnableCors(origins: "http://localhost:9161", headers: "*", methods: "*")]
    public class CategoriesController : ODataController
    {
        ProductsContext db = new ProductsContext();

        private bool Exists(int key)
        {
            return db.Categories.Any(c => c.ID == key);
        }

        private IHttpActionResult Try(int key, Action run, Func<IHttpActionResult> result)
        {
            try
            {
                run();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return result();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // GET odata/Categories
        [EnableQuery]
        public IQueryable<Category> Get()
        {
            return db.Categories;
        }

        // GET odata/Categories(5)
        [EnableQuery]
        public SingleResult<Category> Get([FromODataUri] int key)
        {
            var result = db.Categories.Where(c => c.ID == key);
            return SingleResult.Create(result);
        }

        // POST odata/Categories
        public IHttpActionResult Post(Category create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Categories.Add(create);
            db.SaveChanges();
            return Created(create);
        }

        // POST odata/Categories
        public async Task<IHttpActionResult> PostAsync(Category create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Categories.Add(create);
            await db.SaveChangesAsync();
            return Created(create);
        }

        // PATCH odata/Categories(5)
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Category> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = db.Categories.Find(key);
            if (entity == null)
            {
                return NotFound();
            }
            patch.Patch(entity);
            return Try(key, () => db.SaveChanges(), () => Updated(entity));
        }

        // PATCH odata/Categories(5)
        public async Task<IHttpActionResult> PatchAsync([FromODataUri] int key, Delta<Category> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Categories.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            patch.Patch(entity);
            return Try(key, async () => await db.SaveChangesAsync(), () => Updated(entity));
        }

        // PUT odata/Categories(5)
        public IHttpActionResult Put([FromODataUri] int key, Category update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.ID)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            return Try(key, () => db.SaveChanges(), () => Updated(update));
        }

        // PUT odata/Categories(5)
        public async Task<IHttpActionResult> PutAsync([FromODataUri] int key, Category update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.ID)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            return Try(key, async () => await db.SaveChangesAsync(), () => Updated(update));
        }

        // DELETE odata/Categories(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var entity = db.Categories.Find(key);
            if (entity == null)
            {
                return NotFound();
            }
            db.Categories.Remove(entity);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE odata/Categories(5)
        public async Task<IHttpActionResult> DeleteAsync([FromODataUri] int key)
        {
            var entity = await db.Categories.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            db.Categories.Remove(entity);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
