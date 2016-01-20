using Day17_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Day17_CodeFirst.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IHttpActionResult Get()
        {
            //var movies = from m in _db.Movies select m;
            return Ok(_db.Movies.ToList());
        }

        public IHttpActionResult Get(int id)
        {
            //var movie = from m in _db.Movies where m.Id == id select m;
            //var movie = _db.Movies.Where(m => m.Id == id).FirstOrDefault();
            var movie = _db.Movies.Find(id);
            return Ok(movie);
        }

        public IHttpActionResult Post(Movie movie)
        {
            // if ModelState is valid, run the block of clode
            if(ModelState.IsValid)
            {
                // if movie.Id == 0, this means that this is a new movie
                if (movie.Id == 0)
                {
                    // Simply add a new movie to the database
                    _db.Movies.Add(movie);
                    _db.SaveChanges();
                    return Ok();
                }
                else // if movie.Id != 0, this means that we are trying to edit a movie
                {
                    // load the original movie to the variable called original
                    var original = _db.Movies.Find(movie.Id);
                    // and make the necessary changes
                    original.Title = movie.Title;
                    original.Director = movie.Director;
                    // then save the changes that were made
                    _db.SaveChanges();
                    return Ok(movie);
                }
            }
            // if the ModelState is not valid, return a BadRequest
            return BadRequest(ModelState);
        }

        public IHttpActionResult Delete(int id)
        {
            // find the movie we want to delete and load it up into original
            var original = _db.Movies.Find(id);
            // delete the movie that matches original in the database
            _db.Movies.Remove(original);
            // save changes to make a permanent change
            _db.SaveChanges();
            return Ok();
        }

    }
}
