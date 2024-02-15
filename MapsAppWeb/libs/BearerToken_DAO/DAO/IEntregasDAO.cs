using MapsModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsDAO.DAO
{
    public interface IEntregasDAO
    {
        Entrega Agregar(Entrega Nuevo);
        void Actualizar(Entrega Nuevo);
        void Eliminar(int id);
        //
        Entrega BuscarPorId(int id);
        DataSet BuscarTodos();
    }
}
