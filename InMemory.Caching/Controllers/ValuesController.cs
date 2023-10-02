using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        //[HttpGet("[Action]/{name}")]
        //public void Set(string name)
        //{
        //    _memoryCache.Set("name", name);
        //}

        //[HttpGet]
        //public string Get()
        //{
        //    if(_memoryCache.TryGetValue<String>("name", out string name))
        //    {
        //        return name.Substring(3);
        //    }
        //    return "";
        //}


        [HttpGet("SetDate")]
        public void SetDate()
        {
             _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
        }

        [HttpGet("GetDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");
        }
    }
}
