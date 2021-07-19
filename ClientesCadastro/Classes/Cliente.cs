using System.ComponentModel;


namespace ClientesCadastro.Classes
{
    public partial class Cliente
    {
        //public string Nome { get; set; }
        private string nome;
        [DisplayName("Nome do Cliente")]
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {               
                nome = value;              
            }
        }

        //public int? Tipo { get; set; }
        private string telefone;
        [DisplayName("Telefone")]
        public string Telefone
        {
            get
            {
                return telefone;
            }
            set
            {
                telefone = value;                
            }
        }


        private string email;
        [DisplayName("Email")]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;                
            }
        }

        private int id;
        [Browsable(false)]
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}

    
