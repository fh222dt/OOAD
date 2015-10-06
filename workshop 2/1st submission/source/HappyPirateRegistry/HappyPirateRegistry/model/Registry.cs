using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPirateRegistry.model
{
    class Registry
    {
        private string m_location = "registry.txt";
        public List<Member> m_members;
        private int m_memberId;

        public Registry()
        {
            m_members = new List<Member>();
            m_memberId = 1;
        }

        private int CheckMemberId()
        {
            if(m_members.Count != 0)
            {
                int lastUsedId = m_members.Last().GetMemberId();
                m_memberId = lastUsedId+ 1;
            }

            return m_memberId;
            
        }

        public void AddMember(Member a_member)
        {
            m_members.Add(new Member(a_member, m_memberId));
            m_memberId++;
        }

        public Member SelectMember(int a_id)
        {
            foreach (Member m in m_members)
            {
                if (m.GetMemberId() == a_id)
                {
                    return m;
                }
            }
            return null;
        }

        public void DeleteMember(Member a_member)
        {
            m_members.Remove(a_member);
        }

        public void UpdateMember(Member a_old, Member a_new)
        {
            a_old.Set(a_new);
        }

        enum MemberReadStatus { Indefinite, Member, Boat };

        public void LoadFromFile()
        {
            string loadLine;
            MemberReadStatus status = MemberReadStatus.Indefinite;


            using (StreamReader loader = new StreamReader(m_location))
            {
                while ((loadLine = loader.ReadLine()) != null)
                {
                    if (loadLine == "")
                    {
                        continue;
                    }

                    if (loadLine == "[Member]")
                    {
                        status = MemberReadStatus.Member;
                    }

                    else if (loadLine == "[Boat]")
                    {
                        status = MemberReadStatus.Boat;
                    }

                    else
                    {
                        if (status == MemberReadStatus.Member)
                        {
                            string[] splitMember = loadLine.Split(';');
                            m_members.Add(new Member(splitMember[0], splitMember[1], splitMember[2], int.Parse(splitMember[3])));

                        }

                        else if (status == MemberReadStatus.Boat)
                        {
                            //    if (splitBoat.Length != 3)
                            //    {
                            //        throw new Exception("Det är fel antal ord på raden");
                            //    }
                            string[] splitBoat = loadLine.Split(';');
                            foreach (Member m in m_members)
                            {
                                if(m.GetMemberId() == int.Parse(splitBoat[0]))
                                {
                                    model.Boat.BoatType typeOfBoat;
                                    Enum.TryParse(splitBoat[1], out typeOfBoat);
                                    Boat b = new Boat(typeOfBoat, double.Parse(splitBoat[2]));
                                    m.AddBoat(b);
                                }
                            }

                        }

                    }
                }
            }
            CheckMemberId();
        }

        public void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(m_location))
            {                
                foreach (Member m in m_members)
                {
                    writer.WriteLine("[Member]");
                    writer.WriteLine(m.GetFirstName() + ";" + m.GetLastName() + ";" + m.GetPersonalNumber() + ";" + m.GetMemberId());

                    foreach (Boat b in m.GetBoats())
                    {
                        writer.WriteLine("[Boat]");
                        writer.WriteLine(m.GetMemberId() + ";" + b.GetBoatType() + ";" + b.GetLength());
                    }
                }
                
            }
        }


    }

        
}
