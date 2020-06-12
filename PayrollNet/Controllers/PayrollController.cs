using Payroll.BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace PayrollNet.Controllers
{
    [RoutePrefix("api/Payroll")]
    public class PayrollController : ApiController
    {
        private FileManagementService _fMS = new FileManagementService();


        [HttpGet]
        [Route("GenPay")]
        public IHttpActionResult GeneratePayrollFile()
        {
            try
            {
                _fMS.GenerateOutPutJsonFile();
                var mensaje = $"El archivo con el nombre: asientos.json fue generado.";
                return Ok(mensaje);
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("ReadPay")]
        public HttpResponseMessage ReadPayrollFile()
        {
            var data = _fMS.GetOutPutJsonFile();
            return new HttpResponseMessage()
            {
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };
        }
    }
}

