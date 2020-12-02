using ExamenPart2.Core;
using ExamenPart2.Core.Entities;
using ExamenPart2.Core.Enums;
using ExamenPart2.Core.Interfaces;
using ExamenPart2.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenPart2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }
        // GET: api/<SongsController>
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            var serviceResult = _songService.getSongs();
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);

            return Ok(serviceResult.Result.Select(p => new Song
            {
                songName = p.songName,
                artistName = p.artistName,
                bought = p.bought,
                popularity = p.popularity,
                sid = p.sid,
                price = p.price,
                albumId = p.albumId,
                duration = p.duration
            }));
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        // POST api/<SongsController>
        [HttpPost]
        public ActionResult<Song> Post([FromBody] Song bodySong)
        {
            var serviceResult = _songService.AddSong(bodySong);
            if (serviceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(serviceResult.Error);
            var result = new Song
            {
                songName = serviceResult.Result.songName,
                artistName = serviceResult.Result.artistName,
                bought = serviceResult.Result.bought,
                popularity = serviceResult.Result.popularity,
                sid = serviceResult.Result.sid,
                price = serviceResult.Result.price,
                albumId= serviceResult.Result.albumId,
                duration=serviceResult.Result.duration
            };

            return Ok(result);







            //Song nSong = new Song
            //{
            //    albumId = bodySong.albumId,
            //    artistName = bodySong.artistName,
            //    bought = bodySong.bought,
            //    duration = bodySong.duration,
            //    popularity=bodySong.popularity,
            //    price=bodySong.price,
            //    sid=bodySong.sid,
            //    songName=bodySong.songName,
            //};

            //var songsinAlbum = dbContext.Songs.Where(x => x.albumId == bodySong.albumId);
            //var score = songsinAlbum.Sum(x => x.popularity)/songsinAlbum.Count();
            //dbContext.Songs.Add(nSong);
            //dbContext.SaveChanges();

            //var modifiedAlbum = dbContext.Albums.FirstOrDefault(x => x.id == nSong.albumId);
            //modifiedAlbum.score = score;
            //var fullAlbumprice = songsinAlbum.Sum(x => x.price) + nSong.price;
            //modifiedAlbum.price = fullAlbumprice - (fullAlbumprice * 0.1);

            //dbContext.Albums.Update(modifiedAlbum);
            //dbContext.SaveChanges();

        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
