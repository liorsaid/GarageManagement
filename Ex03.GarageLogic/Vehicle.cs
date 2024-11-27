namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercent; 
        private Wheel [] m_ListOfWheels;

        public Vehicle()
        {

        }

        public override string ToString()
        {
            return $"Model: {ModelName}, License Number: {LicenseNumber}, Energy: {EnergyPercent * 100}%, Wheels info: {getWheelsDetails()}";
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float EnergyPercent
        {
            get { return m_EnergyPercent; }
            set { m_EnergyPercent = value; }
        }

        public Wheel[] ListOfWheels
        {
            get { return m_ListOfWheels; }
            set { m_ListOfWheels = value; }
        }

        public void InitializeWheels(Wheel[] i_Wheels, float i_MaxAirPressure)
        {
            for (int i = 0; i < i_Wheels.Length; i++)
            {
                i_Wheels[i] = new Wheel();
                i_Wheels[i].MaxAirPressure = i_MaxAirPressure;
            }
        }

        public void SetVehicleWheelsInfo(float i_AirPressureInWheels, string i_WheelsManufacturerName)
        {
            foreach (Wheel wheel in ListOfWheels)
            {
                wheel.CurrentAirPressure = i_AirPressureInWheels;
                wheel.ManufacturerName = i_WheelsManufacturerName;
            }
        }

        private string getWheelsDetails()
        {
            string wheelsDetails = "None";

            if(m_ListOfWheels != null && m_ListOfWheels[0] != null)
            {
                wheelsDetails =  m_ListOfWheels[0].ToString();
            }

            return wheelsDetails;
        }
    }
}
