using System.ComponentModel.DataAnnotations;

namespace user_crud_api.Domain.Model;

public class User : Entity
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    public bool isActive { get; set; } = true;
}

