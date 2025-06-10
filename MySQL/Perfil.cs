using ProjetoDKR.Entidades;

namespace ProjetoDKR.MySQL
{
    public class Perfil
    {
        public Perfil()
        {
             
        }

        public PerfilCons BuscarPerfilCons(int idCons)
        {
            //Banco Fictício de Perfis de Consumidores
            /*
            List<PerfilCons> cons = new List<PerfilCons>();
            cons.Add(new PerfilCons()
            {
                Id = 1,
                IdLogin = 1,
                Nome = "Isabella Braga",
                CNPJ = "12.345.678/0001-23",
                Email = "Usuario.Teste@gmail.com",
                Senha = "123564646",
                Telefone = "19999999999",
                CEP = "11111111",
                Numero = "123",
                Endereco = "Rua das Flores Verdes",
                Complemento = "Casa B",
                Transporte = false
            });
            
            cons.Add(new PerfilCons()
            {
                Id = 2,
                IdLogin = 3,
                Nome = "Isabella Braga2",
                CNPJ = "12.345.678/0001-23",
                Email = "Usuario.Teste@gmail.com",
                Senha = "123564646",
                Telefone = "19999999999",
                CEP = "11111111",
                Numero = "123",
                Endereco = "Rua das Flores Verdes",
                Complemento = "Casa B",
                Transporte = false
            });


            if (cons.Any(a => a.IdLogin == idCons))
            {
                return cons.Where(w => w.IdLogin == idCons).First();
            }
            */
            return null;
        }

        public PerfilCons EditarPerfilCons(PerfilCons perfil)
        {
            //Banco Fictício de Perfis de Consumidores
            /*
            List<PerfilCons> cons = new List<PerfilCons>();
            cons.Add(new PerfilCons()
            {
                Id = 1,
                IdLogin = 1,
                Nome = "Isabella Braga",
                CNPJ = "12.345.678/0001-23",
                Email = "Usuario.Teste@gmail.com",
                Senha = "123564646",
                Telefone = "19999999999",
                CEP = "11111111",
                Numero = "123",
                Endereco = "Rua das Flores Verdes",
                Complemento = "Casa B",
                Transporte = false
            });
            
            cons.Add(new PerfilCons()
            {
                Id = 2,
                IdLogin = 3,
                Nome = "Isabella Braga2",
                CNPJ = "12.345.678/0001-23",
                Email = "Usuario.Teste@gmail.com",
                Senha = "123564646",
                Telefone = "19999999999",
                CEP = "11111111",
                Numero = "123",
                Endereco = "Rua das Flores Verdes",
                Complemento = "Casa B",
                Transporte = false
            });


            if (perfil != null)
            {
                var perfilEditar = cons.Where(w => w.Id == perfil.Id).FirstOrDefault();
                if(perfilEditar != null)
                {
                    perfilEditar.Nome = perfil.Nome;
                    perfilEditar.CNPJ = perfil.CNPJ;
                    perfilEditar.Telefone = perfil.Telefone;
                    perfilEditar.Email = perfil.Email;
                    perfilEditar.Senha = perfil.Senha;
                    perfilEditar.CEP = perfil.CEP;
                    perfilEditar.Numero = perfil.Numero;
                    perfilEditar.Endereco = perfil.Endereco;
                    perfilEditar.Complemento = perfil.Complemento;
                    perfilEditar.Transporte = perfil.Transporte;
                }
            }
            */
            return null;
        }

        public PerfilForn BuscarPerfilForn(int idForn)
        {
            //Banco Fictício de Perfis de Fornecedores
            /*
            List<PerfilForn> forn = new List<PerfilForn>();
            forn.Add(new PerfilForn()
            {
                Id = 1,
                IdLogin = 1,
                CNPJ = "12.345.678/0001-23",
                RazaoSocial = "RMB",
                NomeFantasia = "Isabella ",
                Email = "Usuario.Teste@gmail.com",
                Senha = "123564646",
                Telefone = "19999999999",
                CEP = "11111111",
                Numero = "123",
                Endereco = "Rua das Flores Verdes",
                Complemento = "Casa B",
                Categoria = "Mercado",
                Transporte = false
            });

            forn.Add(new PerfilForn()
            {
                Id = 2,
                IdLogin = 2,
                CNPJ = "12.345.678/0001-23",
                RazaoSocial = "kaka",
                NomeFantasia = "Braga",
                Email = "Usuario.Teste@gmail.com",
                Senha = "123564646",
                Telefone = "19999999999",
                CEP = "11111111",
                Numero = "123",
                Endereco = "Rua das Flores Verdes",
                Complemento = "Casa B",
                Categoria = "Restaurante",
                Transporte = true
            });


            if (forn.Any(a => a.IdLogin == idForn))
            {
                return forn.Where(w => w.IdLogin == idForn).First();
            }
            */
            return null;
        }

        public PerfilForn EditarPerfilForn(PerfilForn perfil)
        {
            //Banco Fictício de Perfis de Fornecedores
            /*
            List<PerfilForn> Forn = new List<PerfilForn>();
            Forn.Add(new PerfilForn()
            {
                Id = 1,
                IdLogin = 1,
                CNPJ = "12.345.678/0001-23",
                RazaoSocial = "RMB",
                NomeFantasia = "Isabella ",
                Email = "Usuario.Teste@gmail.com",
                Senha = "123564646",
                Telefone = "19999999999",
                CEP = "11111111",
                Numero = "123",
                Endereco = "Rua das Flores Verdes",
                Complemento = "Casa B",
                Categoria = "Mercado",
                Transporte = false
            });
            
            Forn.Add(new PerfilForn()
            {
                Id = 2,
                IdLogin = 3,
                CNPJ = "12.345.678/0001-23",
                RazaoSocial = "kaka",
                NomeFantasia = "Braga",
                Email = "Usuario.Teste@gmail.com",
                Senha = "123564646",
                Telefone = "19999999999",
                CEP = "11111111",
                Numero = "123",
                Endereco = "Rua das Flores Verdes",
                Complemento = "Casa B",
                Categoria = "Restaurante",
                Transporte = true
            });


            if (perfil != null)
            {
                var perfilEditar = Forn.Where(w => w.Id == perfil.Id).FirstOrDefault();
                if(perfilEditar != null)
                {
                    perfilEditar.CNPJ = perfil.CNPJ;
                    perfilEditar.RazaoSocial = perfil.RazaoSocial;
                    perfilEditar.NomeFantasia = perfil.NomeFantasia;
                    perfilEditar.Telefone = perfil.Telefone;
                    perfilEditar.Email = perfil.Email;
                    perfilEditar.Senha = perfil.Senha;
                    perfilEditar.CEP = perfil.CEP;
                    perfilEditar.Numero = perfil.Numero;
                    perfilEditar.Endereco = perfil.Endereco;
                    perfilEditar.Complemento = perfil.Complemento;
                    perfilEditar.Categoria = perfil.Categoria;
                    perfilEditar.Transporte = perfil.Transporte;
                }
            }
            */
            return null;
        }
    }
}
