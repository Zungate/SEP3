package SEP3.Database;
import java.sql.*;

public class DatabaseConnect
{
    private String url = "jdbc:postgresql://localhost:5432/SEP3?currentSchema=SEP3";

    public DatabaseConnect()
    {
        try {
            Class.forName("org.postgresql.Driver");
        }
        catch (Exception e) {
            System.out.println(e);
        }
    }

    public Connection connect() throws SQLException {
        String user = "postgres";
        String password = "password";

        return DriverManager.getConnection(url, user, password);
    }
}
