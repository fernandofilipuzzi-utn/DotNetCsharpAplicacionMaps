using MapsDAO.DAO;
using MapsModels.Models;
using MapsSQLiteDaoImpl.Impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsServices.Services
{
    public class MapsServicesManager
    {
        public IEntregasDAO entregasDAO { get; set; }
        public IZonasDAO zonasDAO { get; set; }
        
        public MapsServicesManager(string path)
        {
            entregasDAO = new EntregasSQLiteDaoImpl(path);
            zonasDAO = new ZonasSQLiteDaoImpl(path);
        }

        public MapsServicesManager()
        {
            entregasDAO = new EntregasSQLiteDaoImpl();
            zonasDAO = new ZonasSQLiteDaoImpl();
        }
    }
}
