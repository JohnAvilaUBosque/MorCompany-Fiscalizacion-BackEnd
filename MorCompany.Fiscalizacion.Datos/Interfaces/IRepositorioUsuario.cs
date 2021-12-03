using MorCompany.Fiscalizacion.DTOs.Administracion;

namespace MorCompany.Fiscalizacion.Datos.Interfaces
{
    public interface IRepositorioUsuario
    {
        UsuarioDto ObtenerPorId(int id);
        UsuarioDto ObtenerPorCorreo(string correo);
        void Crear(UsuarioDto usuario);
        void Editar(UsuarioDto usuario);
        void Eliminar(int id);
    }
}
