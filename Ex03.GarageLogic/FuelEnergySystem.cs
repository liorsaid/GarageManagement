using System;

namespace Ex03.GarageLogic
{
    public class FuelEnergySystem
    {
        private FuelType m_FuelType;
        private float m_CurrentAmountOfFuel;
        private float m_MaxAmountOfFuel;

        public enum FuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public FuelEnergySystem()
        {

        }

        public FuelType VehicleFuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public float CurrentAmountOfFuel
        {
            get { return m_CurrentAmountOfFuel; }
            set
            {
                if (value <= m_MaxAmountOfFuel && value >= 0)
                {
                    m_CurrentAmountOfFuel = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxAmountOfFuel);
                }
            }
        }

        public float MaxAmountOfFuel
        {
            get { return m_MaxAmountOfFuel; }
            set { m_MaxAmountOfFuel = value; }
        }

        public void ToFuel()
        {
            m_CurrentAmountOfFuel = m_MaxAmountOfFuel;
        }

        public void ToFuel(float i_Amount)
        {
            if (i_Amount >= 0 && m_CurrentAmountOfFuel + i_Amount <= m_MaxAmountOfFuel)
            {
                m_CurrentAmountOfFuel += i_Amount;
            }
            else
            {
                throw new ValueOutOfRangeException(0, (m_MaxAmountOfFuel - m_CurrentAmountOfFuel));
            }
        }
    }
}
