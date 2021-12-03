using Dapper;
using Microsoft.Extensions.Configuration;
using MorCompany.Fiscalizacion.Datos.Interfaces;
using MorCompany.Fiscalizacion.DTOs.Administracion;
using System;
using System.Linq;

namespace MorCompany.Fiscalizacion.Datos.Repositorios
{
    public class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        IConfiguration configuration;

        public RepositorioUsuario(IConfiguration _configuration)
            : base(_configuration.GetConnectionString("ConnexionPostgree"))
        {
            configuration = _configuration;
        }

        public UsuarioDto ObtenerPorId(int id)
        {
            using (var conn = OpenConnection())
            {
                var sql = $"SELECT * FROM usuario WHERE idUsuario = {id}";
                var res = conn.Query<UsuarioDto>(sql).FirstOrDefault();
                return res;
            }
        }

        public UsuarioDto ObtenerPorCorreo(string correo)
        {
            using (var conn = OpenConnection())
            {
                var sql = $"SELECT * FROM usuario WHERE correo = '{correo}'";
                var res = conn.Query<UsuarioDto>(sql).FirstOrDefault();
                return res;
            }
        }

        public void Crear(UsuarioDto usuario)
        {
            using (var conn = OpenConnection())
            {
                var sql = @$"INSERT INTO public.usuario(nombres, apellidos, correo, clave)
                                   VALUES('{usuario.Nombres}', '{usuario.Apellidos}', '{usuario.Correo}', '{usuario.Clave}');";
                var res = conn.Execute(sql);
                if (res == 0) throw new Exception("No fue posible crear el usuario");
            }
        }

        public void Editar(UsuarioDto usuario)
        {
            using (var conn = OpenConnection())
            {
                var sql = @$"UPDATE usuario
	                         SET nombres='{usuario.Nombres}', apellidos='{usuario.Apellidos}', correo='{usuario.Correo}', clave='{usuario.Clave}'
	                         WHERE idUsuario = {usuario.IdUsuario}";
                var res = conn.Execute(sql);
                if (res == 0) throw new Exception("No fue posible editar el usuario");
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = OpenConnection())
            {
                var sql = $"DELETE FROM usuario WHERE idUsuario = {id}";
                var res = conn.Execute(sql);
                if (res == 0) throw new Exception("No fue posible eliminar el usuario");
            }
        }

    }
}
