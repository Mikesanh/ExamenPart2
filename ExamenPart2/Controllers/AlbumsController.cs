using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ExamenPart2.Infrastructure;
using ExamenPart2.API.Models;
using System.Threading.Tasks;
using ExamenPart2.Core.Entities;
using ExamenPart2.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenPart2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ExamenPart2DbContext dbContext;
        private readonly IAlbumService _albumService;
        public AlbumsController(ExamenPart2DbContext _context)
        {
            dbContext = _context;
        }
        public AlbumsController(IAlbumService albumService) 
        {
            _albumService = albumService;
        }

        // GET api/<AlbumsController>
        [HttpGet]
        public IEnumerable<Album> Get2()
        {
            return dbContext.Albums;
        }

        // GET api/<AlbumController>/5
        [HttpGet("Top10")]
     
        public List<Album> Get(int id)
        {
            var myAlbums = dbContext.Albums;
            var mostPopularAlbums = dbContext.Albums.OrderByDescending(x => x.score).Take(10);

            List<Album> Top10MostPopularAlbums = new List<Album>();
            Album nAlbum = new Album();
          
            foreach (var item in mostPopularAlbums)
            {

                nAlbum.albumName = item.albumName;
                nAlbum.artistName = item.artistName;
                nAlbum.bought = item.bought;
                nAlbum.date = item.date;
                nAlbum.score = item.score;
                nAlbum.description = item.description;
                nAlbum.genre = item.genre;
                nAlbum.id = item.id;
                nAlbum.image = item.image;
                nAlbum.price = item.price;
                nAlbum.songs = item.songs;
                
                Top10MostPopularAlbums.Add(nAlbum);

            }


            return Top10MostPopularAlbums;
        }

        // GET: api/Albums
        [HttpGet]
        public int Get()
        {
            var albumsDb = dbContext.Albums.Select(album => new AlbumDto
            {
                id = album.id,
                albumName = album.albumName,
                image = album.image,
                artistName = album.artistName,
            });



            return 1;
        }

        //POST api/<AlbumController>
        [HttpPost]
        public void Post([FromBody] Album bodyAlbum)
        {
            Album nAlbum = new Album
            {
                albumName = bodyAlbum.albumName,
                artistName = bodyAlbum.artistName,
                bought = bodyAlbum.bought,
                date=bodyAlbum.date,
                score=bodyAlbum.score,
                description=bodyAlbum.description,
                genre=bodyAlbum.genre,
                id=bodyAlbum.id,
                image=bodyAlbum.image,
                price=bodyAlbum.price,
                songs=bodyAlbum.songs,    
            };
            dbContext.Albums.Add(nAlbum);
            dbContext.SaveChanges();

        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
