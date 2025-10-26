using System.ComponentModel.DataAnnotations;

namespace demo.Dto;

public class TodoDto
{
    
    public int Id { get; set; }
    
    [Required]
    public string Title{ get; set; }
    
    public bool Checked { get; set; }
}