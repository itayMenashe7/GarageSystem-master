namespace Ex03_UI
{
    using System;
    using System.Collections.Generic;
    using Ex03_GarageLogic;
    using static Ex03_UI.UIConstants;

    public class GarageManagemntApp
    {
        private readonly Garage r_Garage = new Garage();
        private readonly ConsoleUI r_UI = new ConsoleUI();

        public enum eMenuMethodOptions
        {
            EnterNewVehicle = 1,
            UpdateVehicleStatus,
            GetListOfLicenses,
            RefualVehicle,
            ChargeVehilce,
            GetVehicleDetails,
            TireInflation,
            ExitProgeam,
        }

        public void Run()
        {
            this.r_UI.WelcomeMessage();
            eMenuMethodOptions userActionChoice = 0;
            while (userActionChoice != eMenuMethodOptions.ExitProgeam)
            {
                userActionChoice = this.r_UI.DisplayOptionsAndGetChoise<eMenuMethodOptions>(Enum.GetNames(typeof(eMenuMethodOptions)), k_GarageMenuTitle);
                switch (userActionChoice)
                {
                    case eMenuMethodOptions.EnterNewVehicle:
                        this.EnterNewVehicle();
                        break;
                    case eMenuMethodOptions.UpdateVehicleStatus:
                        this.UpdateCarStatus();
                        break;
                    case eMenuMethodOptions.GetListOfLicenses:
                        this.GetListOfLicenses();
                        break;
                    case eMenuMethodOptions.RefualVehicle:
                        this.VehicleRefueling();
                        break;
                    case eMenuMethodOptions.ChargeVehilce:
                        this.VehicleCharging();
                        break;
                    case eMenuMethodOptions.GetVehicleDetails:
                        this.GetVehicleInfo();
                        break;
                    case eMenuMethodOptions.TireInflation:
                        this.InflateTiresToMax();
                        break;
                    case eMenuMethodOptions.ExitProgeam:
                        this.ExitManagemntProgram();
                        break;
                }

                System.Threading.Thread.Sleep(1000);
                this.r_UI.PreesAnyKeyToContinue();
                Console.Clear();
            }
        }

        private void ExitManagemntProgram()
        {
            System.Environment.Exit(0);
        }

        private void InflateTiresToMax()
        {
            string licenseNumber = this.r_UI.getInputFromUser(k_EnterVehicleLicenseToInflateTiresMessage);
            try
            {
                this.r_Garage.InflatingWheelsToMaxByLicense(licenseNumber);
                this.r_UI.DisplayMeaagse(k_VehicleInflatingSuccessfullyMessage);
            }
            catch (Exception ex)
            {
                this.r_UI.DisplayMeaagse(ex.Message);
            }
        }

        private void GetVehicleInfo()
        {
            string licenseNumber = this.r_UI.getInputFromUser(k_EnterVehicleLicenseToPrintDetailsMessage);

            try
            {
                this.r_UI.DisplayMeaagse(this.r_Garage.GetVehicleInfo(licenseNumber));
            }
            catch (Exception ex)
            {
                this.r_UI.DisplayMeaagse(ex.Message);
            }
        }

        private void VehicleCharging()
        {
            string licenseNumber = this.r_UI.getInputFromUser(k_EnterVehicleLicenseToChargeMessage);
            float timeToCharge = this.r_UI.GetEnergyTime();

            try
            {
                this.r_Garage.ChargeBatteryByLicense(licenseNumber, timeToCharge);
                this.r_UI.DisplayMeaagse(k_VehicleChargingSuccessfullyMessage);
            }
            catch (ValueOutOfRangeException ex)
            {
                this.r_UI.PrintOuOfRangeExeption(ex);
            }
            catch (Exception ex)
            {
                this.r_UI.DisplayMeaagse(ex.Message);
            }
        }

        private void VehicleRefueling()
        {
            string licenseNumber = this.r_UI.getInputFromUser(k_EnterVehicleLicenseToFuelMessage);
            Fuel.eFuelType fuelType = this.r_UI.DisplayOptionsAndGetChoise<Fuel.eFuelType>(Fuel.FuelTypeOptions(), k_ChooseFuelTypeTitle);
            float amountOfFuelToAdd = this.r_UI.GetAmountOfFuelToAdd();
            try
            {
                this.r_Garage.RefuelVehicleByLicense(licenseNumber, fuelType, amountOfFuelToAdd);
                this.r_UI.DisplayMeaagse(k_VehicleRefuelSuccessfullyMessage);
            }
            catch (ValueOutOfRangeException ex)
            {
                this.r_UI.PrintOuOfRangeExeption(ex);
            }
            catch (Exception ex)
            {
                this.r_UI.DisplayMeaagse(ex.Message);
            }
        }

        private void GetListOfLicenses()
        {
            List<string> licenses;
            Garage.eFilterOptions filterOption = this.r_UI.DisplayOptionsAndGetChoise<Garage.eFilterOptions>(Enum.GetNames(typeof(Garage.eFilterOptions)), k_ChooseFilterOptionTitle);
            licenses = this.r_Garage.GetVehicleListByStatusFilter(filterOption);
            this.r_UI.PrintLicenseList(licenses);
        }

        private void UpdateCarStatus()
        {
            string licenseNumber = this.r_UI.getInputFromUser(k_EnterVehicleLicenseToUpdateMessage);
            CustomerDetails.eVehicleStatus newStatus = this.r_UI.DisplayOptionsAndGetChoise<CustomerDetails.eVehicleStatus>(CustomerDetails.GetStatusOptions(), k_EnterlicenseTypeTitle);
            try
            {
                this.r_Garage.ChangeStatus(licenseNumber, newStatus);
                this.r_UI.DisplayMeaagse(k_StatusChangedMessage);
            }
            catch (ArgumentException ex)
            {
                this.r_UI.DisplayMeaagse(ex.Message);
            }
        }

        private void EnterNewVehicle()
        {
            string licenseNumber = this.r_UI.getInputFromUser(k_EnterNewVehicleLicense);
            if (this.r_Garage.IsInGarage(licenseNumber))
            {
                this.r_UI.DisplayMeaagse(k_VhicleLisenceAlreadyInGrage);
                this.r_Garage.ChangeStatus(licenseNumber, CustomerDetails.eVehicleStatus.InProcess);
            }
            else
            {
                Vehicle newVehicle = this.createNewVehicle(licenseNumber);
                CustomerDetails vehicleOwner = this.r_UI.GetOwnerDetails();
                this.r_Garage.InsertNewVehicle(newVehicle, vehicleOwner);
                this.r_UI.DisplayMeaagse(k_VehicleEnteredSuccessfullyMessage);
            }
        }

        private Vehicle createNewVehicle(string i_LicenseNumber)
        {
            Vehicle newVehicle;
            VehicleBuilder.eVehicleType vehicleTypeChoice;
            vehicleTypeChoice = this.r_UI.DisplayOptionsAndGetChoise<VehicleBuilder.eVehicleType>(Enum.GetNames(typeof(VehicleBuilder.eVehicleType)), k_VehicleOptionTitle);
            newVehicle = VehicleBuilder.CreateVehicle(i_LicenseNumber, vehicleTypeChoice);
            newVehicle.CreateWheels();
            newVehicle.CreateEngine(Garage.GetEnergySourceByVehicleType(vehicleTypeChoice));
            DetailsForm detailsForm = new DetailsForm();
            this.enterVehicleDetails(detailsForm, newVehicle, vehicleTypeChoice);
            newVehicle.FillInfo(detailsForm);
            return newVehicle;
        }

        private void enterVehicleDetails(DetailsForm io_detailsForm, Vehicle io_Vehicle, VehicleBuilder.eVehicleType i_VehicleType)
        {
            this.initBasicInformation(io_Vehicle);
            if (io_Vehicle is Car)
            {
                this.r_UI.GetAndSetCarInfo(io_detailsForm);
            }
            else if (io_Vehicle is MotorCycle)
            {
                this.r_UI.GetAndSetMotorcyacleInfo(io_detailsForm);
            }
            else if (io_Vehicle is Truck)
            {
                this.r_UI.GetAndSetTruckInfo(io_detailsForm);
            }
        }

        private void initBasicInformation(Vehicle i_Vehicle)
        {
            bool isValidAirInput = false, isValidEnergyInput = false;
            float currentAirPressure;
            string manufacturerName;

            i_Vehicle.ModelName = this.r_UI.getInputFromUser(k_EnterCarModelMessage);
            while (!isValidEnergyInput)
            {
                try
                {
                    float energy = this.r_UI.GetEnergyFromUser();
                    i_Vehicle.Engine.AddEnergyAmount(energy);
                    isValidEnergyInput = true;
                }
                catch (ValueOutOfRangeException ex)
                {
                    this.r_UI.PrintOuOfRangeExeption(ex);
                }
            }

            while (!isValidAirInput)
            {
                try
                {
                    this.r_UI.GetWheelsInfoFromUser(out manufacturerName, out currentAirPressure);
                    i_Vehicle.FillWheelsDetails(manufacturerName, currentAirPressure);
                    isValidAirInput = true;
                }
                catch (ValueOutOfRangeException ex)
                {
                    this.r_UI.PrintOuOfRangeExeption(ex);
                }
            }
        }
    }
}
