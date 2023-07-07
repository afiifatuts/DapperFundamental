using System;
using Npgsql;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace DapperFundamental
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            LINQ -> Language-Intergrated Query
            LINQ ini mendukung banyak data source :
            - In Memory Object (List, Array)
            - ADO.NET (DataSet)
            - Entity Framework
            - SQL Server
            - XML Document
            - Data Source lain lain


            Linq Providers
            - LINQ to Objects
            - LINQ to Entities
            - LINQ to XML
            - LINQ to SQL
            - LINQ to DataSet
            - dll


            3 Hal untuk Membuat Query LINQ
            - Data Source (SQL, In Memory Object, XML)
            - Query (SELECT....)
            - Execute of the query


            Kombinasi Query yang kita perlu ketahui:
            - Query Syntax
            - Method Syntax
            - Mixed Syntax


            Query Syntax
            from object in datasource // inisialisasi
            where condition // kondisi
            select object  // seleksi
             */

            //numbers -> datasource(in memory object)
            var numbers = new List<int> { 2, 3, 4, 5, 6, 7 };

            var querySyntax =
                from number in numbers // inisialisasi
                where number > 5 //kondisi
                select number; //seleksi



            //foreach( var i in querySyntax)
            //{
            //    Console.WriteLine(i);
            //}

            /*
             Method Syntax
            Datasource.ConditionMethod().SelectionMethod()
            initialisasi -- kondisi -- seleksi

            var evenNumber = numbers.Where(number => number % 2 == 0).OrderByDescending(i=>i);

            foreach (var n in evenNumber)
            {
                Console.WriteLine(n);
            }

             
             */

            List<Product> products = new List<Product>
        {
            new Product { Id = 1, ProductName = "Hodie", ProductPrice = 100000, Stock = 10 },
            new Product { Id = 2, ProductName = "Kemeja", ProductPrice = 200000, Stock = 10 },
            new Product { Id = 3, ProductName = "Celana", ProductPrice = 100000, Stock = 10 },
            new Product { Id = 4, ProductName = "Sepatu", ProductPrice = 300000, Stock = 10 }
        };

            var querySyntaxProducts =
                from product in products
                orderby product.ProductName
                select product.ProductName;

            var methodSyntaxProducts =
                products.Where(product => product.ProductPrice > 100000).Select(product => product.ProductName);

            foreach (var querySyntaxProduct in querySyntaxProducts)
            {
                Console.WriteLine(querySyntaxProduct);
            }

            foreach (var price in methodSyntaxProducts)
            {
                Console.WriteLine(price);
            }

            //pagination menggunakan LINQ
            var page = 2;
            var size = 2;
            var productsPage = products.Skip((page - 1) * size).Take(size);

             Console.WriteLine($"Page {page}");
            foreach (var product in productsPage)
            {
                Console.WriteLine(product);
            }


            /*
             Mixed Syntax
             */

            var filteredProducts =
                (from product in products
                 where product.ProductPrice > 100000 && product.ProductPrice < 250000
                 select product).OrderByDescending(p => p);


            // var filteredProducts =
            //     (from product in products
            //         where product.ProductPrice is > 100000 and < 2500000
            //         select product).OrderByDescending(p => p.ProductName);

            Console.WriteLine("Filtered");
            foreach (var i in filteredProducts)
            {
                Console.WriteLine(i);

            }
        }
    }
}
