using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPirateRegistry.view
{
    class MemberView
    {
        //create new member
        public model.Member AddMember()
        {
            string firstName;
            string lastName;
            string personalNumber;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Add new member to registry-----");
            Console.WriteLine("First name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Personal number: ");
            personalNumber = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("New member added!");

            return new model.Member(firstName, lastName, personalNumber, 0);
        }

        public int SelectMember()
        {
            int i;

            Console.WriteLine("");
            Console.WriteLine("Select member by entering Member id:");
            string selected = Console.ReadLine();

            if (Int32.TryParse(selected, out i))
            {
                return i;
            }
            else                    //felhantera konstiga inmatningar
            {
                return 0;
            }
        }

        public int MemberMenu(model.Member a_member)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Member specifics-----");
            Console.WriteLine("Name: {0} {1}", a_member.GetFirstName(), a_member.GetLastName());
            Console.WriteLine("Personal number: {0}", a_member.GetPersonalNumber());
            Console.WriteLine("Member id: {0}", a_member.GetMemberId());

            if (a_member.GetBoats().Count() > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Members registred boats:");
                foreach (model.Boat b in a_member.GetBoats())
                {
                    Console.WriteLine("Type: {0}", b.GetBoatType().ToString());
                    Console.WriteLine("Length: {0}", b.GetLength());
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Member has no boats yet");
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("---------------");
            Console.WriteLine("");
            Console.WriteLine("(D) to Delete member (U) to Update member (A) to Add boat (B) to list all Boats of member");
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.D)
            {
                return 1;
            }

            else if (input.Key == ConsoleKey.U)
            {
                return 2;
            }

            else if (input.Key == ConsoleKey.A)
            {
                return 3;
            }

            else if (input.Key == ConsoleKey.B)
            {
                return 4;
            }

            else return 0;          //returnera nåt annat


        }

        public model.Member DeleteMember(model.Member a_selectedMember)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Delete member from registry-----");
            Console.WriteLine("Do you want to DELETE the following member?");
            Console.WriteLine("Name:{0} {1} Member id:{2}", a_selectedMember.GetFirstName(), a_selectedMember.GetLastName(), a_selectedMember.GetMemberId());
            Console.WriteLine("");
            Console.WriteLine("Please press (Y) Yes or (N) No");

            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Y)
            {
                return a_selectedMember;
            }

            else
            {
                return null;
            }


        }

        public model.Member UpdateMember(model.Member a_selectedMember)
        {
            string firstName;
            string lastName;
            string personalNumber;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Update member information-----");
            Console.WriteLine("");
            Console.WriteLine("Name: {0} {1}", a_selectedMember.GetFirstName(), a_selectedMember.GetLastName());
            Console.WriteLine("Personal number: {0}", a_selectedMember.GetPersonalNumber());
            Console.WriteLine("**********");
            Console.WriteLine("Please change the information by entering below:");
            Console.WriteLine("");
            Console.WriteLine("First name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Personal number: ");
            personalNumber = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Member information updated!");

            return new model.Member(firstName, lastName, personalNumber, a_selectedMember.GetMemberId());

        }
    }
}
