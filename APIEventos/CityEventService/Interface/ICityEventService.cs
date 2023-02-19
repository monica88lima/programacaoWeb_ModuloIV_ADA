using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvent.Service.Interface
{
    public interface ICityEventService
    {
        public void ConsultarEventoPorNome(string nomeEvento);
        public void ConsultarEventoPorDataLocal(DateTime data, string local);

        public void ConsultarEventoPorDataPreco(DateTime data, decimal preco);

        public void AdicionarNovoEvento(object obj);

        public void AlterarEvento(long id, object obj);

        public void ApagarEvento(long id);




    }
}
