using Api.Businness.Repository;
using Api.Entity.Entity;
using Api.Entity.Entity.Settings;
using Api.Entity.Response;
using Api.Logger;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Businness.Manager
{
    public interface IManagerReporte
    {
        ResponseReporte reporteCuenta(string nroCuenta);
    }
    public class ManagerReporte : IManagerReporte
    {
        private ICuentasRepository _repository;

        private readonly dataBaseEntity _dataBase;
        private static readonly string _sectionDataBase = "dataBase";

        private readonly ILogger _logger;

        public ManagerReporte(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;

            _dataBase = new dataBaseEntity();
            configuration.GetSection(_sectionDataBase).Bind(_dataBase);

            _repository = new CuentasRepository(_dataBase);
        }

        public ResponseReporte reporteCuenta(string nroCuenta)
        {
            try
            {
                ResponseReporte reporte = new ResponseReporte();
                var response = _repository.selectCuenta(nroCuenta);
                reporte.nroCuenta=response.nroCuenta;
                reporte.tipo = response.tipo;
                reporte.moneda = response.moneda;
                reporte.nombre = response.nombre;
                reporte.saldo = response.saldo;

                #region PDF
                var htmlCode = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Templates\\Reporte.html");

                SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
                //SelectPdf.PdfDocument doc = converter.ConvertHtmlString(htmlCode);
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString("<h1>PDF PRUEBA</h1>" +
                    $"<h2>Cuenta =>{JsonConvert.SerializeObject(response)}</h2>");

                //doc.Save($"Cuenta-{DateTime.Now.ToString("HHmmss")}.pdf");
                byte[] data = doc.Save();
                var result = Convert.ToBase64String(data );
                doc.Close();
                reporte.pdfBase64 = result;
                #endregion

                return reporte;
            }
            catch (Exception ex)
            {
                _logger.Error($"[selectCuenta] Error: {ex.Message}");
                throw ex;
            }
        }
    }
}
