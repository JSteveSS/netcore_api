using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using NetCoreCRUD.Models;

namespace NetCoreCRUD.Controllers
{
    [Route("api")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TrabajadorController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
              select * from trabajador  
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadorAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                select * from trabajador where id=@TrabajadorId;
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadorAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@TrabajadorId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Trabajador trabajador)
        {
            string query = @"
                        insert into trabajador(nombre, apellido_paterno, apellido_materno, fecha_nacimiento, tipo_documento, numero_documento, sueldo, estado, campos_auditoria) values
                         (@nombre, @apellido_paterno, @apellido_materno, @fecha_nacimiento, @tipo_documento, @numero_documento, @sueldo, @estado, @campos_auditoria) ;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@nombre", trabajador.TrabajadorNombre);
                    myCommand.Parameters.AddWithValue("@apellido_paterno", trabajador.TrabajadorApellidoPaterno);
                    myCommand.Parameters.AddWithValue("@apellido_materno", trabajador.TrabajadorApellidoMaterno);
                    myCommand.Parameters.AddWithValue("@fecha_nacimiento", trabajador.TrabajadorFechaDeNacimiento);
                    myCommand.Parameters.AddWithValue("@tipo_documento", trabajador.TrabajadorTipoDeDocumento);
                    myCommand.Parameters.AddWithValue("@numero_documento", trabajador.TrabajadorNumeroDeDocumento);
                    myCommand.Parameters.AddWithValue("@sueldo", trabajador.TrabajadorSueldo);
                    myCommand.Parameters.AddWithValue("@estado", trabajador.TrabajadorEstado);
                    myCommand.Parameters.AddWithValue("@campos_auditoria", trabajador.TrabajadorCamposDeAuditoria);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

    }
}
