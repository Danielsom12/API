using ApiIp.Dtos;
using ApiIp.Interfaces;
using MySqlConnector;

namespace ApiIp.Repository;

public class IpLogRepository : IpInterfaceLogRepository
{
    private readonly string _connectionString;

    public IpLogRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task RegistrarAsync(string ip, IpResponse? dados)
    {
        const string query = @"
            INSERT INTO LOGS.Ips
                (IP, Provedor, Pais, CEP, Latitude, Longitude, fl_is_mobile, fl_is_vpn, fl_is_tor, fl_is_provy, fl_is_datacenter)
            VALUES
                (@IP, @Provedor, @Pais, @CEP, @Latitude, @Longitude, @fl_is_mobile, @fl_is_vpn, @fl_is_tor, @fl_is_provy, @fl_is_datacenter);";

        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@IP", ip);
        command.Parameters.AddWithValue("@Provedor", (object?)dados?.Provedor ?? DBNull.Value);
        command.Parameters.AddWithValue("@Pais", (object?)dados?.Pais ?? DBNull.Value);
        command.Parameters.AddWithValue("@CEP", (object?)dados?.CEP ?? DBNull.Value);
        command.Parameters.AddWithValue("@Latitude", (object?)dados?.Latitude.ToString() ?? DBNull.Value);
        command.Parameters.AddWithValue("@Longitude", (object?)dados?.Longitude.ToString() ?? DBNull.Value);
        command.Parameters.AddWithValue("@fl_is_mobile", (object?)dados?.Mobile ?? DBNull.Value);
        command.Parameters.AddWithValue("@fl_is_vpn", (object?)dados?.Vpn ?? DBNull.Value);
        command.Parameters.AddWithValue("@fl_is_tor", (object?)dados?.Tor ?? DBNull.Value);
        command.Parameters.AddWithValue("@fl_is_provy", (object?)dados?.Proxy ?? DBNull.Value);
        command.Parameters.AddWithValue("@fl_is_datacenter", (object?)dados?.Datacenter ?? DBNull.Value);

        await command.ExecuteNonQueryAsync();
    }
}
