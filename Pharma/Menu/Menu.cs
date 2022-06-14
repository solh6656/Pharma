using Pharma.Domin.Enttes;
using Pharma.Service.DTOs;
using Pharma.Service.Extansions;
using Pharma.Service.Interfaces;
using Pharma.Service.Services;
using System;

namespace Pharma.Menu
{
    public class UI
    {
        public void Menufunc()
        {
            long sum = 0;
            IUserService service = new UserService();

            log:
            Console.WriteLine("\n\t\tWelcome! ");

            Console.Write("\n 1)Login \t 2)SingUp \t 0)Exit\n\n ");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.Clear();
                again:
                    Console.Write("\n Enter Username : ");
                    string username = Console.ReadLine();
                    Console.Write("\n Enter Password : ");
                    string password = Console.ReadLine();

                    var res = service.GetAll();

                    bool chack = res.Check(username, password.GetHashCode().ToString());

                    if (chack)
                    {
                        Console.Clear();
                        qaytatanlash:
                        IPillService temp = new PillService();
                        var pills = temp.GetAll();

                        int a = 1;
                        Console.WriteLine();
                        foreach (var p in pills)
                        {
                            Console.WriteLine($" {a}) {p.Name} {p.Price} {p.Count}");
                            a++;
                        }

                        Console.WriteLine("\n  1)Buy\t 0)Exit");
                        string choose = Console.ReadLine();
                        if (choose == "1")
                        {

                            Console.Write("\n Enter Pill name : ");
                            string pillname = Console.ReadLine();
                            Console.Write("\n Enter count : ");
                            int count = int.Parse(Console.ReadLine());


                            PillView pill = temp.Get(pillname);
                            if (pill is null)
                            {
                                Console.Clear();
                                Console.WriteLine("\n Pill is not found! Try again!");
                                goto qaytatanlash;
                            }


                            if (pill.Count >= count)
                            {
                                Seller seller = new Seller();
                                seller.SellPills(pill.Name, count);
                                sum += pill.Price * count;
                                Console.Clear();
                                goto qaytatanlash;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"\n\tSorry, the number of pills is limited\n\t! We can only give {pill.Count} pills!");
                                goto qaytatanlash;

                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"\n Idog'o  {sum} sum!");
                            Console.Write("\n Bye!");

                            break;
                        }


                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n Username or  Password not found!  Try again!");
                        goto again;
                    }

                case 2:
                    string firstName, lastName, uSername, phone, paSsword;

                    Console.Clear();
                    Console.Write("\n Enter First name : ");
                    firstName = Console.ReadLine();
                    Console.Write("\n Enter Last name : ");
                    lastName = Console.ReadLine();
                    Console.Write("\n Enter username : ");
                    uSername = Console.ReadLine();
                    Console.Write("\n Enter Phone : ");
                    phone = Console.ReadLine();
                    Console.Write("\n Enter Password : ");
                    paSsword = Hide();

                    UserView userView = new UserView()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Username = uSername,
                        Phone = phone,
                        Password = paSsword.GetHashCode().ToString()
                    };

                    service.Create(userView);

                    Console.Clear();
                    goto log;
                    
            }
        }

        public static string Hide()
        {
            string hide = "";
            while (true)
            {
                try
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            return null;
                        case ConsoleKey.Enter:
                            return hide;
                        case ConsoleKey.Backspace:
                            if(hide.Length > 0)
                                hide = hide.Substring(0, (hide.Length - 1));
                            Console.Write("\b \b");
                            break;
                        default:
                            hide += key.KeyChar;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("*");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine($"Xatolik!!!");
                }
            }
        }

    }
}
