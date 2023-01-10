﻿namespace Ex03_GarageLogic
{
    using System;

    public class VehicleBuilder
    {
        public enum eVehicleType
        {
            Truck = 1,
            FuelCar,
            FuelMotorcycle,
            ElectricCar,
            ElectricMotorcycle,
        }

        public static Vehicle CreateVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
        {
            Vehicle newVehicle = null;

            if (i_VehicleType == eVehicleType.ElectricMotorcycle || i_VehicleType == eVehicleType.FuelMotorcycle)
            {
                newVehicle = new MotorCycle(i_LicenseNumber);
            }
            else if (i_VehicleType == eVehicleType.FuelCar || i_VehicleType == eVehicleType.ElectricCar)
            {
                newVehicle = new Car(i_LicenseNumber);
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                newVehicle = new Truck(i_LicenseNumber);
            }

            return newVehicle;
        }

        public static string[] GetVehicleOptions()
        {
            return Enum.GetNames(typeof(eVehicleType));
        }
    }
}
