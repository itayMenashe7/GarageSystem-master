namespace Ex03_GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicle
    {
        private readonly string r_LicenseNumber;
        private readonly List<Wheel> r_ListOfWheels;
        private string m_NameOfModel;
        private EnergyType m_Engine;
        public Vehicle(string i_LicenseNumber, int i_NumberOfWheels)
        {
            this.r_LicenseNumber = i_LicenseNumber;
            this.r_ListOfWheels = new List<Wheel>(i_NumberOfWheels);
        }

        public string LicenseNumber
        {
            get { return this.r_LicenseNumber; }
        }

        public string ModelName
        {
            get { return this.m_NameOfModel; }
            set { this.m_NameOfModel = value; }
        }

        public EnergyType Engine
        {
            get { return this.m_Engine; }
        }

        public List<Wheel> ListOfWheels
        {
            get { return this.r_ListOfWheels; }
        }

        public string GetEngineDetails()
        {
            StringBuilder information = new StringBuilder("Engine info: ");
            string specificDetails;
            Fuel fuelEngine = this.m_Engine as Fuel;

            information.Append(Environment.NewLine);
            if (fuelEngine != null)
            {
                specificDetails = fuelEngine.GetFuelDetails();
                information.Append(specificDetails);
            }
            else if (this.m_Engine is Electric)
            {
                specificDetails = ((Electric)this.m_Engine).GetElectricInfo();
                information.Append(specificDetails);
            }

            return information.ToString();
        }

        public void InitializeWheels(float i_MaxAirPressure)
        {
            for (int i = 0; i < this.r_ListOfWheels.Capacity; i++)
            {
                this.r_ListOfWheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public void FillWheelsDetails(string i_Manufacturer, float i_CurrentAirPressure)
        {
            foreach (Wheel wheel in this.ListOfWheels)
            {
                wheel.InflatingWheels(i_CurrentAirPressure);
                wheel.Manufacturer = i_Manufacturer;
            }
        }

        public void InflatingWheelsToMaximum()
        {
            foreach (Wheel wheel in this.ListOfWheels)
            {
                wheel.InflatingWheels(wheel.AirPressureDiffToMaxmimum());
            }
        }

        public string GetWheelDetails()
        {
            StringBuilder information = new StringBuilder("Wheels info:");
            string currentWheel;

            foreach (Wheel wheel in this.r_ListOfWheels)
            {
                information.Append(Environment.NewLine);
                currentWheel = string.Format(
                    @"Manufacturer: {0}, Current air pressure: {1}",
                wheel.Manufacturer, wheel.CurrentPressure.ToString());
                information.Append(currentWheel);
            }

            return information.ToString();
        }

        public void AllocateEngine(EnergyType.energyType i_EnergyType)
        {
            if (i_EnergyType == EnergyType.energyType.electric)
            {
                this.m_Engine = new Electric();
            }
            else
            {
                this.m_Engine = new Fuel();
            }
        }

        public abstract void CreateEngine(EnergyType.energyType i_EnergySource);

        public abstract void CreateWheels();

        public abstract string GetSpecificDetailsForm();

        public abstract void FillInfo(DetailsForm i_details);

        public abstract float CurrentEnergyPercent();
    }
}
