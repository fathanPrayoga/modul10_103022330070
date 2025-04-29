using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using modul10_103022330070.Model;

namespace modul10_103022330070.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movieList = new List<Movie>
        {
            new Movie{title = "shawswhank redemption", director = "Frank ocean", stars=new List<string>{"paul allen", "pau cubarsi", "raphinha" },
               description="A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion" },
             new Movie{title = "Dune", director = "Dennis Vilenuve", stars=new List<string>{"timothee chalalamet", "Zendaya", "josh brolin" },
               description="A mythic and emotionally charged hero's journey, \"Dune\" tells the story of Paul Atreides, a brilliant and gifted young man born into a great destiny beyond his understanding, who must travel to the most dangerous planet in the universe to ensure the future of his family and his people. As malevolent forces explode into conflict over the planet's exclusive supply of the most precious resource in existence-a commodity capable of unlocking humanity's greatest potential-only those who can conquer their fear will survive." },
             new Movie{title = "The Dark Knight", director = "Christopher Nolan", stars=new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckart" },
               description="When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness." }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            return movieList;
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> GetByIndex(int index)
        {
            if (index < 0 || index >= movieList.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }
            return Ok(movieList[index]);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            movieList.Add(movie);
            return CreatedAtAction(nameof(GetByIndex), new { index = movieList.Count - 1 }, movie);
        }

        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= movieList.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }

            movieList.RemoveAt(index);
            return NoContent();
        }

    }



}
