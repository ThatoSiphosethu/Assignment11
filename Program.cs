using System;

namespace Assignment11
{
    class Program
    {
        static void Main(string[] args)
        { 
            var crud = new Crud();

            System.Console.WriteLine("Make a selection");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    crud.CreateMovie();
                break;
                case "2":
                    crud.ReadMovie();
                break;
                case "3":
                    crud.UpdateMovie();
                break;
                case "4":
                    crud.DeleteMovie();
                break;
            }
        }
    }
}
