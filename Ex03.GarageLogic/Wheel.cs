using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel()
        {

        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set
            {
                if (value <= m_MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ArgumentException("Current air pressure cannot exceed maximum air pressure.");
                }
            }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public override string ToString()
        {
            return $"Manufacturer Name: {m_ManufacturerName}, Max Air Pressure: {m_MaxAirPressure}, Current Air Pressure: {m_CurrentAirPressure}";
        }

        public void ToInflate()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public void ToInflate(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ArgumentException("Inflation amount exceeds maximum air pressure.");
            }
        }
    }
}
