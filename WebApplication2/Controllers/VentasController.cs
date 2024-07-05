using Microsoft.AspNetCore.Mvc;
using Data;
using Business;
using Rotativa.AspNetCore;

namespace WebApplication2.Controllers
{
    public class VentasController : Controller
    {
        string? IdUsuario = "0";
        public IActionResult Index()
        {
            IdUsuario = HttpContext.Session.GetString("IdUsuario");
            if (IdUsuario == null || IdUsuario == "0")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                HttpContext.Session.SetString("IdUsuario",IdUsuario);
                string cadena = Config.GetConString();
                /*--Trae ViewBags de listados--*/
                ClienteManager cliente = new ClienteManager(cadena);
                ProcesoManager proceso = new ProcesoManager(cadena);
                TiposPrendaManager prendas = new TiposPrendaManager(cadena);
                TelasManager telas = new TelasManager(cadena);
                AdicionesManager adiciones = new AdicionesManager(cadena);
                ViewBag.listaProceso = proceso.GetListaProceso(new Proceso());
                ViewBag.listaTipoPrenda = prendas.GetListaTiposPrendas(new TiposPrenda());
                ViewBag.listaTelas = telas.GetListaTelas(new Telas());
                ViewBag.listaAdiciones = adiciones.GetListaAdiciones(new Adiciones());
                ViewBag.listaClientes = cliente.GetCliente(new Cliente());
                /*--Fin ViewBags Listados--*/
                return View();
            }
        }
        public IActionResult DetalleVentas(Ventas ventas)
        {
            string cadena = Config.GetConString();
            VentasManager manager = new VentasManager(cadena);
            Ventas venta = new Ventas();
            if (ventas == null)
            {

                venta = manager.listaVentas(new Ventas()).FirstOrDefault();
            }
            else
            {
                venta = manager.listaVentas(ventas).FirstOrDefault();
            }
            if (venta == null)
            {
                venta = new Ventas();
            }
            return PartialView(venta);
        }
        public IActionResult DetalleVentasDinamicas(Ventas ventas, string procesoDescripcion, string tiposPrendaDescripcion, string telasDescripcion, string adicionDescripcion)
        {
            ventas.adicion.Id = ventas.AdicionId;
            ventas.adicion.Descripcion = adicionDescripcion;
            ventas.proceso.Id = ventas.ProcesoId;
            ventas.proceso.Descripcion = procesoDescripcion;
            ventas.tiposPrenda.Id = ventas.TiposPrendaId;
            ventas.tiposPrenda.Descripcion = tiposPrendaDescripcion;
            ventas.telas.Id = ventas.TelasId;
            ventas.telas.Descripcion = telasDescripcion;
            if (ventas == null)
            {
                ventas = new Ventas();
            }
            return PartialView(ventas);
        }
        public IActionResult ListaVentas()
        {
            string cadena = Config.GetConString();
            List<Ventas> listaVentas = new List<Ventas>();
            VentasManager manager = new VentasManager(cadena);
            listaVentas = manager.listaVentas(new Ventas());
            return PartialView(listaVentas);
        }
        //public JsonResult GuardarVentas(Ventas ventas)
        //{
        //    int resultado = new int();
        //    string cadena = Config.GetConString();
        //    VentasManager manager = new VentasManager(cadena);
        //    if (String.IsNullOrEmpty(ventas.Id.ToString()))
        //    {
        //        resultado = manager.InsertarVenta(ventas);
        //    }
        //    else
        //    {
        //        ventas.FechaModificacion = DateTime.Now;
        //        manager.ActualizarVentas(ventas);
        //        resultado = (int)ventas.Id;
        //    }
        //    return Json(resultado);
        //}
        public int GuardarVentas(Factura factura, List<Ventas> ventas)
        {
            IdUsuario = HttpContext.Session.GetString("IdUsuario");
            int idFactura = new int();
            string cadena = Config.GetConString();
            FacturaManager facturaManager = new FacturaManager(cadena);
            VentasManager manager = new VentasManager(cadena);
            factura.UsrIdCreo = Convert.ToInt16(IdUsuario);
            idFactura = facturaManager.GuardarFactura(factura);
            if (!String.IsNullOrEmpty(idFactura.ToString()))
            {
                foreach (Ventas venta in ventas)
                {
                    venta.UsuarioIdCreo=Convert.ToInt16(IdUsuario);
                    venta.Estado = true;
                    venta.FacturaId = idFactura;
                    manager.InsertarVenta(venta);
                }
            }
            return idFactura;
        }
        public void EliminarVentas(Ventas ventas)
        {
            string cadena = Config.GetConString();
            VentasManager manager = new VentasManager(cadena);
            manager.EliminarVentas(ventas);
        }
    }
}
