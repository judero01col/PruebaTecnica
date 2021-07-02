﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PruebaTecnica.Application.Features.Positions.Commands.CreatePosition;
using PruebaTecnica.Application.Features.Positions.Commands.DeletePositionById;
using PruebaTecnica.Application.Features.Positions.Commands.UpdatePosition;
using PruebaTecnica.Application.Features.Positions.Queries.GetPositionById;
using PruebaTecnica.Application.Features.Positions.Queries.GetPositions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.WebApi.Controllers.v1
{
    //[ApiVersion("1.0")]
    //public class PositionsController : BaseApiController
    //{
    //    /// <summary>
    //    /// GET: api/controller, , CRUD > Get by query parameters
    //    /// </summary>
    //    /// <param name="filter"></param>
    //    /// <returns></returns>
    //    [HttpGet]
    //    public async Task<IActionResult> Get([FromQuery] GetPositionsQuery filter)
    //    {
    //        return Ok(await Mediator.Send(filter));
    //    }

    //    /// <summary>
    //    /// GET api/controller, CRUD > Get by Id
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> Get(Guid id)
    //    {
    //        return Ok(await Mediator.Send(new GetPositionByIdQuery { Id = id }));
    //    }

    //    /// <summary>
    //    /// POST api/controller, CRUD > Create
    //    /// </summary>
    //    /// <param name="command"></param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    [ProducesResponseType(StatusCodes.Status201Created)]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    // [Authorize]

    //    public async Task<IActionResult> Post(CreatePositionCommand command)
    //    {
    //        var resp = await Mediator.Send(command);
    //        return CreatedAtAction(nameof(Post), resp);
    //    }

    //    /// <summary>
    //    /// Custom - Bulk insert fake data by specifying number of rows
    //    /// </summary>
    //    /// <param name="command"></param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    [Route("AddMock")]
    //    // [Authorize]
    //    public async Task<IActionResult> AddMock(InsertMockPositionCommand command)
    //    {
    //        return Ok(await Mediator.Send(command));
    //    }


    //    /// <summary>
    //    /// PUT api/controller, CRUD > Update
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <param name="command"></param>
    //    /// <returns></returns>
    //    [HttpPut("{id}")]
    //    [Authorize]
    //    public async Task<IActionResult> Put(Guid id, UpdatePositionCommand command)
    //    {
    //        if (id != command.Id)
    //        {
    //            return BadRequest();
    //        }
    //        return Ok(await Mediator.Send(command));
    //    }

    //    /// <summary>
    //    /// DELETE api/controller; CRUD > Delete
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    [HttpDelete("{id}")]
    //    [Authorize]
    //    public async Task<IActionResult> Delete(Guid id)
    //    {
    //        return Ok(await Mediator.Send(new DeletePositionByIdCommand { Id = id }));
    //    }
    //}
}
