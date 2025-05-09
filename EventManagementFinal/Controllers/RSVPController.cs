using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagementFinal.Controllers
{
    public class RSVPController : ApiController
    {
        [HttpGet]
        [Route("api/rsvps/{eventId}")]
        public HttpResponseMessage GetRSVPsForEvent(int eventId)
        {
            try
            {
                var rsvps = RSVPService.GetRSVPsForEvent(eventId);
                return Request.CreateResponse(HttpStatusCode.OK, rsvps);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/rsvps/{eventId}/user/{userId}")]
        public HttpResponseMessage GetRSVPForUser(int eventId, int userId)
        {
            try
            {
                var rsvp = RSVPService.GetRSVPForUser(eventId, userId);
                if (rsvp == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "RSVP not found for this user and event");
                return Request.CreateResponse(HttpStatusCode.OK, rsvp);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/rsvps/create")]
        public HttpResponseMessage CreateOrUpdateRSVP(RSVPDTO rsvpDto)
        {
            try
            {
                var rsvp = RSVPService.CreateOrUpdateRSVP(rsvpDto.UserId, rsvpDto.EventId, rsvpDto.Name, rsvpDto.IsAttending);
                return Request.CreateResponse(HttpStatusCode.OK, rsvp);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
