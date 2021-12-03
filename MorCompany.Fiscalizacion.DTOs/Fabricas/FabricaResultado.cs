
using System;

namespace MorCompany.Fiscalizacion.DTOs.Fabricas
{
    public static class FabricaResultado
    {
        public static ResultadoDto Informativo(string mensaje)
        {
            ResultadoDto resultadoDto = new ResultadoDto();
            resultadoDto.DefinirInformativo();
            resultadoDto.Mensaje = mensaje;
            return resultadoDto;
        }

        public static ResultadoDto Advertencia(string mensaje)
        {
            ResultadoDto resultadoDto = new ResultadoDto();
            resultadoDto.DefinirAdvertencia();
            resultadoDto.Mensaje = mensaje;
            return resultadoDto;
        }

        public static ResultadoDto Error(string mensaje)
        {
            ResultadoDto resultadoDto = new ResultadoDto();
            resultadoDto.DefinirError();
            resultadoDto.Mensaje = mensaje;
            return resultadoDto;
        }

        public static ResultadoDto Excepcion(string mensaje, Exception ex)
        {
            ResultadoDto resultadoDto = new ResultadoDto();
            resultadoDto.DefinirExcepcion();
            resultadoDto.Mensaje = $"{mensaje}  |   {ex.Message}    |   {ex.InnerException?.Message}";
            return resultadoDto;
        }
    }
}
