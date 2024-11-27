namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private LicenseType m_LicenseType;
        private int m_EngineCapacity;
        private readonly float r_MaxAirPressure = 33f;

        public enum LicenseType
        {
            A,
            A1,
            AA,
            B1
        }

        public Motorcycle()
        {
            ListOfWheels = new Wheel[5];
            InitializeWheels(ListOfWheels, r_MaxAirPressure);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, LicenseType: {m_LicenseType}, Engine Capacity: {m_EngineCapacity}";
        }

        public LicenseType License
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }
    } 
}
