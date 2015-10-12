using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPirateRegistry.view
{
    class BoatView
    {
        public model.Boat addBoat()
        {
            int boatType;
            double length;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Add new boat to member-----");
            Console.WriteLine("Boat type: ");
            Console.WriteLine("Please enter (1)Sailboat, (2)Motorsailer, (3)Motorboat, (4)Canoe, (5)Other ");
            boatType = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Length in foot: ");
            length = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("New boat added to member!");

            model.Boat.BoatType typeOfBoat = (model.Boat.BoatType)boatType;

            return new model.Boat(typeOfBoat, length);

        }

        public int SelectBoat(model.Member a_member)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Members all boats-----");
            Console.WriteLine("Name: {0} {1}", a_member.GetFirstName(), a_member.GetLastName());

            if (a_member.GetBoats().Count() > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Members registred boats:");
                int i = 1;
                foreach (model.Boat b in a_member.GetBoats())
                {
                    Console.WriteLine("Boat no {0}", i);
                    Console.WriteLine("Type: {0}", b.GetBoatType().ToString());
                    Console.WriteLine("Length: {0}", b.GetLength());
                    Console.WriteLine("");
                    i++;
                }

                Console.WriteLine("");
                Console.WriteLine("---------------");
                Console.WriteLine("");
                Console.WriteLine("Please select boat by entering boat no");
                int input = Int32.Parse(Console.ReadLine());

                return input;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Member has no boats yet");
                Console.WriteLine("");

                return 0;
            }            

        }

        public int BoatMenu(model.Boat a_boat)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Boat specifics-----");
            Console.WriteLine("Type: {0}", a_boat.GetType());
            Console.WriteLine("Length: {0}", a_boat.GetLength());

            Console.WriteLine("");
            Console.WriteLine("---------------");
            Console.WriteLine("");
            Console.WriteLine("(D) to Delete boat (U) to Update boat");
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.D)
            {
                return 1;
            }

            else if (input.Key == ConsoleKey.U)
            {
                return 2;
            }

            else return 0;

        }

        public model.Boat DeleteBoat(model.Boat a_selectedBoat, model.Member a_selectedMember)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Delete boat from registry-----");
            Console.WriteLine("Do you want to DELETE the following boat?");
            Console.WriteLine("Owner:{0} {1}", a_selectedMember.GetFirstName(), a_selectedMember.GetLastName());
            Console.WriteLine("Type: {0}", a_selectedBoat.GetType());
            Console.WriteLine("Length: {0}", a_selectedBoat.GetLength());
            Console.WriteLine("");
            Console.WriteLine("Please press (Y) Yes or (N) No");

            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Y)
            {
                return a_selectedBoat;
            }

            else
            {
                return null;
            }


        }

        public model.Boat UpdateBoat(model.Boat a_selectedBoat)
        {
            int boatType;
            double length;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Update boat information-----");
            Console.WriteLine("");
            Console.WriteLine("Type: {0}", a_selectedBoat.GetType());
            Console.WriteLine("Length: {0}", a_selectedBoat.GetLength());
            Console.WriteLine("**********");
            Console.WriteLine("Please change the information by entering below:");
            Console.WriteLine("");
            Console.WriteLine("Boat type: ");
            Console.WriteLine("Please enter (1)Sailboat, (2)Motorsailer, (3)Motorboat, (4)Canoe, (5)Other ");
            boatType = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Length in foot: ");
            length = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Boat information updated!");

            model.Boat.BoatType type = (model.Boat.BoatType)boatType;

            return new model.Boat(type, length);

        }
    }
}
