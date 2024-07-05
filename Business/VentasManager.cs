using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class VentasManager:VentasData
    {
        public VentasManager(string constring):base(constring)
        {
        }
        public List<Ventas> listaVentas(Ventas ventas) 
        {
            return GetVentas(ventas);
        }
        public int InsertarVenta(Ventas ventas)
        {
            var resultado = 0;
            resultado = InsertVenta(ventas);
            return resultado;
        }
        public void EliminarVentas(Ventas ventas)
        {
            DeleteVenta(ventas);
        }
        public void ActualizarVentas(Ventas ventas)
        {
            UpdateVenta(ventas);
        }
    }
}
