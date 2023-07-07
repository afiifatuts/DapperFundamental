using System;
using Npgsql;
using Dapper;
using System.Linq;

namespace DapperFundamental
{
    public class Program
    {

        public delegate void SayHello(Action callback);

        static void Main(string[] args)
        {
            /*
           Lambda Expression
          Didefinisikan dalam bahasa pemrograman adalag anonymous function, yang artinya method/function tanpa nama

            2 Tipe Lambda Expression yang digunakan di C#
          - Lambda Expression : dimana bodynya sebagai expression
          - Lambda Statement : dimana memiliki block code sebagai bodynya 


           */

            //Return data menggunakan Func<>
            Func<int, int> square = (int x) => x * x;
            Console.WriteLine(square(10));

            //tidak mengembalikan apa2 menggunakan Action
            SayHello sayHello = (Action  callback) =>
            {
                Console.WriteLine("Hello world");
                Console.WriteLine("Hello world");
                callback();
            };

            Action callback = () =>
            {
                Console.WriteLine("Ini Callback");
            };

            sayHello(callback);

            sayHello(()=> {
                Console.WriteLine("Ini adalah Callback Anonymous Function");
            });

        }
    }
}
