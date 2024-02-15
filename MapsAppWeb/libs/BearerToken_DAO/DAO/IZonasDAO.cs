using MapsModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsDAO.DAO
{
    public interface IZonasDAO
    {
        Zona Agregar(Zona Nuevo, int idCredencial);
        void Actualizar(Zona Nuevo);
        void Eliminar(int id);
        //
        Zona BuscarPorId(int id);
        DataSet BuscarTodos();
    }
}
