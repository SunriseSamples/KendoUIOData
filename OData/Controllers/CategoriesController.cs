using OData.Models;
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
using System.Web.OData.Routing;

namespace OData.Controllers
{
    [EnableCors(origins: "http://localhost:9161", headers: "*", methods: "*")]
    [ODataRoutePrefix("Categories")]
    public class CategoriesController : ODataController
    {
        ProductsContext db = new ProductsContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private bool Exists(int key)
        {
            return db.Categories.Any(c => c.ID == key);
        }

        private async Task<IHttpActionResult> TrySave(int key, Category entity)
        {
            try
            {
                await db.SaveChangesAsync();
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
            return Ok(entity);
        }

        // GET odata/Categories
        [EnableQuery(PageSize = 10)]
        public IHttpActionResult Get()
        {
            return Ok(db.Categories.AsQueryable());
        }

        // GET odata/Categories(5)
        [ODataRoute("({key})")]
        [EnableQuery]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var entity = await db.Categories.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST odata/Categories
        public async Task<IHttpActionResult> Post(Category create)
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
        [ODataRoute("({key})")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Category> patch)
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
            return await TrySave(key, entity);
        }

        // PUT odata/Categories(5)
        [ODataRoute("({key})")]
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Category update)
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
            return await TrySave(key, update);
        }

        // DELETE odata/Categories(5)
        [ODataRoute("({key})")]
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
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
