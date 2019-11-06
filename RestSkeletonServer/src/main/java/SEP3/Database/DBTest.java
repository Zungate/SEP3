package SEP3.Database;

import SEP3.Shared.Product;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class DBTest extends DatabaseConnect
{
    public static void main(String[] args) throws SQLException
    {
        ProductHandler handler = new ProductHandler();

        for(Product product: handler.getProducts())
        {
            System.out.println(product.getTitle());
        }
    }
}
