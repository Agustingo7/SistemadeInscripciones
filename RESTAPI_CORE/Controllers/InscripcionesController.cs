using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RESTAPI_CORE.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace RESTAPI_CORE.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly string cadenaSQL;

        public int Id { get; private set; }

        public InscripcionesController(IConfiguration config) {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        //REFERENCIAS
        //MODELO
        //SQL

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista() { 
            
            List<Inscripciones> lista = new List<Inscripciones>();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_inscripciones", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {

                            lista.Add(new Inscripciones
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Nombre = rd["Nombre"].ToString(),
                                Apellido = rd["Apellido"].ToString(),
                                DNI = rd["DNI"].ToString(),
                                Edad = rd["Edad"].ToString(),
                                Correo = Convert.ToString(rd["Correo"])
                            });
                        }

                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" , response = lista });
            }
            catch(Exception error) {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message,  response = lista });

            }
        }

        [HttpGet]
        //[Route("Obtener")] // => Obtener?Id=13 | ampersand
        [Route("Obtener/{Id:int}")]
        public IActionResult Obtener(int Id)
        {

            List<Inscripciones> lista = new List<Inscripciones>();
            Inscripciones oproducto = new Inscripciones();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_lista_inscripciones", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {

                            lista.Add(new Inscripciones
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Nombre = rd["Nombre"].ToString(),
                                Apellido = rd["Apellido"].ToString(),
                                DNI = rd["DNI"].ToString(),
                                Edad = rd["Edad"].ToString(),
                                Correo = Convert.ToString(rd["Correo"])
                            });
                        }

                    }
                }

                oproducto = lista.Where(item => item.Id == Id).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oproducto });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = oproducto });

            }
        }



        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Inscripciones objeto)
        {
            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_guardar_inscripciones", conexion);
                    cmd.Parameters.AddWithValue("Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", objeto.Apellido);
                    cmd.Parameters.AddWithValue("DNI", objeto.DNI);
                    cmd.Parameters.AddWithValue("Edad", objeto.Edad);
                    cmd.Parameters.AddWithValue("Correo", objeto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "agregado" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message});

            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Inscripciones objeto)
        {
            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_editar_IdUsuario", conexion);
                    cmd.Parameters.AddWithValue("Id", objeto.Id == 0 ? DBNull.Value : objeto.Id);
                    cmd.Parameters.AddWithValue("Nombre", objeto.Nombre is null ? DBNull.Value : objeto.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", objeto.Apellido is null ? DBNull.Value : objeto.Apellido);
                    cmd.Parameters.AddWithValue("DNI", objeto.DNI is null ? DBNull.Value : objeto.DNI);
                    cmd.Parameters.AddWithValue("Edad", objeto.Edad is null ? DBNull.Value : objeto.Edad);
                    cmd.Parameters.AddWithValue("Correo", objeto.Correo is null ? DBNull.Value : objeto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "editado" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }

        [HttpDelete]
        [Route("Eliminar/{Id:int}")]
        public IActionResult Eliminar(int Id)
        {
            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_eliminar_inscripciones", conexion);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "eliminado" });
            }
            catch (Exception error)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });

            }
        }


    }
}
