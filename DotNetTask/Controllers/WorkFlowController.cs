﻿using Core.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IWorkFlowService _workFlowService;
        public WorkFlowController(IWorkFlowService workFlowService)
        {
            _workFlowService = workFlowService;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetWorkFlow(string id)
        {
            var workFlow = await _workFlowService.GetByIdAsync(id);
            if (workFlow == null)
            {
                return NotFound($"WorkFlow with ID {id} not found.");
            }

            return Ok(workFlow);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetWorkFlow()
        {
            var workFlows = await _workFlowService.GetAllAsync();

            if (workFlows == null)
            {
                return NotFound("WorkFlow not found");
            }
            return Ok(workFlows);
        }
    }
}
