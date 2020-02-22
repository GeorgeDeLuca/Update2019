using System;

// esta classe não é um model, não é uma entidade do negocio, é apenas um modelo auxiliar para povoar as telas
namespace SalesWebMVC.Models.ViewModes
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}