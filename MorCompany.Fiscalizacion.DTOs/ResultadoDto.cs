
namespace MorCompany.Fiscalizacion.DTOs
{
    public class ResultadoDto
    {
        public string Mensaje { get; set; }

        private enum TipoMensaje
        {
            Info = 1,
            Warn = 2,
            Error = 3,
            Fatal = 4,
        }

        private TipoMensaje Estado { get; set; }

        public void DefinirInformativo() => Estado = TipoMensaje.Info;
        public void DefinirAdvertencia() => Estado = TipoMensaje.Warn;
        public void DefinirError() => Estado = TipoMensaje.Error;
        public void DefinirExcepcion() => Estado = TipoMensaje.Fatal;

        public bool EsInformativo() => Estado == TipoMensaje.Info;
        public bool EsAdvertencia() => Estado == TipoMensaje.Warn;
        public bool EsError() => Estado == TipoMensaje.Error;
        public bool EsExcepcion() => Estado == TipoMensaje.Fatal;
    }
}
