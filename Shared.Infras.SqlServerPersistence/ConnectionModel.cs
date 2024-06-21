namespace Shared.Infras.SqlServerPersistence;

public class ConnectionModel
{
    public required string Server { get; init; }
    public required string Port { get; init; }
    public required string Database { get; init; }
    public required string UserId { get; init; }
    public required string Password { get; init; }
    public required bool TrustServerCertificate { get; init; } = true;

    public string GetConnectionString()
        => $"""
            Server={Server},{Port};
            Database={Database};
            User Id={UserId};
            Password={Password};
            TrustServerCertificate={TrustServerCertificate.ToString()};
            """;
}