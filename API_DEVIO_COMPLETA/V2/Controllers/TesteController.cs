using API_DEVIO_COMPLETA.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace API_DEVIO_COMPLETA.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TesteController : MainController
    {
        private readonly ILogger _logger;

        public TesteController(INotificador notificador, IUser appUser, ILogger<TesteController> logger) : base(notificador, appUser)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {

            //throw new Exception("testeeee");

            _logger.LogTrace("log de trace"); // log minimo para desenvolvimento
            _logger.LogDebug("log de debug"); // log de info de debug para desenvolvimento

            // pode usar na aplicação em qualquer ambiente
            _logger.LogInformation("log de informação");
            _logger.LogWarning("log de aviso");
            _logger.LogError("log de erro");
            _logger.LogCritical("log de problema critico"); // ameaça a perfomance e saude da aplicação


            return "Sou a V2";
        }
    }
}
