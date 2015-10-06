using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPirateRegistry.model
{
    class Member
    {
        private string m_firstName;
        private string m_lastName;
        private string m_personalNumber;
        private int m_memberId;
        private List<Boat> m_boats = new List<Boat>();

        //Kan det behövas en dummymedlem?
        public Member(string a_firstName, string a_lastName, string a_personalNumber, int a_memberId)
        {
            m_firstName = a_firstName;
            m_lastName = a_lastName;
            m_personalNumber = a_personalNumber;
            m_memberId = a_memberId;

        }

        public Member (Member a_member, int a_memberId)
        {
            m_memberId = a_memberId;
            Set(a_member);
        }

        public string GetFirstName()
        {
            return m_firstName;
        }

        public string GetLastName()
        {
            return m_lastName;
        }

        public string GetPersonalNumber()
        {
            return m_personalNumber;
        }

        public int GetMemberId()
        {
            return m_memberId;
        }

        public IEnumerable<Boat> GetBoats()
        {
            return m_boats;
        }

        public void Set (Member a_member)                   
        {
            m_firstName = a_member.m_firstName;
            m_lastName = a_member.m_lastName;
            m_personalNumber = a_member.m_personalNumber;
        }

        public void AddBoat(Boat a_boat)
        {
            m_boats.Add(a_boat);
        }

        public Boat SelectBoat (int a_id)
        {
            return m_boats[a_id];   //felhantering
        }

        public void DeleteBoat(Boat a_boat)
        {
            m_boats.Remove(a_boat);
        }

        public void UpdateBoat(Boat a_old, Boat a_new)
        {
            a_old.Set(a_new);
        }




    }
}
