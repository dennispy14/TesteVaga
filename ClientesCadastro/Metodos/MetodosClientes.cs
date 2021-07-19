using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClientesCadastro.Classes
{
    
    public partial class Cliente
    {
        
        public void Insert()
        {
            
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Clientes;Trusted_Connection=True;"))
            {

                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Insert Into Cliente (nome, telefone, email) Values (@nome, @telefone, @email)";
                    cmd.Connection = cn;

                   
                    cmd.Parameters.AddWithValue("@nome", this.nome);
                    cmd.Parameters.AddWithValue("@telefone", this.telefone);
                    cmd.Parameters.AddWithValue("@email", this.email);

                    try
                    {
                        cmd.ExecuteNonQuery();                       
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public void Update()
        {
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Clientes;Trusted_Connection=True;"))
            {

                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Update Cliente Set nome = @nome, telefone = @telefone, email = @email Where ID = @ID";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@ID", this.ID);
                    cmd.Parameters.AddWithValue("@nome", this.nome);
                    cmd.Parameters.AddWithValue("@telefone", this.telefone);
                    cmd.Parameters.AddWithValue("@email", this.email);

                    cmd.ExecuteNonQuery();
                
                }
            }
        }        
        public void Apagar()
        {

            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Clientes;Trusted_Connection=True;"))
            {

                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Delete From Cliente Where nome = @nome";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@nome", this.nome);
                 
                    try
                    {
                        cmd.ExecuteNonQuery();
                        
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }


            }

        }
        public static List<Cliente> Filtra(string filtro)
        {

            List<Cliente> _return = null;

            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Clientes;Trusted_Connection=True;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * from Cliente where nome = @nome";

                    cmd.Parameters.AddWithValue("@nome", filtro);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Cliente cli = new Cliente();
                                cli.nome = dr.GetString(dr.GetOrdinal("nome"));
                                cli.telefone = dr.GetString(dr.GetOrdinal("telefone"));
                                cli.email = dr.GetString(dr.GetOrdinal("email"));
                                cli.id = dr.GetInt32(dr.GetOrdinal("ID"));

                                if (_return == null)
                                    _return = new List<Cliente>();

                                _return.Add(cli);
                            }
                        }
                    }
                }
            }

            return _return;
        }
        public static List<Cliente> Todos()
        {

            List<Cliente> _return = null;

            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Clientes;Trusted_Connection=True;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * from Cliente";
                    

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while(dr.Read())
                            {
                                Cliente cli = new Cliente();                                
                                cli.nome = dr.GetString(dr.GetOrdinal("nome"));
                                cli.telefone = dr.GetString(dr.GetOrdinal("telefone"));
                                cli.email = dr.GetString(dr.GetOrdinal("email")); 
                                cli.id = dr.GetInt32(dr.GetOrdinal("ID"));

                                if (_return == null)
                                    _return = new List<Cliente>();                                

                                _return.Add(cli);
                            }
                        }
                    }                   
                }
            }

            return _return;
        }
        public Cliente(string nome, string telefone, string email)
        {            
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;            
        }        
        public Cliente()
        {

        }

    }
}
