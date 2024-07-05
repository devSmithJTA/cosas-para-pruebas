using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClienteManager:ClienteData
    {
        public ClienteManager(string constring) : base(constring) 
        {
        }
        public List<Cliente> ListaClientes(Cliente cliente) 
        {
            return GetCliente(cliente);
        }
        public int InsertarCliente(Cliente cliente)
        {
            int result = InsertCliente(cliente);
            return result;
        }
        public void ActualizarCliente(Cliente cliente)
        {
            UpdateCliente(cliente);
        }
        public int ConteoCliente() 
        {
            int NumeroCliente = CountCliente();
            return NumeroCliente;
        }
    }
}
