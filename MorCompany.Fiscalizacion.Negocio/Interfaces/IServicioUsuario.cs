using MorCompany.Fiscalizacion.DTOs;
using MorCompany.Fiscalizacion.DTOs.Administracion;

namespace MorCompany.Fiscalizacion.Negocio.Interfaces
{
    public interface IServicioUsuario
    {
        UsuarioDto ObtenerPorId(int id);
        ResultadoDto Autenticar(LoginDto login);
        ResultadoDto Crear(UsuarioDto usuario);
        ResultadoDto Editar(UsuarioDto usuario);
        ResultadoDto Eliminar(int id);
    }
}
