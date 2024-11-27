namespace Ex03.GarageLogic
{
    public class ElectricEnergySystem
    {
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;
        
        public ElectricEnergySystem()
        {

        }

        public float RemainingBatteryTime
        {
            get { return m_RemainingBatteryTime; }
            set
            {
                if (value <= m_MaxBatteryTime && value >= 0)
                {
                    m_RemainingBatteryTime = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxBatteryTime);
                }
            }
        }

        public float MaxBatteryTime
        {
            get { return m_MaxBatteryTime; }
            set { m_MaxBatteryTime = value; }
        }

        public void ChargeBattery()
        {
            m_RemainingBatteryTime = m_MaxBatteryTime;
        }

        public void ChargeBattery(float i_TimeToCharge)
        {
            if (i_TimeToCharge >= 0 && m_RemainingBatteryTime + i_TimeToCharge <= m_MaxBatteryTime)
            {
                m_RemainingBatteryTime += i_TimeToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(0, (m_MaxBatteryTime - m_RemainingBatteryTime));
            }
        }
    }
}
