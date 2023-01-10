namespace Ex03_UI
{
    using System;
    using System.Collections.Generic;
    using Ex03_GarageLogic;
    using static Ex03_UI.UIConstants;

    internal class ConsoleUI
    {
        public T DisplayOptionsAndGetChoise<T>(string[] options, string titleMessage)
        {
            bool isValidInput = false;
            this.DisplayMeaagse(titleMessage);
            T userChoice = default(T);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}" + ". {0}", this.SplitStringByCapitelLetter(options[i]));
            }

            while (!isValidInput)
            {
                try
                {
                    userChoice = this.GetChoiceFromUser<T>();
                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.Clear();
            return userChoice;
        }

        public float GetEnergyFromUser()
        {
            string energyAmountStr;
            float energyAmount;

            energyAmountStr = this.getInputFromUser(k_EnterCurrentEneryAmount);
            while (!float.TryParse(energyAmountStr, out energyAmount))
            {
                this.DisplayMeaagse(k_InvalidEnergyInputErrorMessage);
                energyAmountStr = this.getInputFromUser(k_EnterCurrentEneryAmount);
            }

            return energyAmount;
        }

        public void WelcomeMessage()
        {
            Console.WriteLine(k_WelcomeMessage);
        }

        public float GetEnergyTime()
        {
            string energyTimeToAdd;
            float energyAfterConverting;

            energyTimeToAdd = this.getInputFromUser(k_EnterIimeToChargeMessage);
            while (!float.TryParse(energyTimeToAdd, out energyAfterConverting))
            {
                energyTimeToAdd = this.getInputFromUser(k_InvalidIimeInputErrorMessage);
            }

            return energyAfterConverting;
        }

        public float GetAmountOfFuelToAdd()
        {
            string amoutOfFuelToAdd;
            float fuelAfterConverting;
            amoutOfFuelToAdd = this.getInputFromUser(k_EnterAmoutOfFuelMessage);
            while (!float.TryParse(amoutOfFuelToAdd, out fuelAfterConverting))
            {
                amoutOfFuelToAdd = this.getInputFromUser(k_InvalidFuelInputErrorMessage);
            }

            return fuelAfterConverting;
        }

        public void GetAndSetMotorcyacleInfo(DetailsForm i_DetailsForm)
        {
            string engineCapacityStr;
            int engineCapacity;
            engineCapacityStr = this.getInputFromUser(k_EnterEngineCapacityTitle);
            while (!int.TryParse(engineCapacityStr, out engineCapacity))
            {
                engineCapacityStr = this.getInputFromUser(k_InvalidEngineCapacityInputErrorMessage);
            }

            i_DetailsForm.EngineCapacity = engineCapacity;
            i_DetailsForm.LicenceType = this.DisplayOptionsAndGetChoise<MotorCycle.eLicenseType>(MotorCycle.GetLicenseTypeOption(), k_EnterlicenseTypeTitle);
        }

        public void GetAndSetCarInfo(DetailsForm io_DetailsForm)
        {
            io_DetailsForm.CarColor = this.DisplayOptionsAndGetChoise<Car.eColorType>(Car.GetColorOptions(), k_EnterCarColorTitle);
            io_DetailsForm.NumberOfDoors = this.DisplayOptionsAndGetChoise<Car.eNumberOfDoors>(Car.GetNumberOfDoorsOptions(), k_EnterDoorsNumberTitle);
        }

        public void GetAndSetTruckInfo(DetailsForm i_DetailsForm)
        {
            string isTransportingHazardousMaterialsInput, baggageCapacityStr;
            float baggageCapacity;
            bool isTransportingHazardousMaterials = true;

            baggageCapacityStr = this.getInputFromUser(k_EnterBaggageCapacityMessage);
            while (!float.TryParse(baggageCapacityStr, out baggageCapacity))
            {
                baggageCapacityStr = this.getInputFromUser(k_InvalidBaggageCapacityInputErrorMessage);
            }

            isTransportingHazardousMaterialsInput = this.getInputFromUser(k_IsTransportingHazardousMaterialsMessage);
            while (!(isTransportingHazardousMaterialsInput == k_Yes || isTransportingHazardousMaterialsInput == k_No) || !(isTransportingHazardousMaterialsInput.Length == 1))
            {
                isTransportingHazardousMaterialsInput = this.getInputFromUser(k_InvalidHazardousMaterialInputErrorMessage);
            }

            i_DetailsForm.BaggageCapacity = baggageCapacity;
            i_DetailsForm.IsHazardousMateriaBaggage = isTransportingHazardousMaterialsInput == k_Yes ? isTransportingHazardousMaterials : !isTransportingHazardousMaterials;
        }

        public void PreesAnyKeyToContinue()
        {
            Console.WriteLine(k_PressAnyKeyToContinueMessage);
            string input = Console.ReadLine();
        }

        internal string getInputFromUser(string i_message)
        {
            Console.WriteLine(i_message);
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        internal void DisplayMeaagse(string i_message)
        {
            Console.WriteLine(i_message);
        }

        internal CustomerDetails GetOwnerDetails()
        {
            CustomerDetails customer = new CustomerDetails();
            customer.VehicleStatus = CustomerDetails.eVehicleStatus.InProcess;
            customer.CustomerName = this.getInputFromUser(k_EnterVehicleOwnerName);
            customer.PhoneNumber = this.getInputFromUser(k_EnterVehicleOwnerPhoneNumber);

            return customer;
        }

        internal void PrintLicenseList(List<string> licenses)
        {
            foreach (string license in licenses)
            {
                this.DisplayMeaagse(license);
            }
        }

        internal void PrintOuOfRangeExeption(ValueOutOfRangeException i_Ex)
        {
            string message = string.Format("{0} [{1}-{2}]", i_Ex.Message, i_Ex.MinValue.ToString(), i_Ex.MaxValue.ToString());
            this.DisplayMeaagse(message);
        }

        internal void GetWheelsInfoFromUser(out string o_ManufacturerName, out float o_CurrentAirPressure)
        {
            string airPressureStr;
            float airPressure;

            o_ManufacturerName = this.getInputFromUser(k_EnterManufacturerName);
            airPressureStr = this.getInputFromUser(k_EnterWheelsAirPressure);
            while (!float.TryParse(airPressureStr, out airPressure))
            {
                this.DisplayMeaagse(k_InvalidWheelsAirPressureInputErrorMessage);
                airPressureStr = this.getInputFromUser(k_EnterWheelsAirPressure);
            }

            o_CurrentAirPressure = airPressure;
        }

        private T GetChoiceFromUser<T>()
        {
            string choice = Console.ReadLine();
            T choiceValue = default(T);
            if (int.TryParse(choice, out int value) && Enum.IsDefined(typeof(T), value))
            {
                choiceValue = (T)Enum.Parse(typeof(T), choice);
            }
            else
            {
                throw new FormatException(k_InvalidMenuchoiceMessage);
            }

            return choiceValue;
        }

        private string SplitStringByCapitelLetter(string i_valueToAplit)
        {
            string output = string.Empty;
            for (int i = 0; i < i_valueToAplit.Length; i++)
            {
                char cuurentChar = i_valueToAplit[i];
                if (char.IsUpper(cuurentChar) && i > 0)
                {
                    output += " ";
                }

                output += cuurentChar;
            }

            return output;
        }
    }
}