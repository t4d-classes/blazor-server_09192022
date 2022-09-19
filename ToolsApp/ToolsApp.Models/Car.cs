using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsApp.Core.Interfaces.Models;

namespace ToolsApp.Models
{
  public class NewCar : INewCar
  {
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
  }

  public class Car : NewCar, ICar
  {
    public int Id { get; set; }
  }
}
