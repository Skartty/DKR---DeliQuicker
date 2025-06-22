using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace DeliQuicker.Utilidades
{
    public static class BancoInitializer
    {
        public static void InicializarBanco(string connectionStringComBanco)
        {
            try
            {
                var configSemBanco = ConfigurationManager.ConnectionStrings["ConexaoSemBanco"];
                if (configSemBanco == null)
                {
                    MessageBox.Show("Erro: string de conexão 'ConexaoSemBanco' não foi encontrada no App.config.");
                    return;
                }

                string connStrSemBanco = configSemBanco.ConnectionString;

                bool bancoExiste = false;
                using (var conn = new MySqlConnection(connStrSemBanco))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'projeto_dkr';", conn))
                    {
                        var resultado = cmd.ExecuteScalar();
                        bancoExiste = resultado != null;
                    }

                    if (!bancoExiste)
                    {
                        using (var cmd = new MySqlCommand("CREATE DATABASE projeto_dkr;", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                using (var conn = new MySqlConnection(connectionStringComBanco))
                {
                    conn.Open();

                    string script = @"
CREATE TABLE IF NOT EXISTS login (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario VARCHAR(100) NOT NULL,
    senha VARCHAR(255) NOT NULL,
    tipo ENUM('Consumidor', 'Fornecedor') NOT NULL
);

CREATE TABLE IF NOT EXISTS perfil_cons (
    id INT PRIMARY KEY AUTO_INCREMENT,
    id_login INT NOT NULL,
    nome VARCHAR(100) NOT NULL,
    cnpj CHAR(14) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    telefone VARCHAR(20),
    cep CHAR(8),
    numero VARCHAR(10),
    endereco VARCHAR(100),
    complemento VARCHAR(100),
    transporte BOOLEAN,
    FOREIGN KEY (id_login) REFERENCES login(id)
);

CREATE TABLE IF NOT EXISTS perfil_forn (
    id INT PRIMARY KEY AUTO_INCREMENT,
    id_login INT NOT NULL,
    cnpj CHAR(14) NOT NULL,
    razao_social VARCHAR(100) NOT NULL,
    nome_fantasia VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    telefone VARCHAR(20),
    cep CHAR(8),
    numero VARCHAR(10),
    endereco VARCHAR(100),
    complemento VARCHAR(100),
    categoria VARCHAR(50),
    transporte BOOLEAN,
    FOREIGN KEY (id_login) REFERENCES login(id)
);

CREATE TABLE IF NOT EXISTS produto (
    id INT PRIMARY KEY AUTO_INCREMENT,
    id_forn INT NOT NULL,
    nome_produto VARCHAR(100) NOT NULL,
    categoria VARCHAR(50),
    validade DATE,
    quantidade INT,
    descricao TEXT,
    imagem LONGBLOB,
    FOREIGN KEY (id_forn) REFERENCES perfil_forn(id)
);
";

                    using (var cmd = new MySqlCommand(script, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                InserirDadosExemplo(connectionStringComBanco);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar o banco: " + ex.Message);
            }
        }

        private static void InserirDadosExemplo(string connectionString)
        {
            string senhaHasheada = DeliQuicker.Utilidades.Hashing.HashPassword("1234");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string insert = @"
INSERT IGNORE INTO login (id, usuario, senha, tipo) VALUES 
(1, 'cons@gmail.com', @senha, 'Consumidor'),
(2, 'forn@gmail.com', @senha, 'Fornecedor');

INSERT IGNORE INTO perfil_cons (id, id_login, nome, cnpj, email, senha, telefone, cep, numero, endereco, complemento, transporte) 
VALUES (1, 1, 'Maria Consumidora', '12345678000190', 'cons@gmail.com', @senha, '1234', '12345678', '100', 'Rua A', 'Ap 1', true);

INSERT IGNORE INTO perfil_forn (id, id_login, cnpj, razao_social, nome_fantasia, email, senha, telefone, cep, numero, endereco, complemento, categoria, transporte) 
VALUES (1, 2, '98765432000190', 'Fornecedor Alimentos LTDA', 'AlimBom', 'forn@gmail.com', @senha, '1234', '87654321', '200', 'Av B', 'Bloco 2', 'Alimentos', false);

INSERT IGNORE INTO produto (id_forn, nome_produto, categoria, validade, quantidade, descricao) 
VALUES 
(1, 'Cesta Básica', 'Alimentos', '2025-12-31', 10, 'Cesta com arroz, feijão, óleo e macarrão'),
(1, 'Leite Integral', 'Laticínios', '2024-10-01', 20, 'Pacote com 12 unidades');
";

                using (MySqlCommand cmd = new MySqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@senha", senhaHasheada);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


