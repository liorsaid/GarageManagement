using System;

namespace Ex03.GarageLogic
{
    public class RegularCar : Car
    {
        private FuelEnergySystem m_FuelEnergySystem;
        private readonly FuelEnergySystem.FuelType r_FuelType = FuelEnergySystem.FuelType.Octan95;

        public RegularCar()
        {
            m_FuelEnergySystem = new FuelEnergySystem();
            m_FuelEnergySystem.MaxAmountOfFuel = 45.0f;
            m_FuelEnergySystem.VehicleFuelType = r_FuelType;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Fuel Type: {m_FuelEnergySystem.VehicleFuelType}, Current Fuel: {m_FuelEnergySystem.CurrentAmountOfFuel}L, Max Fuel: {FuelEnergySystem.MaxAmountOfFuel}L";
        }

        public FuelEnergySystem FuelEnergySystem
        {
            get { return m_FuelEnergySystem; }
            set { m_FuelEnergySystem = value; }
        }

        public FuelEnergySystem.FuelType FuelType
        {
            get { return r_FuelType;}
        }
    }
}
