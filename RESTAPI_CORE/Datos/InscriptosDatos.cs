using RESTAPI_CORE.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace RESTAPI_CORE.Datos
{
    public class InscriptosDatos
    {

        public List<InscriptosModel> Listar() { 
        
            var oLista = new List<InscriptosModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new InscriptosModel() {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            DNI = dr["DNI"].ToString(),
                            Edad = dr["Edad"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Carrera = dr["Carrera"].ToString()
                        });

                    }
                }
            }

            return oLista;
        }

        public InscriptosModel Obtener(int Id)
        {

            var oContacto = new InscriptosModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContacto.Id = Convert.ToInt32(dr["Id"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Apellido = dr["Apellido"].ToString();
                        oContacto.DNI = dr["DNI"].ToString();
                        oContacto.Edad = dr["Edad"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                        oContacto.Carrera = dr["Carrera"].ToString();
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(InscriptosModel ocontacto) {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", ocontacto.Apellido);
                    cmd.Parameters.AddWithValue("DNI", ocontacto.DNI);
                    cmd.Parameters.AddWithValue("Edad", ocontacto.Edad);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.Parameters.AddWithValue("Carrera", ocontacto.Carrera);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e) {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }


        public bool Editar(InscriptosModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id", ocontacto.Id);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", ocontacto.Apellido);
                    cmd.Parameters.AddWithValue("DNI", ocontacto.DNI);
                    cmd.Parameters.AddWithValue("Edad", ocontacto.Edad);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.Parameters.AddWithValue("Carrea", ocontacto.Carrera);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int Id)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


    }
}
