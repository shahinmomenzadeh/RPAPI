using System.ComponentModel.DataAnnotations;


namespace model.UserDto;

public class UserDto
{
    
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string lastname { get; set; }
    public int cardid { get; set; }
    
    public string ImageUrl { get; set; }
    
    
}