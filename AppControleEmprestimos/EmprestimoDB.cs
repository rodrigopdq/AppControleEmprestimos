using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public class EmprestimoDB
{
    private string conexao;

    // Construtor que busca a string de conexão do arquivo App.config
    public EmprestimoDB()
    {
        this.conexao = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
    }

    // Método para Incluir um novo Empréstimo no Banco (Com uso de parâmetros contra SQL Injection)
    public void IncluirEmprestimo(Emprestimo emp)
    {
        MySqlConnection cn = new MySqlConnection(conexao);
        MySqlCommand cmd = cn.CreateCommand();

        cmd.CommandText = "INSERT INTO Emprestimos (item, amigo, contato, data_emprestimo, data_devolucao_combinada, status) " +
                          "VALUES (@item, @amigo, @contato, @data_emp, @data_comb, @status)";

        // Adicionando parâmetros para segurança (Critério exigido pelo professor)
        cmd.Parameters.AddWithValue("@item", emp.getItem());
        cmd.Parameters.AddWithValue("@amigo", emp.getAmigo());
        cmd.Parameters.AddWithValue("@contato", emp.getContato());
        cmd.Parameters.AddWithValue("@data_emp", emp.getDataEmprestimo());
        cmd.Parameters.AddWithValue("@data_comb", emp.getDataDevolucaoCombinada());
        cmd.Parameters.AddWithValue("@status", emp.getStatus());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new ApplicationException("Erro ao inserir empréstimo: " + ex.ToString());
        }
        finally
        {
            cn.Close();
        }
    }

    // Método para Listar os Empréstimos (Retorna um DataTable para preencher a tela)
    public DataTable getEmprestimos()
    {
        MySqlConnection cn = new MySqlConnection(conexao);
        MySqlCommand cmd = cn.CreateCommand();
        MySqlDataAdapter da;

        cmd.CommandText = "SELECT * FROM Emprestimos";

        try
        {
            cn.Open();
            cmd.Connection = cn;
            da = new MySqlDataAdapter(cmd);
            DataTable dtEmprestimos = new DataTable();
            da.Fill(dtEmprestimos);
            return dtEmprestimos;
        }
        catch (MySqlException ex)
        {
            throw new ApplicationException("Erro ao buscar empréstimos: " + ex.ToString());
        }
        finally
        {
            cn.Close();
        }
    }
}