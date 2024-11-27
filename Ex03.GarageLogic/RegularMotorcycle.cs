using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public class RegularMotorCycle : Motorcycle
    {
        private FuelEnergySystem m_FuelEnergySystem;
        private readonly FuelEnergySystem.FuelType r_FuelType = FuelEnergySystem.FuelType.Octan98;

        public RegularMotorCycle()
        {
            m_FuelEnergySystem = new FuelEnergySystem();
            m_FuelEnergySystem.MaxAmountOfFuel = 5.5f;
            m_FuelEnergySystem.VehicleFuelType = r_FuelType;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Fuel Type: {m_FuelEnergySystem.VehicleFuelType}, Current Fuel: {m_FuelEnergySystem.CurrentAmountOfFuel}L, Max Fuel: {m_FuelEnergySystem.MaxAmountOfFuel}L";
        }

        public FuelEnergySystem FuelEnergySystem
        {
            get { return m_FuelEnergySystem; }
            set { m_FuelEnergySystem = value; }
        }

        public FuelEnergySystem.FuelType FuelType
        {
            get { return r_FuelType; }
        }
    }
}
