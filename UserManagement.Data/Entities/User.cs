using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Forename { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool IsActive { get; set; }
    //if this was real data, I'd use the DateTime type for the below property, but seeing as it's fictional data I figured a string was suitable for now.
    public string DateOfBirth { get; set; } = default!; 
}
