using Microsoft.AspNetCore.Mvc;
using washbook_backend.DTOs;
using washbook_backend.Models;
using washbook_backend.Services.Interfaces;
using washbook_backend.Utilities.Helpers;

namespace washbook_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachinesController : ControllerBase
{
    private readonly IMachineService _machineService;

    public MachinesController(IMachineService machineService)
    {
        _machineService = machineService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Machine>>> GetAllMachines()
    {
        var machines = await _machineService.GetAllAsync();
        return Ok(machines);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Machine>> GetMachineById(int id)
    {
        var machine = await _machineService.GetByIdAsync(id);
        return Ok(machine);
    }

    [HttpPost]
    public async Task<ActionResult> AddMachine([FromBody] MachineDto machineDto)
    {
        // TODO: Update, code clean up, remove try catch
        try
        {
            var machine = new Machine
            {
                Name = machineDto.Name,
                Status = machineDto.Status,
            };

            await _machineService.AddAsync(machine);
            var response = new ApiResponse<Machine>(true, "Data created successfully", machine);

            return Ok(response);
        }
        catch (Exception e)
        {
            var errorResponse = new ApiResponse<string>(false, "An unexpected error occurred", null);
            return BadRequest(errorResponse);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var machine = await _machineService.GetByIdAsync(id);
        await _machineService.DeleteAsync(machine);

        return NoContent();
    }
}