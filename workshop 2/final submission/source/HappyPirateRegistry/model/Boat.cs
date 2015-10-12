using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPirateRegistry.model
{
    class Boat
    {
        public enum BoatType
        {
            Sailboat = 1, Motorsailer, Motorboat, Canoe, Other      //added motorboat as well (not mentioned in requirements?)
        }

        private BoatType m_type;
        private double m_length;       

        public Boat (BoatType a_type, double a_length)
        {
            m_type = a_type;
            m_length = a_length;
        }

        public BoatType GetBoatType()
        {
            return m_type;
        }

        public double GetLength()
        {
            return m_length;
        }

        public void Set(Boat a_boat)
        {
            m_type = a_boat.m_type;
            m_length = a_boat.m_length;
        }



    }
}
