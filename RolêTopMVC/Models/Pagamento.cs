namespace RolêTopMVC.Models
{
    public class Pagamento : Produto
    {
        public Pagamento(string Parcelas)
        {
            this.parcelas = Parcelas;
        }
    }
}