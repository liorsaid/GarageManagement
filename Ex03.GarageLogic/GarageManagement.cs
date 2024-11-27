using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManagement
    {
        private readonly List<CustomerCard> r_ListOfCustomers; 

        public GarageManagement()
        {
            r_ListOfCustomers = new List<CustomerCard>();
        }

        public void AddCustomerCardToGarage(CustomerCard i_Customer)
        {
            r_ListOfCustomers.Add(i_Customer);
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, CustomerCard.VehicleStatus i_VehicleStatus)
        {
            CustomerCard customerCardToChange = FindCustomerCardByLicenseNumber(i_LicenseNumber);

            customerCardToChange.GarageVehicleStatus = i_VehicleStatus;
        }

        public CustomerCard FindCustomerCardByLicenseNumber(string i_LicenseNumber)
        {
            CustomerCard desiredCustomer = null;

            foreach (CustomerCard customer in r_ListOfCustomers)
            {
                try
                {
                    if (customer != null && customer.CustomerVehicle.LicenseNumber == i_LicenseNumber)
                    {
                        desiredCustomer = customer;
                        break;
                    }
                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.ToString());
                }
            }

            return desiredCustomer;
        }

        public bool IsVehicleInTheGarage(string i_LicenseNumber)
        {
            return FindCustomerCardByLicenseNumber(i_LicenseNumber) != null ? true : false;
        }

        public List<string> GetVehiclesLisencesNumbersByStatus(CustomerCard.VehicleStatus i_VehicleStatus)
        {
            List<string> vehiclesLisenceNumbers = new List<string>();

            foreach (CustomerCard customer in r_ListOfCustomers)
            {
                if (customer.GarageVehicleStatus == i_VehicleStatus)
                {
                    vehiclesLisenceNumbers.Add(customer.CustomerVehicle.LicenseNumber);  
                }
            }

            return vehiclesLisenceNumbers;
        }

        public List<string> GetAllVehiclesLisencesNumbers()
        {
            List<string> vehiclesLisenceNumbers = new List<string>();

            foreach (CustomerCard customer in r_ListOfCustomers)
            {
                vehiclesLisenceNumbers.Add(customer.CustomerVehicle.LicenseNumber);
            }

            return vehiclesLisenceNumbers;
        }

        public string GetVehicleDetailsByLicenseNumber(string i_LicenseNumber)
        {
            string vehicleDetailsByLicenseNumber = null;
            CustomerCard customer = FindCustomerCardByLicenseNumber(i_LicenseNumber);  

            if(customer != null)
            {
                vehicleDetailsByLicenseNumber = customer.CustomerVehicle.ToString();           
            }

            return vehicleDetailsByLicenseNumber;
        }
    }
}
