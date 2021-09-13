using Chicken.Entities;
using Chicken.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Chicken.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemRepository repo;

        public ItemController()
        {
            repo = new ItemRepository();
        }

        [HttpGet]
        public ItemDTO GetItems()
        {
            var item = repo.GetResult();
            return item;
        }

    }
}
