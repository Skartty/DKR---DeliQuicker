﻿namespace ProjetoDKR.Entidades
{
    public class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }

        public MySQL.LoginUsuario LoginUsuario
        {
            get => default;
            set
            {
            }
        }

        public MySQL.Perfil Perfil
        {
            get => default;
            set
            {
            }
        }
    }
}
