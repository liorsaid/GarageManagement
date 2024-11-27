namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private ElectricEnergySystem m_ElectricEnergySystem;

        public ElectricCar()
        {
            m_ElectricEnergySystem = new ElectricEnergySystem();
            m_ElectricEnergySystem.MaxBatteryTime = 3.5f;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Battery: {m_ElectricEnergySystem.RemainingBatteryTime}/{m_ElectricEnergySystem.MaxBatteryTime} hours remaining";
        }

        public ElectricEnergySystem ElectricEnergySystem
        {
            get { return m_ElectricEnergySystem; }
            set { m_ElectricEnergySystem = value; }
        }
    }
}
