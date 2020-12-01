﻿using ExamenPart2.Core.Entities;
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
        private readonly ExamenPart2DbContext dbContext;
        public SongsController(ExamenPart2DbContext _context)
        {
            dbContext = _context;
        }
        // GET: api/<SongsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        // POST api/<SongsController>
        [HttpPost]
        public void Post([FromBody] Song bodySong)
        {
            Song nSong = new Song
            {
                albumId = bodySong.albumId,
                artistName = bodySong.artistName,
                bought = bodySong.bought,
                duration = bodySong.duration,
                popularity=bodySong.popularity,
                price=bodySong.price,
                sid=bodySong.sid,
                songName=bodySong.songName,
            };

            var songsinAlbum = dbContext.Songs.Where(x => x.albumId == bodySong.albumId);
            var score = songsinAlbum.Sum(x => x.popularity)/songsinAlbum.Count();
            dbContext.Songs.Add(nSong);
            dbContext.SaveChanges();

            var modifiedAlbum = dbContext.Albums.FirstOrDefault(x => x.id == nSong.albumId);
            modifiedAlbum.score = score;
            var fullAlbumprice = songsinAlbum.Sum(x => x.price) + nSong.price;
            modifiedAlbum.price = fullAlbumprice - (fullAlbumprice * 0.1);

            dbContext.Albums.Update(modifiedAlbum);
            dbContext.SaveChanges();

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