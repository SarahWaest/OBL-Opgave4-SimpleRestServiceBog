using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opgave1Unit_tests;

namespace SimpleRestServiceBog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BogController : ControllerBase
    {
        private static readonly List<Bog> Books = new List<Bog>()
        {
            new Bog(){Forfatter = "Akira Himekawa", Isbn13 = "DetteErEnISBN", Sidetal = 200, Titel = "The Legend of Zelda"},
            new Bog(){Forfatter = "Akira Himekawa", Isbn13 = "DetteErISBNEN", Sidetal = 250, Titel = "The Legend of Zelda: Ocarina of Time"},
            new Bog(){Forfatter = "Akira Himekawa", Isbn13 = "DetteErISBN11", Sidetal = 400, Titel = "The Legend of Zelda: Breath of the Wild"},
            new Bog(){Forfatter = "Akira Himekawa", Isbn13 = "DetteErISBN12", Sidetal = 700, Titel = "The Legend of Zelda: Twilight princess"},
            new Bog(){Forfatter = "Akira Himekawa", Isbn13 = "DetteErISBN13", Sidetal = 900, Titel = "The Legend of Zelda: The Master Trials"}
        };

        // GET: api/Bog
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return Books;
        }

        // GET: api/Bog/5
        [HttpGet("{isbn13}", Name = "Get")]
        public Bog Get(string isbn13)
        {
            return Books.Find(i => i.Isbn13 == isbn13);
        }

        // POST: api/Bog
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            Books.Add(value);
        }

        // PUT: api/Bog/5
        [HttpPut("{isbn13}")]
        public void Put (string isbn13, [FromBody] Bog value)
        {
            Bog bog = Get(isbn13);
            if (bog != null)
            {
                bog.Isbn13 = value.Isbn13;
                bog.Forfatter = value.Forfatter;
                bog.Sidetal = value.Sidetal;
                bog.Titel = value.Titel;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Bog bog = Get(isbn13);
            Books.Remove(bog);
        }
    }
}
