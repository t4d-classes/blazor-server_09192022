using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsApp.Core.Interfaces.Models
{

  public interface INewColor
  {
    string Name { get; set; }
    string HexCode { get; set; }
  }


  public interface IColor: INewColor
  {
    int Id {  get; set; }
  }
}
