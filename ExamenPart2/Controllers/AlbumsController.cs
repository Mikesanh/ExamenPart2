using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ExamenPart2.Infrastructure;
using ExamenPart2.API.Models;
using System.Threading.Tasks;
using ExamenPart2.Core.Entities;
using ExamenPart2.Core.Interfaces;
using ExamenPart2.Core.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenPart2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
       
        private readonly IAlbumService _albumService;
       
        public AlbumsController(IAlbumService albumService) 
        {
            _albumService = albumService;
        }


        // GET api/<AlbumController>/5
        [HttpGet("api/Top10")]
        public ActionResult<IEnumerable<Album>> Getpop()
        {
            var serviceResult = _albumService.GetPopularAlbums();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            var albums = serviceResult.Result;
            return Ok(albums.Select(p => new Album
            {
                albumName=p.albumName,
                artistName=p.artistName,
                bought=p.bought,
                date=p.date,
                description=p.description,
                genre=p.genre,
                id=p.id,
                image=p.image,
                price=p.price,
                score=p.score,
                songs=p.songs
            }));
        }

        // GET: api/Albums
        [HttpGet]
        public ActionResult<IEnumerable<Album>> Get()
        {
            var serviceResult = _albumService.GetAlbums();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return Ok(serviceResult.Result.Select(p => new Album
            {
                albumName = p.albumName,
                artistName = p.artistName,
                bought = p.bought,
                date = p.date,
                description = p.description,
                genre = p.genre,
                id = p.id,
                image = p.image,
                price = p.price,
                score = p.score,
                songs = p.songs
            }));
        }

        //POST api/<AlbumController>
        [HttpPost]
        public ActionResult<Album> Post([FromBody] Album bodyAlbum)
        {
            var serviceResult = _albumService.AddAlbum(bodyAlbum);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);
            var result= new Album
            {
                albumName = serviceResult.Result.albumName,
                artistName = serviceResult.Result.artistName,
                bought = serviceResult.Result.bought,
                date= serviceResult.Result.date,
                score= serviceResult.Result.score,
                description= serviceResult.Result.description,
                genre= serviceResult.Result.genre,
                id= serviceResult.Result.id,
                image= serviceResult.Result.image,
                price= serviceResult.Result.price,
                songs= serviceResult.Result.songs,    
            };

            return Ok(result);
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
