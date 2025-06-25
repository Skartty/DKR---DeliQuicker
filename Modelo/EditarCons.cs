using ProjetoDKR.Entidades;

namespace ProjetoDKR.Model
{
    public class EditarCons
    {
        public bool Editar { get; set; }
        public PerfilCons Perfil { get; set; }

        public TelaUsuarioCons TelaUsuarioCons
        {
            get => default;
            set
            {
            }
        }
    }
}
