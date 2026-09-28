namespace GarageApp.Data.Models;

using GarageApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(40)]
    public string Make { get; set; } = null!;

    [Required]
    [StringLength(40)]
    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public CarType Type { get; set; }

    public bool IsAvailable { get; set; }

    public int GarageId { get; set; }

    public Garage Garage { get; set; }
}
