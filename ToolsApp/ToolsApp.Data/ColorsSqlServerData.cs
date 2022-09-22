using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

using AutoMapper;
using Dapper;

using ToolsApp.Core.Interfaces.Data;
using ToolsApp.Core.Interfaces.Models;

using ColorModel = ToolsApp.Models.Color;
using ColorDataModel = ToolsApp.Data.Models.Color;


namespace ToolsApp.Data;

public class ColorsSqlServerData : IColorsData
{
  private DataContext _dataContext;
  private IMapper _mapper;

  public ColorsSqlServerData(DataContext dataContext)
  {
    _dataContext = dataContext; 
    var mapperConfig = new MapperConfiguration(config => {
      config.CreateMap<ColorDataModel, ColorModel>().ReverseMap();
    });
    _mapper = mapperConfig.CreateMapper();
  }

  [JSInvokable]
  public async Task<IEnumerable<IColor>> All()
  {
    using var con = _dataContext.CreateConnection();

    var sql = "select Id, Name, Hexcode from Color";
    var colors = await con.QueryAsync<ColorDataModel>(sql);

    return colors
      .Select(color => _mapper.Map<ColorDataModel, ColorModel>(color))
      .AsEnumerable<IColor>();
  }

  public async Task<IColor> Append(INewColor newColor)
  {
    using var con = _dataContext.CreateConnection();

    var colorData = await con.QueryAsync<ColorDataModel>(
      "[InsertColor]",
      newColor,
      commandType: System.Data.CommandType.StoredProcedure
    );
  
    return _mapper.Map<ColorDataModel, ColorModel>(colorData.Single()) as IColor;  
  }

  public async Task<IColor> One(int colorId)
  {
    using var con = _dataContext.CreateConnection();

    var parameters = new { ColorId = colorId };
    var sql = "select Id, Name, Hexcode from Color where Id = @ColorId";
    var colors = await con.QueryAsync<ColorDataModel>(sql, parameters);

    return colors
      .Select(color => _mapper.Map<ColorDataModel, ColorModel>(color))
      .Cast<IColor>().SingleOrDefault();
  }

  public async Task Remove(int colorId)
  {
    using var con = _dataContext.CreateConnection();

    await con.ExecuteAsync(
      "[DeleteColor]",
      new { Id = colorId },
      commandType: System.Data.CommandType.StoredProcedure
    );
  }

  public async Task Replace(IColor color)
  {
    using var con = _dataContext.CreateConnection();

    await con.ExecuteAsync(
      "[UpdateColor]",
      color,
      commandType: System.Data.CommandType.StoredProcedure
    );
  }
}
