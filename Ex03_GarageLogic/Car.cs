namespace Ex03_GarageLogic
{
    using System;

    public class Car : Vehicle
    {
        private const int k_numberOfWheels = 5;
        private const float k_minimumRange = 0;
        private const float k_maximumAirPressure = 32f;
        private const float k_maximumBatteryCapacity = 4.7f;
        private const float k_maximumFuelCapacity = 50f;
        private eColorType k_color;
        eNumberOfDoors k_doors;

        public Car(string i_licenseNumber)
            : base(i_licenseNumber, k_numberOfWheels)
        {
        }

        public enum eNumberOfDoors
        {
            two = 1,
            three,
            four,
            five,
        }

        public enum eColorType
        {
            red = 1,
            blue,
            white,
            gray,
        }

        public static string[] GetColorOptions()
        {
            return Enum.GetNames(typeof(eColorType));
        }

        public static string[] GetNumberOfDoorsOptions()
        {
            return Enum.GetNames(typeof(eNumberOfDoors));
        }

        public override void FillInfo(DetailsForm i_formDetails)
        {
            this.k_color = i_formDetails.CarColor;
            this.k_doors = i_formDetails.NumberOfDoors;
        }

        public override void CreateWheels()
        {
            this.InitializeWheels(k_maximumAirPressure);
        }

        public override void CreateEngine(EnergyType.energyType i_EnergyType)
        {
            this.AllocateEngine(i_EnergyType);
            if (this.Engine is Electric)
            {
                this.Engine.UpdateMaximumEnergyCapcity(k_maximumBatteryCapacity);
            }
            else
            {
                this.Engine.UpdateMaximumEnergyCapcity(k_maximumFuelCapacity);
                ((Fuel)this.Engine).SetFuelType = Fuel.eFuelType.Octan95;
            }
        }

        public override string GetSpecificDetailsForm()
        {
            string color = null, numOfDoors = null;

            color = this.k_color.ToString();
            numOfDoors = this.k_doors.ToString();
            string returnValue = string.Format("The color of the car: {0}, and the amount of doors is {1}", color, numOfDoors);
            return returnValue;
        }

        public override float CurrentEnergyPercent()
        {
            if (this.Engine is Electric)
            {
                return this.Engine.GetCurrentEnergy() / k_maximumBatteryCapacity * 100;
            }
            else
            {
                return this.Engine.GetCurrentEnergy() / k_maximumFuelCapacity * 100;
            }
        }
    }
}
