using MySql.Data.MySqlClient;
using System.Data;

namespace FilmesApi.Data;

public class DbSession : IDisposable
{
    public IDbConnection Connection { get; }

    public DbSession(IConfiguration configuration)
    {
        // Ele busca a string "DefaultConnection" que acabamos de ajustar no JSON
        Connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
        
        // Abre a conexão automaticamente ao criar a sessão
        Connection.Open();
    }

    // Quando a requisição termina, o .NET chama o Dispose e fecha o banco sozinho
    public void Dispose()
    {
        Connection.Close();
        Connection.Dispose();
    }
}