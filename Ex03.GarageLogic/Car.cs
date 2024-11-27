namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {

        private ColorType m_Color;
        private int m_NumberOfDoors;
        private readonly float r_MaxAirPressure = 31f; 

        public enum ColorType
        {
            Yellow,
            White,
            Red,
            Black
        }

        public Car()
        {
            ListOfWheels = new Wheel[5];
            InitializeWheels(ListOfWheels, r_MaxAirPressure);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Color: {Color}, Doors: {NumberOfDoors}";
        }

        public ColorType Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public int NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set
            {
                if (value == 2 || value == 3 || value == 4 || value == 5)
                {
                    m_NumberOfDoors = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(2, 5);
                }
            }
        }
    }
}
