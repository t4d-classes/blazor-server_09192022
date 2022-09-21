
using ToolsApp.Core.Interfaces.Data;
using ToolsApp.Core.Interfaces.Models;

using CarModel = ToolsApp.Models.Car;
using CarDataModel = ToolsApp.Data.Models.Car;

using AutoMapper;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ToolsApp.Data
{

  public class CarsSqlServerData : ICarsData
  {
    private DataContext _dataContext;
    private IMapper _mapper;

    public CarsSqlServerData(DataContext dataContext)
    {
      _dataContext = dataContext;
      var mapperConfig = new MapperConfiguration(config =>
      {
        config.CreateMap<CarDataModel, CarModel>().ReverseMap();
      });
      _mapper = mapperConfig.CreateMapper();
    }

    public async Task<IEnumerable<ICar>> All()
    {
      using var con = _dataContext.CreateConnection();

      var sql = "select Id, Make, Model, Year, Color, Price from Car";
      var cars = await con.QueryAsync<CarDataModel>(sql);

      return cars
        .Select(car => _mapper.Map<CarDataModel, CarModel>(car))
        .AsEnumerable<ICar>();
    }

    public async Task<ICar> Append(INewCar car)
    {
      using var con = _dataContext.CreateConnection();

      var carData = await con.QueryAsync<CarDataModel>(
        "[InsertCar]",
        car,
        commandType: System.Data.CommandType.StoredProcedure
      );

      return _mapper.Map<CarDataModel, CarModel>(carData.Single()) as ICar;

      // throw new NotImplementedException();
    }

    public async Task<ICar> One(int carId)
    {
      using var con = _dataContext.CreateConnection();

      var parameters = new { CarId = carId };
      var sql = "select Id, Make, Model, Year, Color, Price from Car where Id = @CarId";
      var cars = await con.QueryAsync<CarDataModel>(sql, parameters);

      return cars
        .Select(car => _mapper.Map<CarDataModel, CarModel>(car))
        .Cast<ICar>().SingleOrDefault();
    }

    public async Task Remove(int carId)
    {
      using var con = _dataContext.CreateConnection();

      await con.ExecuteAsync(
        "[DeleteCar]",
        new { Id = carId },
        commandType: System.Data.CommandType.StoredProcedure
      );
    }

    public async Task Replace(ICar car)
    {
      using var con = _dataContext.CreateConnection();

      await con.ExecuteAsync(
        "[UpdateCar]",
        car,
        commandType: System.Data.CommandType.StoredProcedure
      );
    }
  }

}
