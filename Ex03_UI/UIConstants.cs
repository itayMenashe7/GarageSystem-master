namespace Ex03_UI
{
    public static class UIConstants
    {
        public const string k_WelcomeMessage = "Hello and welcome to the garage management application. We're excited to help you manage your garage with ease";
        public const string k_GarageMenuTitle = "Garage Application Menu:\nPlease choose one of the options";
        public const string k_InvalidMenuchoiceMessage = "Invalid menu choice. Please enter a valid menu option";
        public const string k_EnterNewVehicleLicense = "Enter the license number of the car you want to put in the garage";
        public const string k_EnterVehicleLicenseToUpdateMessage = "Enter the license number of the car you want to update is status";
        public const string k_EnterVehicleLicenseToChargeMessage = "Enter the license number of the car you want to charge";
        public const string k_EnterVehicleLicenseToPrintDetailsMessage = "Enter the license number of the car you want to get information about";
        public const string k_EnterVehicleLicenseToInflateTiresMessage = "Enter the license number of the vehcile you want to inflate";
        public const string k_EnterVehicleLicenseToFuelMessage = "Enter the license number of the car you want add fual";

        public const string k_VhicleLisenceAlreadyInGrage = "The license number you entered is already in the garage!";
        public const string k_VehicleEnteredSuccessfullyMessage = "The vehicle has been entered successfully";
        public const string k_EnterVehicleOwnerPhoneNumber = "Please enter the vehicle owner's phone number";
        public const string k_EnterVehicleOwnerName = "Please enter the name of the vehicle owner";
        public const string k_EnterCarModelMessage = "Please enter the vehicle model";
        public const string k_EnterCurrentEneryAmount = "Please enter the current energy amount:";
        public const string k_EnterManufacturerName = "Plaese enter the wheel manufacturer";
        public const string k_EnterWheelsAirPressure = "Plaese enter the wheel's air pressure";
        public const string k_InvalidEnergyInputErrorMessage = "Invalid energy amount, Try again";
        public const string k_InvalidWheelsAirPressureInputErrorMessage = "Invalid Air Pressure Input, Try again";
        public const string k_InvalidHazardousMaterialInputErrorMessage = "Invalid input, Is the truck transporting hazardous materials?\nY/N";
        public const string k_IsTransportingHazardousMaterialsMessage = "Is the truck transporting hazardous materials?\nY/N";
        public const string k_EnterBaggageCapacityMessage = "Please enter the baggage capacity";
        public const string k_InvalidBaggageCapacityInputErrorMessage = "Invalid baggage capacity input, please Try again";
        public const string k_VehicleOptionTitle = "Please choose Your vehicle type";
        public const string k_EnterCarColorTitle = "Please choose a car color";
        public const string k_EnterDoorsNumberTitle = "Please choose number of doors";
        public const string k_EnterlicenseTypeTitle = "Please choose a license type";
        public const string k_EnterEngineCapacityTitle = "Please enter the engine capacity(cc)";
        public const string k_InvalidEngineCapacityInputErrorMessage = "Invalid engine capacity, Try again";
        public const string k_StatusChangedMessage = "The status of the vehicle in the garage has been successfully changed";
        public const string k_InvalidIimeInputErrorMessage = "Invalid time format, Please try again";
        public const string k_EnterIimeToChargeMessage = "Please enter sum of " + k_TimeToAddFormat + " to add";
        public const string k_VehicleChargingSuccessfullyMessage = "Charging of the vehicle has been successful";
        public const string k_ChooseFuelTypeTitle = "Please select the type of fuel you want";
        public const string k_EnterAmoutOfFuelMessage = "Please enter sum of " + k_Fuel + " to add";
        public const string k_InvalidFuelInputErrorMessage = "Invalid amount, Please try again";
        public const string k_VehicleRefuelSuccessfullyMessage = "The vehicle has been successfully refueled";
        public const string k_VehicleInflatingSuccessfullyMessage = "The process of inflating the wheels went through successfully and the tires are full to the maximum pressure";
        public const string k_ChooseFilterOptionTitle = "Please choose filter option";
        public const string k_PressAnyKeyToContinueMessage = "Press any key to continue...";

        public const string k_Yes = "Y";
        public const string k_No = "N";
        private const string k_Fuel = "fuel";
        private const string k_TimeToAddFormat = "minutes";
    }
}
