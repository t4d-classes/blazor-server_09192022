using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToolsApp.Components.Validators
{
  public class HexColorValidator: ValidationAttribute
  {
    private Regex _hexColorRegex;

    public HexColorValidator(int hexColorLength)
    {
      _hexColorRegex = new Regex("^[0-9a-fA-F]{" + hexColorLength + "}$");
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {

      var inputValue = Convert.ToString(value);

      if (inputValue is null)
      {
        return new ValidationResult($"{validationContext.DisplayName} is not a valid hex color");
      }

      if (!_hexColorRegex.IsMatch(inputValue))
      {
        return new ValidationResult($"{validationContext.DisplayName} is not a valid hex color");
      }

      return ValidationResult.Success;

    }
  }
}
