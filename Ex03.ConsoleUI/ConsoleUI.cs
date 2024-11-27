using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        private GarageManagement garageManagement = new GarageManagement();

        public void CustomerConversation()
        {
            bool isConversationExists = true;

            while (isConversationExists)
            {
                Console.WriteLine("Hey! what's your name?");
                string customerName = Console.ReadLine();

                Console.WriteLine(@"
Hey {0}, Please choice which action whould you like to do:
1. Enter vehicle to the garage
2. See all the license numbers of the vehicles in the garage
3. Change the state of the vehicle in the garage
4. To inflate the wheels
5. To fuel a vehicle which is on fuel energy system
6. To charge a vehicle which is on electric energy system
7. To see all the details on a specific vehicle base on license number
", customerName);
                try
                {
                    int userMenuChoiceConverted = int.Parse(Console.ReadLine());

                    Console.WriteLine("{0}, Plese give me the License Number of the Vehicle: ", customerName);
                    string licenseNumber = Console.ReadLine();

                    switch (userMenuChoiceConverted)
                    {
                        case 1:
                            enterVehicleToGarageChoice(customerName, licenseNumber);
                            break;

                        case 2:
                            showGarageVehiclesLicenseNumbers();
                            break;

                        case 3:
                            CustomerCard.VehicleStatus vehicleStatusToChange = GetUserVehicleStatusChoice();
                            changeVehicleGarageStatus(licenseNumber, vehicleStatusToChange);
                            break;

                        case 4:
                            inflateAirPressureToMax(licenseNumber);
                            break;

                        case 5:
                            FuelEnergySystem.FuelType fuelTypeChoice = GetUserFuelTypeChoice();

                            Console.WriteLine("Please enter how much liters to you want to fuel (L):");
                            float amountOfFuel = float.Parse(Console.ReadLine());

                            try
                            {
                                fuelVehicle(licenseNumber, amountOfFuel, fuelTypeChoice);
                            }
                            catch (ArgumentException arguEx)
                            {
                                Console.WriteLine(arguEx.Message);
                            }
                            catch (ValueOutOfRangeException valOutRanEx)
                            {
                                Console.WriteLine(valOutRanEx.Message);
                            }
                            break;

                        case 6:
                            Console.WriteLine("Please enter how much time of battery do you want to add (H):");
                            float amountOfBatteryToAdd = float.Parse(Console.ReadLine());

                            try
                            {
                                chargeVehicle(licenseNumber, amountOfBatteryToAdd);
                            }
                            catch (ValueOutOfRangeException valOutRanEx)
                            {
                                Console.WriteLine(valOutRanEx.Message);
                            }
                            break;

                        case 7:
                            showDetailsOnVehicleByLiceseNumber(licenseNumber);
                            break;

                        default:
                            break;

                    }

                    Console.WriteLine("If do you want to do more actions please type Y");
                    isConversationExists = Console.ReadLine() == "Y";
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(String.Format("{0}, You should only choose a digit from the list", formatEx.Message));
                }
            }
        }

        private void enterVehicleToGarageChoice(string i_CustomerName, string i_LicenseNumber)
        {

            if (!garageManagement.IsVehicleInTheGarage(i_LicenseNumber))
            {
                Console.WriteLine("Your vehicle is not in the Garage.. Please answer the following questions before we enter your vehicle to the garage:");
                CustomerCard cutomerCard = new CustomerCard();

                cutomerCard.OwnerName = i_CustomerName;
                Console.WriteLine("What is your phone number:");
                string customerPhoneNumber = Console.ReadLine();

                cutomerCard.OwnerPhoneNumber = customerPhoneNumber;
                int customerVehicleTypeChoice = getUserVehicleType();

                Vehicle newVehicle;

                switch (customerVehicleTypeChoice)
                {
                    case 1:
                        Car settedCar = setInfoToCarObject();

                        newVehicle = settedCar;
                        break;

                    case 2:
                        Motorcycle settedMotorCycle = setInfoToMotorcycleObject();

                        newVehicle = settedMotorCycle;
                        break;

                    case 3:
                        Truck settedTruck = setInfoToTruckObject();

                        newVehicle = settedTruck;
                        break;

                    default:
                        newVehicle = null;
                        break;

                }

                Console.WriteLine("What is the name of your vehicle model?");
                string modelName = Console.ReadLine();

                Console.WriteLine("What is the current air pressure in your vehicle's wheels:");
                float currentAirPressure = float.Parse(Console.ReadLine());

                Console.WriteLine("What is the name of your vehicle's wheels manufacturer:");
                string wheelsManufacturerName = Console.ReadLine();

                setGeneralInfoToVehicle(cutomerCard, newVehicle, i_LicenseNumber, modelName, wheelsManufacturerName, currentAirPressure);
                garageManagement.AddCustomerCardToGarage(cutomerCard);
            }
        }

        private void showGarageVehiclesLicenseNumbers()
        {
            List<string> licenseNumbersList = garageManagement.GetAllVehiclesLisencesNumbers();

            printListOfLicenseNumbers(licenseNumbersList);
            Console.WriteLine(@"
Do you want to filter it by Vehicle status?
1. Yes
2. No");
            int customerChoice = int.Parse(Console.ReadLine());

            if(customerChoice == 1) 
            {
                CustomerCard.VehicleStatus vehicleStatus = GetUserVehicleStatusChoice();

                licenseNumbersList = garageManagement.GetVehiclesLisencesNumbersByStatus(vehicleStatus);
                printListOfLicenseNumbers(licenseNumbersList);
            }
        }

        private void changeVehicleGarageStatus(string i_LicenseNumber, CustomerCard.VehicleStatus i_VehicleStatusToChange)
        {
            garageManagement.ChangeVehicleStatus(i_LicenseNumber, i_VehicleStatusToChange);
        }

        private void inflateAirPressureToMax(string i_LicenseNumber)
        {
            CustomerCard customerCard = garageManagement.FindCustomerCardByLicenseNumber(i_LicenseNumber);
            Wheel [] wheels = customerCard.CustomerVehicle.ListOfWheels;

            foreach (Wheel wheel in wheels)
            {
                wheel.ToInflate();
            }
        }

        private void fuelVehicle(string i_LicenseNumber, float i_AmountOfFuelToAdd, FuelEnergySystem.FuelType i_FuelType)
        {
            CustomerCard customerCard = garageManagement.FindCustomerCardByLicenseNumber(i_LicenseNumber);

            if(customerCard.CustomerVehicle is RegularCar)
            {   
                RegularCar regularCar = customerCard.CustomerVehicle as RegularCar;

                if(i_FuelType != regularCar.FuelType)
                {
                    throw new ArgumentException(String.Format("Your fuel type is incorrect. The right fuel type is {0}", regularCar.FuelType));
                }
                else
                {
                    regularCar.FuelEnergySystem.ToFuel(i_AmountOfFuelToAdd);
                }
            } 
            else if (customerCard.CustomerVehicle is RegularMotorCycle)
            {
                RegularMotorCycle regularMotorcycle = customerCard.CustomerVehicle as RegularMotorCycle;

                if (i_FuelType != regularMotorcycle.FuelType)
                {
                    throw new ArgumentException(String.Format("Your fuel type is incorrect. The right fuel type is {0}", regularMotorcycle.FuelType));
                }
                else
                {
                    regularMotorcycle.FuelEnergySystem.ToFuel(i_AmountOfFuelToAdd);
                }
            }
            else if (customerCard.CustomerVehicle is Truck)
            {
                Truck regularTruck = customerCard.CustomerVehicle as Truck;

                if (i_FuelType != regularTruck.FuelType)
                {
                    throw new ArgumentException(String.Format("Your fuel type is incorrect. The right fuel type is {0}", regularTruck.FuelType));
                }
                else
                {
                    regularTruck.FuelEnergySystem.ToFuel(i_AmountOfFuelToAdd);
                }
            }
            else
            {
                Console.WriteLine("Your vehicle is not on fuel energy system...");
            }
        }

        private void chargeVehicle(string i_LicenseNumber, float i_AmountToCharge)
        {
            CustomerCard customerCard = garageManagement.FindCustomerCardByLicenseNumber(i_LicenseNumber);

            if (customerCard.CustomerVehicle is ElectricCar)
            {
                ElectricCar electricCar = customerCard.CustomerVehicle as ElectricCar;

                electricCar.ElectricEnergySystem.ChargeBattery(i_AmountToCharge);
            }
            else if (customerCard.CustomerVehicle is ElectricMotorcycle)
            {
                ElectricMotorcycle electricMotorcycle = customerCard.CustomerVehicle as ElectricMotorcycle;

                electricMotorcycle.ElectricEnergySystem.ChargeBattery(i_AmountToCharge);
            }
            else
            {
                Console.WriteLine("Your vehicle is not on electric energy system...");
            }
        }

        private void showDetailsOnVehicleByLiceseNumber(string i_LicenseNumber)
        {
            CustomerCard customerCard = garageManagement.FindCustomerCardByLicenseNumber(i_LicenseNumber);

            Console.WriteLine(customerCard.CustomerVehicle.ToString());
        }

        private void setGeneralInfoToVehicle(CustomerCard i_CustomerCard, Vehicle i_Vehicle, string i_LicenseNumber, string i_ModelName, string i_WheelsManufacturerName, float i_CurrentAirPressure)
        {
            i_Vehicle.LicenseNumber = i_LicenseNumber;
            i_Vehicle.ModelName = i_ModelName;
            i_Vehicle.SetVehicleWheelsInfo(i_CurrentAirPressure, i_WheelsManufacturerName);
            i_CustomerCard.CustomerVehicle = i_Vehicle;
            Console.WriteLine(i_Vehicle.ToString());
        }

        private Car setInfoForSpecificCarType()
        {
            Car car;
            int userSystemEngineChoice = getUserEngineSystemType();

            if(userSystemEngineChoice == 1)
            {
                Console.WriteLine("How much fuel your car currently has?");
                float currentFuel = float.Parse(Console.ReadLine());
                car = new RegularCar();

                try
                {
                    ((RegularCar)car).FuelEnergySystem.CurrentAmountOfFuel = currentFuel;
                    car.EnergyPercent = currentFuel / ((RegularCar)car).FuelEnergySystem.MaxAmountOfFuel;
                }
                catch(ArgumentException arguEx)
                {
                    Console.WriteLine($"{arguEx.Message}");
                }  
            }
            else
            {
                Console.WriteLine("How much Battery time your car has left?");
                float batteryTimeLeft = float.Parse(Console.ReadLine());

                car = new ElectricCar();
                try
                {
                    ((ElectricCar)car).ElectricEnergySystem.RemainingBatteryTime = batteryTimeLeft;
                    car.EnergyPercent = batteryTimeLeft / ((ElectricCar)car).ElectricEnergySystem.MaxBatteryTime;
                }
                catch (ArgumentException arguEx)
                {
                    Console.WriteLine($"{arguEx.Message}");
                }
            }

            return car;
        }

        private Car setInfoToCarObject()
        {
            Car specificCar = null;

            Car.ColorType userColorType = GetUserColorChoice();
            Console.WriteLine("How much doors your Car has?");
            bool succeed = int.TryParse(Console.ReadLine(), out int o_NumberOfDoors); 

            if(succeed)
            {
                specificCar = setInfoForSpecificCarType();
                specificCar.Color = userColorType;
                try
                {
                    specificCar.NumberOfDoors = o_NumberOfDoors;
                }

                catch (ArgumentException arguEx)
                {
                    Console.WriteLine(arguEx.Message);
                }
            }
          
            return specificCar;
        }

        private Motorcycle setInfoForSpecificMotorcycleType()
        {
            Motorcycle motorcycle;
            int userSystemEngineChoice = getUserEngineSystemType();

            if (userSystemEngineChoice == 1)
            {
                Console.WriteLine("How much fuel your motorcycle currently has?");
                float currentFuel = float.Parse(Console.ReadLine());

                motorcycle = new RegularMotorCycle();
                try
                {
                    ((RegularMotorCycle)motorcycle).FuelEnergySystem.CurrentAmountOfFuel = currentFuel;
                    motorcycle.EnergyPercent = currentFuel / ((RegularMotorCycle)motorcycle).FuelEnergySystem.MaxAmountOfFuel;
                }
                catch(ArgumentException arguEx)
                {
                    Console.WriteLine(arguEx.Message);
                }
            }
            else
            {
                Console.WriteLine("How much Battery time your motorcycle has left?");
                float batteryTimeLeft = float.Parse(Console.ReadLine());

                motorcycle = new ElectricMotorcycle();
                try
                {
                    ((ElectricMotorcycle)motorcycle).ElectricEnergySystem.RemainingBatteryTime = batteryTimeLeft;
                    motorcycle.EnergyPercent = batteryTimeLeft / ((ElectricMotorcycle)motorcycle).ElectricEnergySystem.MaxBatteryTime;
                }
                catch (ArgumentException arguEx)
                {
                    Console.WriteLine(arguEx.Message);
                }
            }

            return motorcycle;
        }

        private Motorcycle setInfoToMotorcycleObject()
        {
            Motorcycle.LicenseType userLicenseType = GetUserLicenseTypeChoice();

            Console.WriteLine("What is the engine capacity?");
            int engineCapacity = int.Parse(Console.ReadLine());
            Motorcycle specificMotorcycle = setInfoForSpecificMotorcycleType();

            specificMotorcycle.License = userLicenseType;
            specificMotorcycle.EngineCapacity = engineCapacity;

            return specificMotorcycle;
        }

        private Truck setInfoToTruckObject()
        {

            Truck truck = new Truck();

            Console.WriteLine("How much fuel your car currently has?");
            float currentFuel = float.Parse(Console.ReadLine());

            try
            {
                truck.FuelEnergySystem.CurrentAmountOfFuel = currentFuel;
                truck.EnergyPercent = currentFuel / truck.FuelEnergySystem.MaxAmountOfFuel;
            }
            catch(ArgumentException arguEx)
            {
                Console.WriteLine(arguEx.Message);
            }

            Console.WriteLine(@"
Does your truck transport hazardous materials:
1. Yes
2. No
");
            int isTransportHazerdous = int.Parse(Console.ReadLine());

            truck.TransportHazardousMaterials = isTransportHazerdous == 1;
            Console.WriteLine("What is your cargo volume?");
            float cargoVolume = float.Parse(Console.ReadLine());

            truck.CargoVolume = cargoVolume;
         
            return truck;   
        }

        private int getUserVehicleType()
        {
            int userVehicleTypeChoice;

            Console.WriteLine(@"
Which type your vehicle is (Choose the relevant number of your answer):
1. Car
2. Motorcycle
3. Truck
");
            userVehicleTypeChoice = int.Parse(Console.ReadLine());

            return userVehicleTypeChoice;
        }

        private int getUserEngineSystemType()
        {
            int userEngineSystemType;

            Console.WriteLine(@"
Which type your engine system is (Choose the relevant number of your answer):
1. Fuel
2. Electric
");
            userEngineSystemType = int.Parse(Console.ReadLine());

            return userEngineSystemType;
        }

        private void printListOfLicenseNumbers(List<string> i_List)
        {
            foreach (string licenseNumber in i_List)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        public static Car.ColorType GetUserColorChoice()
        {
            Console.WriteLine("Please select your car color:");
            foreach (object color in Enum.GetValues(typeof(Car.ColorType)))
            {
                Console.WriteLine($"{(int)color}. {color}");
            }

            while (true)
            {
                Console.Write("Enter the number corresponding to your choice: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int colorIndex) && Enum.IsDefined(typeof(Car.ColorType), colorIndex))
                {
                    return (Car.ColorType)colorIndex;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }


        public static Motorcycle.LicenseType GetUserLicenseTypeChoice()
        {
            Console.WriteLine("Please select your car license type:");
            foreach (object lisenceType in Enum.GetValues(typeof(Motorcycle.LicenseType)))
            {
                Console.WriteLine($"{(int)lisenceType}. {lisenceType}");
            }

            while (true)
            {
                Console.Write("Enter the number corresponding to your choice: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int licenseTypeIndex) && Enum.IsDefined(typeof(Motorcycle.LicenseType), licenseTypeIndex))
                {
                    return (Motorcycle.LicenseType)licenseTypeIndex;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }


        public static CustomerCard.VehicleStatus GetUserVehicleStatusChoice()
        {
            Console.WriteLine("Please select your vehicle status do you want to filter by:");
            foreach (object vehicleStatus in Enum.GetValues(typeof(CustomerCard.VehicleStatus)))
            {
                Console.WriteLine($"{(int)vehicleStatus}. {vehicleStatus}");
            }

            while (true)
            {
                Console.Write("Enter the number corresponding to your choice: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int statusIndex) && Enum.IsDefined(typeof(CustomerCard.VehicleStatus), statusIndex))
                {
                    return (CustomerCard.VehicleStatus)statusIndex;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        public static FuelEnergySystem.FuelType GetUserFuelTypeChoice()
        {
            Console.WriteLine("Please select fuel type:");
            foreach (object fuelType in Enum.GetValues(typeof(FuelEnergySystem.FuelType)))
            {
                Console.WriteLine($"{(int)fuelType}. {fuelType}");
            }

            while (true)
            {
                Console.Write("Enter the number corresponding to your choice: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int fuelTypeIndex) && Enum.IsDefined(typeof(FuelEnergySystem.FuelType), fuelTypeIndex))
                {
                    return (FuelEnergySystem.FuelType)fuelTypeIndex;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}
