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
            string sqlDataSource = _configuration.GetConnectionString("TrabajadorAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@nombre", trabajador.nombre);
                    myCommand.Parameters.AddWithValue("@apellido_paterno", trabajador.apellido_paterno);
                    myCommand.Parameters.AddWithValue("@apellido_materno", trabajador.apellido_materno);
                    myCommand.Parameters.AddWithValue("@fecha_nacimiento", trabajador.fecha_nacimiento);
                    myCommand.Parameters.AddWithValue("@tipo_documento", trabajador.tipo_documento);
                    myCommand.Parameters.AddWithValue("@numero_documento", trabajador.numero_documento);
                    myCommand.Parameters.AddWithValue("@sueldo", trabajador.sueldo);
                    myCommand.Parameters.AddWithValue("@estado", trabajador.estado);
                    myCommand.Parameters.AddWithValue("@campos_auditoria", trabajador.campos_auditoria);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(trabajador);
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, Trabajador trabajador)
        {
            string query = @"
                        update trabajador set 
                        nombre =@nombre,
                        apellido_paterno =@apellido_paterno,
                        apellido_materno =@apellido_materno,
                        fecha_nacimiento =@fecha_nacimiento,
                        tipo_documento =@tipo_documento,
                        numero_documento =@numero_documento,
                        sueldo =@sueldo,
                        estado =@estado,  
                        campos_auditoria =@campos_auditoria
                        where id=@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadorAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@nombre", trabajador.nombre);
                    myCommand.Parameters.AddWithValue("@apellido_paterno", trabajador.apellido_paterno);
                    myCommand.Parameters.AddWithValue("@apellido_materno", trabajador.apellido_materno);
                    myCommand.Parameters.AddWithValue("@fecha_nacimiento", trabajador.fecha_nacimiento);
                    myCommand.Parameters.AddWithValue("@tipo_documento", trabajador.tipo_documento);
                    myCommand.Parameters.AddWithValue("@numero_documento", trabajador.numero_documento);
                    myCommand.Parameters.AddWithValue("@sueldo", trabajador.sueldo);
                    myCommand.Parameters.AddWithValue("@estado", trabajador.estado);
                    myCommand.Parameters.AddWithValue("@campos_auditoria", trabajador.campos_auditoria);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from trabajador 
                        where id=@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadorAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
