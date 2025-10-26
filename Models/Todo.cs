using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models;

[Table("todos")]
public class Todo(string title)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("title")]
    [StringLength(100)]
    public string Title{ get; set; } = title;

    [Column("checked")]
    public bool Checked { get; set; } = false;

}