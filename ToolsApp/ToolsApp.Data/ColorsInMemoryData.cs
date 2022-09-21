using AutoMapper;
using ToolsApp.Core.Interfaces.Data;
using ToolsApp.Core.Interfaces.Models;

using ColorModel = ToolsApp.Models.Color;
using ColorDataModel = ToolsApp.Data.Models.Color;

namespace ToolsApp.Data
{
  public class ColorsInMemoryData : IColorsData
  {
    private IMapper _mapper;
    
    private List<ColorDataModel> _colors = new() {
      new() { Id = 1, Name = "red", HexCode = "ff0000" },
      new() { Id = 2, Name = "blue", HexCode = "0000ff" },
      new() { Id = 3, Name = "yellow", HexCode = "00ffff" },
    };

    public ColorsInMemoryData()
    {
      var mapperConfig = new MapperConfiguration(config =>
      {
        config.CreateMap<INewColor, ColorDataModel>();
        config.CreateMap<IColor, ColorDataModel>();
        config.CreateMap<ColorDataModel, ColorModel>().ReverseMap();
      });

      _mapper = mapperConfig.CreateMapper();
    }
    
    
    public Task<IEnumerable<IColor>> All()
    {
      return Task.FromResult(
        _colors
          .Select(colorDataModel => _mapper.Map<ColorDataModel, ColorModel>(colorDataModel))
          .AsEnumerable<IColor>());
    }

    public Task<IColor> One(int colorId)
    {
      return Task.FromResult(_colors
        .Where(c => c.Id == colorId)
        .Select(c => _mapper.Map<ColorDataModel, ColorModel>(c))
        .Cast<IColor>()
        .SingleOrDefault());
    }

    public Task<IColor> Append(INewColor newColor)
    {
      var newColorDataModel = _mapper.Map<ColorDataModel>(newColor);
      newColorDataModel.Id = _colors.Any() ? _colors.Max(c => c.Id) + 1 : 1;
      
      _colors.Add(newColorDataModel);

      return Task.FromResult(
        _mapper.Map<ColorDataModel, ColorModel>(newColorDataModel) as IColor);
    }

    public Task Remove(int colorId)
    {
      var colorIndex = _colors.FindIndex(c => c.Id == colorId);
      if (colorIndex == -1)
      {
        throw new IndexOutOfRangeException("Color not found");
      }
      _colors.RemoveAt(colorIndex);
      return Task.CompletedTask;
    }

    public Task Replace(IColor color)
    {
      var colorDataModel = _mapper.Map<ColorDataModel>(color);
      var colorIndex = _colors.FindIndex(c => c.Id == colorDataModel.Id);
      if (colorIndex == -1)
      {
        throw new IndexOutOfRangeException("Color not found");
      }    

      _colors[colorIndex] = colorDataModel;
      return Task.CompletedTask;
    }
  }
}