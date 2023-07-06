using System;
using Npgsql;
using Dapper;
using System.Collections.Generic;
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

            //var sql = @"CREATE TABLE m_product(
            //id int primary key,
            //product_name varchar(100),
            //product_price int,
            //stock int)";

            //var insert = @"INSERT INTO m_product (id , product_name,product_price,stock)
            //VALUES (2,'Kemeja',2000000,10)";
            //connection.Execute(insert);

            var select = "SELECT * FROM m_product";

          var products = connection.Query(select).ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
