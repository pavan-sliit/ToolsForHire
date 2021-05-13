using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolsForHire.Models;
using ToolsForHire.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace ToolsForHire.Controllers.Api
{
    public class ToolsController : ApiController
    {
        private ApplicationDbContext _context;

        public ToolsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/tools
        public IHttpActionResult GetTools(string query = null)
        {
            var toolsQuery = _context.Tools
                .Include(t => t.CategoryType)
                .Where(t => t.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                toolsQuery = toolsQuery.Where(t => t.Name.Contains(query));

            var toolDtos = toolsQuery
                .ToList()
                .Select(Mapper.Map<Tool, ToolDto>);

            return Ok(toolDtos);
        }

        //GET /api/tools/{id}
        public IHttpActionResult GetTool(int id)
        {
            var tool = _context.Tools.SingleOrDefault(c => c.Id == id);

            if (tool == null)
                return NotFound();

            return Ok(Mapper.Map<Tool, ToolDto>(tool));
        }

        //POST /api/tools
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageTools)]
        public IHttpActionResult CreateTool(ToolDto toolDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tool = Mapper.Map<ToolDto, Tool>(toolDto);
            _context.Tools.Add(tool);
            _context.SaveChanges();

            toolDto.Id = tool.Id;

            return Created(new Uri(Request.RequestUri + "/" + tool.Id), toolDto);
        }

        //PUT /api/tool/{id}
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageTools)]
        public IHttpActionResult UpdateTool(int id, ToolDto toolDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var toolInDb = _context.Tools.SingleOrDefault(c => c.Id == id);

            if (toolInDb == null)
                return NotFound();

            Mapper.Map(toolDto, toolInDb);
            _context.SaveChanges();

            return Ok();

        }

        //DELETE /api/tools/{id}
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageTools)]
        public IHttpActionResult DeleteTool(int id)
        {
            var toolInDb = _context.Tools.SingleOrDefault(c => c.Id == id);

            if (toolInDb == null)
                return NotFound();

            _context.Tools.Remove(toolInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
