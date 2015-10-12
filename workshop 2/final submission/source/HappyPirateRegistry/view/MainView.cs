using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPirateRegistry.view
{
    class MainView
    {
        //to be able to use all types of view from this view?
        public MemberView m_memberView = new MemberView();
        public BoatView m_boatView = new BoatView();

        public void ShowGoBackMenu()
        {
            Console.WriteLine("Press enter for main menu");
            Console.ReadLine();
        }
        public void ShowStartMenu ()
        {
            Console.Clear();
            Console.WriteLine(" ╔═════════════════════════════════════════╗ ");
            Console.WriteLine(" ║    The Happy Pirate Member Registry     ║ ");
            Console.WriteLine(" ╚═════════════════════════════════════════╝ ");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add member");
            Console.WriteLine("2. Update, delete or add boat to member");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("3. Compact list");
            Console.WriteLine("4. Verbose list");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Pick your menu choise [0-4]:");
        }

        public int VerifyUserInput(int input, int min, int max)
        {
            if(input > max || input < min)
            {
                Console.WriteLine("Please enter your choise [{0}-{1}]", min, max);
                return 0;
            }
            else
            {
                return input;
            }
        }

        public int userInput()
        {
            int inputNumber;
            do
            {
                int i;
                string input = Console.ReadLine();
                Int32.TryParse(input, out i);
                inputNumber = VerifyUserInput(i, 0, 4);
                
            } while (inputNumber == 0);

            return inputNumber;
        }
            


        public void ShowCompactList(List<model.Member> a_members)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Compact List-----");
            if (a_members.Count == 0)
            {
                Console.WriteLine("Registry has no members yet");
            }

            else
            {
                foreach(model.Member m in a_members)
                {
                    Console.WriteLine("Name: {0} {1}", m.GetFirstName(), m.GetLastName());
                    Console.WriteLine("Member id: {0}", m.GetMemberId());
                    Console.WriteLine("Number of Boats: {0}", m.GetBoats().Count());
                    Console.WriteLine("");
                    Console.WriteLine("---------------");
                    Console.WriteLine("");
                }
            }
        }

        public void ShowVerboseList(List<model.Member> a_members)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-----Verbose List-----");
            if (a_members.Count == 0)
            {
                Console.WriteLine("Registry has no members yet");
            }

            else
            {
                foreach (model.Member m in a_members)
                {
                    Console.WriteLine("Name: {0} {1}", m.GetFirstName(), m.GetLastName());
                    Console.WriteLine("Personal number: {0}", m.GetPersonalNumber());
                    Console.WriteLine("Member id: {0}", m.GetMemberId());

                    if (m.GetBoats().Count() > 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Members registred boats:");
                        Console.WriteLine("");
                        foreach (model.Boat b in m.GetBoats())
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
                }
            }
        }

    }
}
