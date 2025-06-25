namespace ProjetoDKR.Model
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public MySQL.LoginUsuario LoginUsuario
        {
            get => default;
            set
            {
            }
        }
    }
}
