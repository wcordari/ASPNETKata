using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ASPNETKata.Shared;


namespace ASPNETKata.Shared
{

    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _connection.Query<Product>("SELECT * from product ORDER By ProductId DESC");
        }

        public void DeleteProduct(int productId)
        {
            _connection.Execute("DELETE FROM Product WHERE ProductId = @id", new { id = productId });
        }

        public void UpdateProduct(Product prod)
        {
            _connection.Execute("UPDATE Product SET Name = @name WHERE ProductId = @id", new { id = prod.ProductId, name = prod.Name });
        }

        public void InsertProduct(Product prod)
        {
            _connection.Execute("INSERT into product (Name) values (@name)", new { name = prod.Name });
        }

        public Product GetDetails(int productId)
        {
            return _connection.Query<Product>("SELECT * FROM Product WHERE ProductID = @id", new { id = productId })
                .FirstOrDefault();
        }

        /*
        var cText = "INSERT into product (" + string.Join(", ", prod.Params.Keys) + ")";

        var valueKeys = prod.Params.Keys.Select(str => "@" + str);
        cText += " values (" + string.Join(", ", valueKeys) + ")";
        */
    }
}
