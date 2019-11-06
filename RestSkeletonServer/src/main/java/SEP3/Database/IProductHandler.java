package SEP3.Database;

import SEP3.Shared.Product;

import javax.jws.WebMethod;
import javax.jws.WebService;
import java.sql.SQLException;
import java.util.List;

@WebService
public interface IProductHandler
{
    @WebMethod List<Product> getProducts() throws SQLException;
    @WebMethod Product getProduct(int id) throws SQLException;
}
