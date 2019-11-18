package SEP3.Database;

import SEP3.Shared.Product;

import javax.ws.rs.*;
import java.io.*;
import java.net.Socket;
import java.net.UnknownHostException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import static javax.ws.rs.core.MediaType.APPLICATION_JSON;

@Path("/products")
public class ProductHandler extends DatabaseConnect implements IProductHandler
{

    public List<Product> getProducts(String sql, Object... values) throws SQLException
    {
        List<Product> products = new ArrayList<>();
        try (Connection connection = connect())
        {
            try (PreparedStatement statement = connection.prepareStatement(sql))
            {
                for (int i = 0; i < values.length; i++)
                {
                    statement.setObject(i + 1, values[i]);
                }
                ResultSet result = statement.executeQuery();
                while (result.next())
                {
                    int id = result.getInt("id");
                    String title = result.getString("title");
                    String url = result.getString("url");
                    String size = result.getString("size");

                    products.add(new Product(id, title, url, size));
                }
            }
            connect().close();
            return products;
        }
    }


    @Override
    @GET
    @Produces(APPLICATION_JSON)
    public List<Product> getProducts() throws SQLException
    {
        return getProducts("SELECT * FROM Product ORDER BY title");
    }

    @Override
    @GET
    @Path("{id}")
    @Produces(APPLICATION_JSON)
    public Product getProduct(@PathParam("id") int id) throws SQLException
    {
        List<Product> products = getProducts("SELECT * FROM Product where id =?", id);
        connect().close();
        if(products.isEmpty())
            return null;
        else
            return products.get(0);
    }



    @Override
    @POST
    @Path("/buy")
    @Consumes(APPLICATION_JSON)
    @Produces(APPLICATION_JSON)
    public void buyCart(Product product) throws SQLException
    {
        String serverName = "localhost";
        try {

            System.out.println("Connecting to " + serverName);
            Socket client = new Socket(serverName, 9777);

            System.out.println("Forbundet...");
            OutputStream outputStream = client.getOutputStream();
            DataOutputStream out = new DataOutputStream(outputStream);

            out.writeUTF("Hej fra buy: " + product.getTitle());

            InputStream inFromServer = client.getInputStream();
            DataInputStream in = new DataInputStream(inFromServer);

            System.out.println("Server siger");

        } catch (UnknownHostException e)
        {
            e.printStackTrace();
        } catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    @Override
    @GET
    @Path("/get10")
    @Produces(APPLICATION_JSON)
    public List<Product> get10Products() throws SQLException
    {
        return getProducts("SELECT * FROM Product LIMIT 10");
    }
}
