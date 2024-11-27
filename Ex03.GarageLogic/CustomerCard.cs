namespace Ex03.GarageLogic
{
    public class CustomerCard
    {
        private Vehicle m_CustomerVehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private VehicleStatus m_GarageVehicleStatus = VehicleStatus.InRepair;

        public CustomerCard()
        {

        }

        public enum VehicleStatus
        {
            InRepair,
            Repaired,
            Paid
        }

        public Vehicle CustomerVehicle
        {
            get { return m_CustomerVehicle; }
            set { m_CustomerVehicle = value; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public VehicleStatus GarageVehicleStatus
        {
            get { return m_GarageVehicleStatus; }
            set { m_GarageVehicleStatus = value; }
        }
    }
}
