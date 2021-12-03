using MorCompany.Fiscalizacion.Datos.Interfaces;
using MorCompany.Fiscalizacion.DTOs;
using MorCompany.Fiscalizacion.DTOs.Administracion;
using MorCompany.Fiscalizacion.DTOs.Fabricas;
using MorCompany.Fiscalizacion.Negocio.Interfaces;
using MorCompany.Fiscalizacion.Utilidades.Ayudantes;
using MorCompany.Fiscalizacion.Utilidades.Comun;
using System;

namespace MorCompany.Fiscalizacion.Negocio.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        IRepositorioUsuario repositorioUsuario;

        public ServicioUsuario(IRepositorioUsuario _repositorioUsuario)
        {
            repositorioUsuario = _repositorioUsuario;
        }

        public UsuarioDto ObtenerPorId(int id)
        {
            try
            {
                return repositorioUsuario.ObtenerPorId(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ResultadoDto Autenticar(LoginDto login)
        {
            try
            {
                UsuarioDto usuarioExistente = repositorioUsuario.ObtenerPorCorreo(login.Correo);

                if (usuarioExistente == null)
                    return FabricaResultado.Error("No existe usuario");

                usuarioExistente.Clave = AyudanteSeguridad.DesencriptarConAes(usuarioExistente.Clave, Constantes.LlaveSeguridad);

                if (usuarioExistente.Clave != login.Clave)
                    return FabricaResultado.Error("Clave incorrecta");

                return FabricaResultado.Informativo("Autenticado");
            }
            catch (Exception ex)
            {
                return FabricaResultado.Excepcion("Excepción al autenticar usuario", ex);
            }
        }

        public ResultadoDto Crear(UsuarioDto usuario)
        {
            try
            {
                UsuarioDto usuarioExistente = repositorioUsuario.ObtenerPorCorreo(usuario.Correo);

                if (usuarioExistente != null)
                    return FabricaResultado.Error("Ya existe un usuario con el mismo correo");

                usuario.Clave = AyudanteSeguridad.EncriptarConAes(usuario.Clave, Constantes.LlaveSeguridad);

                repositorioUsuario.Crear(usuario);

                return FabricaResultado.Informativo("Usuario creado");
            }
            catch (Exception ex)
            {
                return FabricaResultado.Excepcion("Excepción al crear usuario", ex);
            }
        }

        public ResultadoDto Editar(UsuarioDto usuario)
        {
            try
            {
                UsuarioDto usuarioExistente = repositorioUsuario.ObtenerPorCorreo(usuario.Correo);

                if (usuarioExistente == null)
                    return FabricaResultado.Error("No existe usuario");

                usuario.Clave = string.IsNullOrEmpty(usuario.Clave) ?
                                    usuarioExistente.Clave :
                                    AyudanteSeguridad.EncriptarConAes(usuario.Clave, Constantes.LlaveSeguridad);

                repositorioUsuario.Editar(usuario);

                return FabricaResultado.Informativo("Usuario editado");
            }
            catch (Exception ex)
            {
                return FabricaResultado.Excepcion("Excepción al editar usuario", ex);
            }
        }

        public ResultadoDto Eliminar(int id)
        {
            try
            {
                UsuarioDto usuarioExistente = repositorioUsuario.ObtenerPorId(id);

                if (usuarioExistente == null)
                    return FabricaResultado.Error("No existe usuario");

                repositorioUsuario.Eliminar(id);

                return FabricaResultado.Informativo("Usuario eliminado");
            }
            catch (Exception ex)
            {
                return FabricaResultado.Excepcion("Excepción al eliminar usuario", ex);
            }
        }
    }
}
