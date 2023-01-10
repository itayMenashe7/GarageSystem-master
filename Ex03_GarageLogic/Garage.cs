namespace Ex03_GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class Garage
    {
        private readonly Dictionary<Vehicle, CustomerDetails> r_VehiclesInGarage;

        public Garage()
        {
            this.r_VehiclesInGarage = new Dictionary<Vehicle, CustomerDetails>();
        }

        public enum eFilterOptions
        {
            All = 1,
            Fixed,
            InProcess,
            payed,
        }

        public Vehicle this[string i_LicenseNumber]
        {
            get
            {
                Vehicle resVehicle = null;

                foreach (Vehicle vehicle in this.r_VehiclesInGarage.Keys)
                {
                    if (vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        resVehicle = vehicle;
                    }
                }

                if (resVehicle == null)
                {
                    throw new ArgumentException("The license number doesn't exist");
                }

                return resVehicle;
            }
        }

        public void InsertNewVehicle(Vehicle i_Vehicle, CustomerDetails i_cutomer)
        {
            this.r_VehiclesInGarage.Add(i_Vehicle, i_cutomer);
        }

        public List<string> GetVehicleListByStatusFilter(eFilterOptions filterOption)
        {
            List<string> returnList = new List<string>();

            foreach (KeyValuePair<Vehicle, CustomerDetails> entry in this.r_VehiclesInGarage)
            {
                Vehicle vehicle = entry.Key;
                CustomerDetails customerDetails = entry.Value;
                if (filterOption != eFilterOptions.All)
                {
                    if ((int)customerDetails.VehicleStatus + 1 == (int)filterOption)
                    {
                        returnList.Add(vehicle.LicenseNumber);
                    }
                }
                else
                {
                    returnList.Add(vehicle.LicenseNumber);
                }
            }

            return returnList;
        }

        public bool IsInGarage(string i_LicenseNumber)
        {
            bool isInGarage = false;

            foreach (Vehicle vehicle in this.r_VehiclesInGarage.Keys)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    isInGarage = true;
                }
            }

            return isInGarage;
        }

        public void ChangeStatus(string i_LicenseNumber, CustomerDetails.eVehicleStatus i_NewStatus)
        {
            this.r_VehiclesInGarage[this[i_LicenseNumber]].VehicleStatus = i_NewStatus;
        }

        public void InflatingWheelsToMaxByLicense(string i_LicenseNumber)
        {
            this[i_LicenseNumber].InflatingWheelsToMaximum();
        }

        public void RefuelVehicleByLicense(string i_LicenseNumber, Fuel.eFuelType i_fuelType, float i_EnergyToAdd)
        {
            Fuel engineFuel = this[i_LicenseNumber].Engine as Fuel;

            if (engineFuel != null)
            {
                engineFuel.RefuelEnergy(i_EnergyToAdd, i_fuelType);
            }
            else
            {
                throw new ArgumentException("The vehicle engine is not fuel");
            }
        }

        public void ChargeBatteryByLicense(string i_LicenseNumber, float i_EnergyToAdd)
        {
            Electric engineElectric = this[i_LicenseNumber].Engine as Electric;

            if (engineElectric != null)
            {
                engineElectric.ChargeBattery(i_EnergyToAdd);
            }
            else
            {
                throw new ArgumentException("The vehicle engine is not electric");
            }
        }

        public static EnergyType.energyType GetEnergySourceByVehicleType(VehicleBuilder.eVehicleType i_VehicleType)
        {
            EnergyType.energyType energyType;

            if (i_VehicleType == VehicleBuilder.eVehicleType.ElectricCar || i_VehicleType == VehicleBuilder.eVehicleType.ElectricMotorcycle)
            {
                energyType = EnergyType.energyType.electric;
            }
            else
            {
                energyType = EnergyType.energyType.fuel;
            }

            return energyType;
        }

        public string GetVehicleInfo(string i_LicenseNumber)
        {
            string vehicleDetails, wheelsDetails, engineDetails, vehicleSpecificDetails;
            Vehicle vehicle = this[i_LicenseNumber];
            CustomerDetails ownerCustomerDetails = this.r_VehiclesInGarage[vehicle];
            wheelsDetails = vehicle.GetWheelDetails();
            engineDetails = vehicle.GetEngineDetails();
            vehicleSpecificDetails = vehicle.GetSpecificDetailsForm();
            string currentStatus = Enum.GetName(typeof(CustomerDetails.eVehicleStatus), ownerCustomerDetails.VehicleStatus);
            vehicleDetails = string.Format(
            @"License Number: {0}
Car model: {1}
Customer name: {2}
Customer phone number: {3}
Status: {4}
The Current Energy Percent is: {5}%
{6}
{7}
{8}",
            vehicle.LicenseNumber, vehicle.ModelName, ownerCustomerDetails.CustomerName,
            ownerCustomerDetails.PhoneNumber,
            currentStatus,
            vehicle.CurrentEnergyPercent().ToString(), wheelsDetails,
            engineDetails, vehicleSpecificDetails);

            return vehicleDetails;
        }
    }
}
