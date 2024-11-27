namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_TransportHazardousMaterials;
        private float m_CargoVolume;
        private FuelEnergySystem m_FuelEnergySystem;
        private readonly float r_MaxAirPressure = 28f;
        private readonly FuelEnergySystem.FuelType r_FuelType = FuelEnergySystem.FuelType.Soler;

        public Truck()
        {
            m_FuelEnergySystem = new FuelEnergySystem();
            m_FuelEnergySystem.MaxAmountOfFuel = 120.0f;
            m_FuelEnergySystem.VehicleFuelType = r_FuelType;
            ListOfWheels = new Wheel[12];
            InitializeWheels(ListOfWheels, r_MaxAirPressure);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Transport Hazardous Materials: {m_TransportHazardousMaterials}, Cargo Volume: {m_CargoVolume}, Fuel Type: {m_FuelEnergySystem.VehicleFuelType}, Current Fuel: {m_FuelEnergySystem.CurrentAmountOfFuel}L, Max Fuel: {m_FuelEnergySystem.MaxAmountOfFuel}L";
        }

        public FuelEnergySystem FuelEnergySystem
        {
            get { return m_FuelEnergySystem; }
            set { m_FuelEnergySystem = value; }
        }

        public bool TransportHazardousMaterials
        {
            get { return m_TransportHazardousMaterials; }
            set { m_TransportHazardousMaterials = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public FuelEnergySystem.FuelType FuelType
        {
            get { return r_FuelType; }
        }
    }
}
