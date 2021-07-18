using RVAS_Kosarka.Dtos;
using RVAS_Kosarka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace RVAS_Kosarka.Controllers.Api
{
    public class ClubsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClubsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/clubs
        public IEnumerable<ClubDto> GetClubs()
        {
            return _context.Clubs.ToList().Select(Mapper.Map<Club, ClubDto>);
            
        }

        //POST /api/clubs
        [HttpPost]
        public IHttpActionResult CreateClub(ClubDto clubDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var club = Mapper.Map<ClubDto, Club>(clubDto);

            _context.Clubs.Add(club);
            _context.SaveChanges();

            clubDto.Id = club.Id;

            return Created(new Uri(Request.RequestUri + "/" + club.Id), clubDto);
        }

        //DELETE /api/clubs/1
        [HttpDelete]
        public void DeleteClub(int id)
        {
            var clubInDb = _context.Clubs.SingleOrDefault(c => c.Id == id);

            if (clubInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Clubs.Remove(clubInDb);
            _context.SaveChanges();
        }
        
        // PUT /api/clubs/1
        [HttpPut]
        public IHttpActionResult UpdateClub(ClubDto clubDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clubInDb = _context.Clubs.SingleOrDefault(c => c.Id == clubDto.Id);

            if (clubInDb == null)
                return NotFound();

            Mapper.Map(clubDto, clubInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
