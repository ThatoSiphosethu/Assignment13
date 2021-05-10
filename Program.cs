using System;
using System.IO;
using NLog;

namespace Assignment13
{
    class Program
    {
        static void Main(string[] args)
        { 
            
            
           // string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            //var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger(); 
            //logger.Info("Program started");

            var crud = new Crud();

            System.Console.WriteLine("Make a selection");
            System.Console.WriteLine("\n1. Movie\n2. Users\n3. Occupation\n4. Ratings");
            int option = 0;

           do
           {
               option = Int32.Parse(Console.ReadLine());
               int choice;

               //if (!int.TryParse(option))
               //{
                   //logger.Error("Invalid input");
              // } else
                if (option == 1)
               {
                   Console.Clear();
                   Console.WriteLine("\n1. Add Movie\n2. View Movie\n3. Upddate Movie\n4. Delete Movie");
                    
                    choice = Int32.Parse(Console.ReadLine()); 
                    if (choice == 1)
                    {
                        crud.CreateMovie();
                    }
                    else if (choice == 2)
                    {
                        crud.ReadMovie();
                    }
                    else if (choice == 3)
                    {
                        crud.UpdateMovie();
                    }
                    else if (choice == 4)
                    { 
                        crud.DeleteMovie();
                    }
                    
               }
               else if (option == 2)
               
               {
                    Console.Clear();
                    Console.WriteLine("\n1. Add User\n2. View Users\n3. Upddate User\n4. Delete User");
                    choice = Int32.Parse(Console.ReadLine()); 
                   if (choice == 1)
                    {
                        crud.AddUser();
                    }
                    else if (choice == 2)
                    {
                        crud.SearchUser();
                    }
                    else if (choice == 3)
                    {
                       // crud.UpdateUser();
                    }
                    else if (choice == 4)
                    { 
                        //crud.DeleteUser();
                    }
               }else if (option == 3)
                    Console.Clear();
                    Console.WriteLine("\n1. Add Occupation\n2. View Occupation\n3. Upddate Occupation\n4. Delete Occupation");
                    choice = Int32.Parse(Console.ReadLine()); 
                    if (choice == 1)
                    {
                        crud.AddOccupation();
                    }
                    else if (choice == 2)
                    {
                        crud.ViewOccupation();
                    }
                    else if (choice == 3)
                    {
                        crud.UpdateOccupation();
                    }
                    else if (choice == 4)
                    { 
                        crud.DeleteOccupation();
                    }

                else if (option == 4)
                    Console.Clear();
                    Console.WriteLine("\n1. Add Ratings\n2. View Ratings\n3. Upddate Rating\n4. Delete Rating");
                    choice = Int32.Parse(Console.ReadLine()); 
                    try
                    {
                        if (choice == 1)
                            {
                                crud.AddRatings();
                            }
                        else if (choice == 2)
                            {
                                crud.SearchRating();
                            }
                        else if (choice == 3)
                            {
                                crud.UpdateRating();
                            }
                        else if (choice == 4)
                            { 
                                crud.DeleteRating();
                            }
                    }
                    catch (System.Exception)
                    {
                         Console.WriteLine("Sorry option not yet available");
                    }
                    
                    
                   // else {return;}
               
           } while (option > 5 || option < 1); 

        }
    }
}
