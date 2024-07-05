using Data;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProcesoManager : ProcesoData
    {
        public ProcesoManager(string constring) : base(constring) 
        {
        }
        public List<Proceso> GetListaProceso(Proceso proceso)
        {
            List<Proceso> listaProceso = new List<Proceso>();
            listaProceso=GetProceso(proceso);
            return listaProceso;
        }
        
    }
}
