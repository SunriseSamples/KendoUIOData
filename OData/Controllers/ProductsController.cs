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
using System.Web.OData.Routing;

namespace OData.Controllers
{
    [EnableCors(origins: "http://localhost:9161", headers: "*", methods: "*")]
    [ODataRoutePrefix("Products")]
    public class ProductsController : ODataController
    {
        ProductsContext db = new ProductsContext();

        private bool Exists(Guid key)
        {
            return db.Products.Any(p => p.ID == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // GET odata/Products
        [EnableQuery(PageSize = 10)]
        public IHttpActionResult Get()
        {
            return Ok(db.Products.AsQueryable());
        }

        // GET odata/Products(5)
        [ODataRoute("({key})")]
        [EnableQuery]
        public async Task<IHttpActionResult> Get([FromODataUri] Guid key)
        {
            var entity = await db.Products.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST odata/Products
        public async Task<IHttpActionResult> Post(Product create)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Products.Add(create);
            await db.SaveChangesAsync();
            return Created(create);
        }

        // PATCH odata/Products(5)
        [ODataRoute("({key})")]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<Product> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Products.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            patch.Patch(entity);
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

        // PUT odata/Products(5)
        [ODataRoute("({key})")]
        public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Product update)
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
            return Ok(update);
        }

        // DELETE odata/Products(5)
        [ODataRoute("({key})")]
        public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
        {
            var entity = await db.Products.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            db.Products.Remove(entity);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
