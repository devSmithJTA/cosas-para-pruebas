using Business;
using Data;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace WebApplication2.Controllers
{
    public class FacturaController : Controller
    {
        string? IdUsuario = "0";
        public IActionResult Index()
        {
            IdUsuario = HttpContext.Session.GetString("IdUsuario");
            if (IdUsuario == null || IdUsuario == "0")
            {
                return RedirectToAction("Index", "Login");
            }
            else { 
            HttpContext.Session.SetString("IdUsuario",IdUsuario);
            return View();
            }
        }
        //public IActionResult ObtenerFactura(Factura facturas)
        public IActionResult ObtenerFactura(int idFactura)
        {
            Factura facturas= new Factura();
            facturas.Id = idFactura;
            string cadena = Config.GetConString();
            FacturaManager manager = new FacturaManager(cadena);
            Factura factura = new Factura();
            factura = manager.ListarFactura(facturas).FirstOrDefault();
            if (factura == null)
            {
                factura = new Factura();
            }
            //return PartialView(factura);
            //return View(facturas);
            return new ViewAsPdf("ObtenerFactura", factura)
            {
                FileName = "Factura" + factura.Id + ".pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }
        public IActionResult MostrarFactura(int idFactura)
        {
            Factura facturas= new Factura();
            facturas.Id = idFactura;
            string cadena = Config.GetConString();
            FacturaManager manager = new FacturaManager(cadena);
            Factura factura = new Factura();
            factura = manager.ListarFactura(facturas).FirstOrDefault();
            if (factura == null)
            {
                factura = new Factura();
            }
            return PartialView(factura);
            //return View(facturas);

        }
        public IActionResult PVBotonImprimir(int idFactura)
        {
            ViewBag.IdFactura = idFactura;
            return PartialView();
        }
        public IActionResult ListaFactura() 
        {
            string cadena = Config.GetConString();
            List<Factura> listaFactura = new List<Factura>();
            FacturaManager manager = new FacturaManager(cadena);
            listaFactura = manager.GetListFactura(new Factura());
            return PartialView(listaFactura);
        }
        public IActionResult DetalleFactura(Factura factura, string[] prendas,string[] telas)
        {
            string cadena = Config.GetConString();
            TelasManager telaManager = new TelasManager(cadena);
            Int16? diasEntregaCompleto = 0;
            Int16? diasEntregaTelas = 0;
            Int16? diasEntregaPrenda = 0;
            TiposPrenda tiposPrenda = new TiposPrenda();
            Telas tela = new Telas();
            TiposPrendaManager prenda = new TiposPrendaManager(cadena);
            foreach (var item in prendas)
            {
                tiposPrenda = prenda.GetListaTiposPrendas(new TiposPrenda() { Id = Convert.ToInt16(item) }).FirstOrDefault();
                if(tiposPrenda.DiasEntrega>diasEntregaPrenda) diasEntregaPrenda = tiposPrenda.DiasEntrega;
            }
            foreach (var item in telas)
            {
                tela = telaManager.GetListaTelas(new Telas() { Id = Convert.ToInt16(item) }).FirstOrDefault();
                if (tela.DiasEntrega > diasEntregaTelas) diasEntregaTelas = tela.DiasEntrega;

            }
            if (tela.DiasEntrega > tiposPrenda.DiasEntrega)
            {
                diasEntregaCompleto = tela.DiasEntrega;
            }
            else 
            {
                diasEntregaCompleto = tiposPrenda.DiasEntrega;
            }
            factura.DiasEntrega = diasEntregaCompleto;
            factura.cliente = new Cliente();
            return PartialView(factura);
            //FacturaManager manager = new FacturaManager(cadena);
            //Factura facturas = new Factura();
            //facturas = manager.ListarFactura(factura).FirstOrDefault();
            //if (facturas==null)
            //{
            //    facturas = new Factura();
            //}
            //return PartialView(facturas);
        }
    }
}
