using apiParcialMafe.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Data;
using System.Data.Common;

namespace apiParcialMafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        public IDbConnection _dbConnection;
        public ArticulosController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var connection = _dbConnection)
            {
                var articulos = await connection.QueryAsync<Articulos>("SELECT * FROM articulos;");
                return Ok(articulos);
            }
        }
    }
}
