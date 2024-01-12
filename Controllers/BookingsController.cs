using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using washbook_backend.DTOs;
using washbook_backend.Models;
using washbook_backend.Services.Interfaces;
using washbook_backend.Utilities.Helpers;

namespace washbook_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<BookingsController> _logger;

    public BookingsController(IBookingService bookingService, UserManager<User> userManager,
        ILogger<BookingsController> logger
    )
    {
        _bookingService = bookingService;
        _userManager = userManager;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _bookingService.GetAllAsync();

        var bookingDtos = bookings.Select(b => new BookingDto
        {
            Id = b.Id,
            DateTime = b.DateTime,
            RoomNumber = b.RoomNumber,
            User = new UserDto
            {
                Id = b.User.Id,
                FirstName = b.User.FirstName,
                LastName = b.User.LastName,
                UserName = b.User.UserName,
                Email = b.User.Email,
            }
        });

        var response = new ApiResponse<IEnumerable<BookingDto>>(true, "Data retrieved successfully", bookingDtos);

        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
    {
        try
        {
            var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _logger.LogInformation($"--INFO--: User {currentUserId} is creating a booking.");

            var booking = new Booking
            {
                DateTime = bookingDto.DateTime,
                RoomNumber = bookingDto.RoomNumber,
                UserId = currentUserId
            };
            await _bookingService.AddAsync(booking);
            var response = new ApiResponse<Booking>(true, "Data retrieved successfully", booking);

            return Ok(response);
        }
        catch (Exception e)
        {
            _logger.LogInformation($"--INFO--: User Creating.... {e.Message}");
            var errorResponse = new ApiResponse<string>(false, "An unexpected error occurred", null);
            return BadRequest(errorResponse);
        }
    }
}