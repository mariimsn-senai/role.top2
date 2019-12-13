namespace RolêTopMVC.ViewModels
{
    public class RespostasViewModel : BaseViewModel
    {
        public string Mensagem {get;set;}

        public RespostasViewModel()
        {

        }

        public RespostasViewModel(string mensagem)
        {
            this.Mensagem = mensagem;
        }
    }

}