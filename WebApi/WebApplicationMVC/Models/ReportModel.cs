using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApplicationMVC.Models
{
    public class Data
    {        
        public IEnumerable<ReportModel> report { get; set; }
    } 

    public class ReportModel
    {
        public int IdCliente { get; set; }
        public DateTime FechaRegistroEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Sucursal { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int IdViaje { get; set; }
    }
}