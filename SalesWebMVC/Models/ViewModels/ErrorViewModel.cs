using System;

// esta classe n�o � um model, n�o � uma entidade do negocio, � apenas um modelo auxiliar para povoar as telas
namespace SalesWebMVC.Models.ViewModes
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}