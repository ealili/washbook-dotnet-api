namespace washbook_backend.DTOs;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

#nullable disable
public class UserDto
{
    public string Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string UserName { get; set; }

    public List<string> Roles { get; set; }
}