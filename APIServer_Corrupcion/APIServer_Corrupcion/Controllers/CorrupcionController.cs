using APIServer_Corrupcion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIServer_Corrupcion.Controllers
{
    public class CorrupcionController : ApiController
    {
        //Abrir la conexion
        public ModeloReportesCorrupcion conexion;
        public CorrupcionController()
        {
            conexion = new ModeloReportesCorrupcion();
        }
      //Metodo 1. Obtener todos los reportes
        [Route("api/reportes/ObtenerTodos")]
        [HttpGet]
        public List<Reporte> GetReportes()
        {
            //SELECT * FROM Reportes            
            var consulta = from c in conexion.Reportes select c;
            return consulta.ToList(); 
        }
      //Metodo 2. Buscar reporte por Folio
        [Route("api/reportes/BuscarReporte")]
        [HttpGet]
        public List<Reporte> GetBusquedaReportes(int folio)
        {
            //SELECT * FROM Reportes WHERE Folio_Reporte = folio
            var consulta = from b in conexion.Reportes
                           where b.Folio_Reporte == folio
                           select b;
            return consulta.ToList();
        }
      //Metodo 3. Insertar nuevo reporte
        [Route("api/reportes/GuardarReporte")]
        [HttpPost]
        public bool GuardarNuevoReporte(Reporte datos)
        {
            using (var conectar = new ModeloReportesCorrupcion())
            {
                try
                {
                    conectar.Reportes.Add(
                    new Reporte()
                    {
                        Descripcion = datos.Descripcion,
                        Fecha_Reporte = datos.Fecha_Reporte,
                        Status = datos.Status,
                        Usuario = datos.Usuario,                        
                    });
                    conectar.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }    
        }
        //Metodo 4. Modificar reporte
        [Route("api/reporte/ModificarReporte")]
        [HttpPut]
        public bool PutModificarReporte(int Folio, [FromBody]Reporte datos)
        {
            using (var conectar = new ModeloReportesCorrupcion())
            {
                var consulta = (from c in conectar.Reportes
                                where c.Folio_Reporte == Folio
                                select c).FirstOrDefault();
                if (consulta != null)
                {
                    consulta.Descripcion = datos.Descripcion;
                    consulta.Status = datos.Status;                    
                    conectar.SaveChanges();
                }
                return true;
            }
        }

        //Metodo 5. Eliminar reporte
        [Route("api/reportes/EliminarReporte")]
        [HttpDelete]
        public bool EliminarReporte(int Folio)
        {
            using (var conectar = new ModeloReportesCorrupcion())
            {
                //DELETE * FROM reportes WHERE Folio
                var consulta = (from c in conectar.Reportes
                                where c.Folio_Reporte == Folio
                                select c).FirstOrDefault();

                if (consulta != null)
                {
                    conectar.Reportes.Remove(consulta);
                    conectar.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Metodo 6. Mostrar Status
        [Route("api/Status")]
        [HttpGet]
        public List<SoloEstatus> GetEstatus()
        {
            //SELECT estatus FROM Estatus            
            var consulta = from d in conexion.Estatus
                           select new SoloEstatus(){
                               Status = d.Status                               
                           };
            return consulta.ToList();
        }

      //Metodo 7. Mostrar usuarios registrados
        [Route("api/UsuariosRegistrados")]
        [HttpGet]
        public List<Usuario> GetUsuarios()
        {
            //SELECT * FROM Usuarios            
            var consulta = from c in conexion.Usuarios select c;
            return consulta.ToList();
        }

      //Metodo 8. Insertar Nuevo usuario        
        [Route("api/NuevoUsuario")]
        [HttpPost]
        public bool GuardarNuevoUsuario(Usuario datos)
        {
            using (var conectar = new ModeloReportesCorrupcion())
            {
                try
                {
                    conectar.Usuarios.Add(
                    new Usuario()
                    {
                        Usuario1 = datos.Usuario1,
                        Nombre = datos.Nombre,
                        ApeMaterno = datos.ApeMaterno,
                        ApePaterno = datos.ApePaterno,
                        Contrasena = datos.Contrasena,
                    });
                    conectar.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

      //Metodo 9. Modificar datos del usuario
        [Route("api/ModificarUsuario")]
        [HttpPut]
        public bool PutModificarUsuario(string user, [FromBody]Usuario datos)
        {
            using (var conectar = new ModeloReportesCorrupcion())
            {
                var consulta = (from c in conectar.Usuarios
                                where c.Usuario1 == user
                                select c).FirstOrDefault();
                if (consulta != null)
                {
                    consulta.Nombre = datos.Nombre;
                    consulta.ApeMaterno = datos.ApeMaterno;
                    consulta.ApePaterno = datos.ApePaterno;
                    consulta.Contrasena = datos.Contrasena;                   
                    conectar.SaveChanges();
                }
                return true;
            }
        }
        //Metodo 10. Buscar validar usuario 
        [Route("api/usuario/ValidarUsuario")]
        [HttpGet]
        public List<UsuarioFiltrado> GetBuscarUsuario(string user)
        {
            //SELECT usuario, contrasena FROM Usuarios WHERE usuario = user
            var consulta = from b in conexion.Usuarios
                           where b.Usuario1 == user
                           select new UsuarioFiltrado(){                               
                               Contrasena = b.Contrasena
                           };
            return consulta.ToList();
        }
        //Metodo 11. Buscar reporte por Usuario
        [Route("api/reportes/MisReportes")]
        [HttpGet]
        public List<Reporte> GetMisReportes(string user)
        {
            //SELECT * FROM Reportes WHERE Usuario = user
            var consulta = from b in conexion.Reportes
                           where b.Usuario == user
                           select b;
            return consulta.ToList();
        }
        
        //Metodo 12. Obtener Usuario
        [Route("api/usuario/ObtenerUsuario")]
        [HttpGet]
        public List<Usuario> GetObtenerUsuario(string user)
        {
            //SELECT * FROM usuario WHERE usuario = user
            var consulta = from c in conexion.Usuarios
                           where c.Usuario1 == user
                           select c;
            return consulta.ToList();
        }
    }
}
