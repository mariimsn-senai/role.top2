using System;

namespace RolêTopMVC.Models
{
    public class Agendamento : Produto
    {
        public Agendamento(string data, string horario)
        {
            this.data = data;
            this.horario = horario;
        }

    }
}