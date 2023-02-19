
using CityEvent.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityEvent.Service.Service
{
    public class CityEventService:ICityEventService
    {
       //Consultar Eventos por titulo

        public void ConsultarEventoPorNome(string nomeEvento)
        {

        }

        //Consultar Eventos por data e local

        public void ConsultarEventoPorDataLocal(DateTime data, string local)
        {

        }

        //Consutar Eventos por data e preço

        public void ConsultarEventoPorDataPreco(DateTime data, decimal preco)
        {

        }

        //Adicionar um novo Evento

        public void AdicionarNovoEvento(object obj)
        {

        }

        //Alterar um Evento ja criado
        public void AlterarEvento(long id,object obj)
        {

        }

        //Deletar um Evento cadastrado
        public void ApagarEvento(long id)
        {

        }

    }
}
