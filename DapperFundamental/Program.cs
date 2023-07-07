using System;
using Npgsql;
using Dapper;
using System.Linq;

namespace DapperFundamental
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             Dapper adalah ORM(micro ORM) yang memungkinkan kita untuk mengakses data
            lebih cepat dan memapping object


            Keunggulan Dapper
            -Dapper ringan dan cepat
            -Dapper ini mudah digunakan dan object mapping yang powerfull
            - Dapper mendukung yang namanya parameterized queries yang membantu kita untuk menghindari
            yang namanya SQL Injection

            Tujuan utama Dapper me-mapping queries ke object

            Dapper RDBMS(Provider): SQL Server,Oracle,PostgreSQL, MySQL
             */

            /*
             4 Method extention IDBConnection:
            - Query(DQL)
            - Execute (DDL, DML)
            - Execute Scalar (DML , DQL) - Mengambalikan satu record dan satu column
            - Execute Reader (DQL)
             
             */

            var connString = "Host=localhost;Username=postgres;Password=blimbeng38;Database=enigma_shop";
            using var connection = new NpgsqlConnection(connString);
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            //var sql = @"CREATE TABLE m_product(
            //id int primary key,
            //product_name varchar(100),
            //product_price int,
            //stock int)";

            //var insert = @"INSERT INTO m_product (id , product_name,product_price,stock)
            //VALUES (2,'Kemeja',2000000,10)";
            //connection.Execute(insert);

            /* var select = "SELECT * FROM m_product;";

            var products = connection.Query<Product>(select).ToList();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            */

            /*
            Menampilkan Single Data:
            - QuerySingle - Dynamic                     = Mengembalikan sat data berupa dynamic - Exception saat query kosong atau data lebih dari satu
            - QuerySingle<T>                    
            - QuerySingleOrDefault - Dynamic            = Mengambalikan saty data berupa dynamic - Exception saat query lebih dari satu data , kalau query kosong akan return null
            - QuerySingleOrDefault<T>
            - QueryFirst - Dynamic                      = Mengambalikan satu data berupa dynamic - Exception saat query itu kosong
            - QueryFirst<T>
            - QueryFirstOrDefault - Dynamic             = Mengembalikan satu kata berupa dynamic - tidak mengembalikan exception apapun, kalau query ksosong akan return null
            - QueryFirstOrDefault<T>


            var selectOne = "SELECT * FROM m_product WHERE id = 2";
            var product = connection.QueryFirstOrDefault<Product>(selectOne);

            Console.WriteLine(product);

             */

            /* Execute Scallar
              
             var selectAgregat = "Select count(id) from m_product GROUP BY product_name";
             var selectName = "Select product_name from m_product";

             var count = connection.ExecuteScalar<int>(selectAgregat);
             var name = connection.ExecuteScalar<string>(selectName);

             Console.WriteLine(name);
            */

            /* Execute Reader
            var select = "SELECT * FROM m_product";

            var reader = connection.ExecuteReader(select);

            while (reader.Read())
            {
                Console.WriteLine(new Product
                {
                    Id = Convert.ToInt32(reader["id"]),
                    ProductName = reader["product_name"].ToString(),
                    ProductPrice = Convert.ToInt32(reader["product_price"]),
                    Stock = Convert.ToInt32(reader["stock"]),
                });
            }
            */

            /*
             Parameter Dapper
            - Anonymous Parameters
            - Dynamic Parameters

            var product = new Product {
                Id = 5,
                ProductName = "Tas",
                ProductPrice = 200000,
                Stock = 21
            };

            // Anonymous Parameter with Anonymous Object
            var productParams = new
            {
                id = product.Id,
                productName = product.ProductName,
                productPrice = product.ProductPrice,
                stock = product.Stock
            };

            //Dynamic Parameters
            var dynamicParameters = new DynamicParameters(product);

            var sql = @"INSERT INTO m_product (id , product_name, product_price, stock)
                VALUES (@id, @productName, @productPrice, @stock)";
            connection.Execute(sql, product);

             */

            var sql = "SELECT * FROM m_product WHERE product_price > @productPrice";
            var products = connection.Query<Product>(sql, new
            {
                productPrice = 100000
            }).ToList();

            products.ForEach(Console.WriteLine);


        }
    }
}
