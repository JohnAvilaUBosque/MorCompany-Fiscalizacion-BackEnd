using Microsoft.AspNetCore.Mvc;
using MorCompany.Fiscalizacion.DTOs;
using MorCompany.Fiscalizacion.DTOs.Administracion;
using MorCompany.Fiscalizacion.Negocio.Interfaces;

namespace MorCompany.Fiscalizacion.API.Controladores
{
    [ApiController]
    [Route("api/usuario")]
    public class ControladorUsuario : ControllerBase
    {
        private IServicioUsuario servicioUsuario;

        public ControladorUsuario(IServicioUsuario _servicioUsuario)
        {
            servicioUsuario = _servicioUsuario;
        }

        [HttpGet("{id}")]
        public ActionResult ObtenerPorId(int id)
        {
            UsuarioDto usuario = servicioUsuario.ObtenerPorId(id);

            if (usuario != null) return Ok(usuario);

            return BadRequest("No existe usuario");
        }

        [HttpPost("autenticar")]
        public ActionResult Autenticar([FromBody] LoginDto login)
        {
            ResultadoDto resultado = servicioUsuario.Autenticar(login);

            if (resultado.EsInformativo()) return Ok(resultado.Mensaje);

            return BadRequest(resultado.Mensaje);
        }

        [HttpPost("crear")]
        public ActionResult Crear([FromBody] UsuarioDto usuario)
        {
            ResultadoDto resultado = servicioUsuario.Crear(usuario);

            if (resultado.EsInformativo()) return Ok(resultado.Mensaje);

            return BadRequest(resultado.Mensaje);
        }

        [HttpPut("editar")]
        public ActionResult Editar([FromBody] UsuarioDto usuario)
        {
            ResultadoDto resultado = servicioUsuario.Editar(usuario);

            if (resultado.EsInformativo()) return Ok(resultado.Mensaje);

            return BadRequest(resultado.Mensaje);
        }

        [HttpDelete("eliminar/{id}")]
        public ActionResult Eliminar(int id)
        {
            ResultadoDto resultado = servicioUsuario.Eliminar(id);

            if (resultado.EsInformativo()) return Ok(resultado.Mensaje);

            return BadRequest(resultado.Mensaje);
        }

    }
}
