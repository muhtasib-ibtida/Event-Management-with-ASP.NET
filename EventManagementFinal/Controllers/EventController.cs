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
    public class EventController : ApiController
    {
        [HttpGet]
        [Route("api/events/all")]
        public HttpResponseMessage GetAllEvents()
        {
            try
            {
                var events = EventService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, events);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/events/{id}")]
        public HttpResponseMessage GetEvent(int id)
        {
            try
            {
                var eventDetails = EventService.Get(id);
                if (eventDetails == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Event not found");
                return Request.CreateResponse(HttpStatusCode.OK, eventDetails);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/events/create")]
        public HttpResponseMessage AddEvent(EventDTO eventDto)
        {
            try
            {
                var createdEvent = EventService.Create(eventDto);
                return Request.CreateResponse(HttpStatusCode.Created, createdEvent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("api/events/{id}")]
        public HttpResponseMessage UpdateEvent(int id, EventDTO eventDto)
        {
            try
            {
                var updatedEvent = EventService.Update(eventDto);
                if (updatedEvent == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Event not found");
                return Request.CreateResponse(HttpStatusCode.OK, updatedEvent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/events/{id}")]
        public HttpResponseMessage DeleteEvent(int id)
        {
            try
            {
                var deleted = EventService.Delete(id);
                if (!deleted)
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Event not found");
                return Request.CreateResponse(HttpStatusCode.OK, "Event deleted successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
