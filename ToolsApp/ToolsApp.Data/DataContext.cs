using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsApp.Data
{
  public class DataContext
  {
    private readonly string _connectionString;

    public DataContext(IConfiguration configuration) {
      _connectionString = configuration["ConnectionString"];
    }

    public DataContext() {
      _connectionString = "";
    }

    public virtual IDbConnection CreateConnection() => new SqlConnection(_connectionString);
  }
}
