namespace Ex03_GarageLogic
{
    public class Truck : Vehicle
    {
        private const float k_MaxFuelCapacity = 120f;
        private const float k_MaxAirPressure = 34f;
        private const int k_NumberOfWheels = 14;
        private bool m_IsHazardousMaterialBaggage;
        private float m_baggaeCapacity;
        private const float m_NoElectric = 0;

        public Truck(string i_LicenseNumber)
            : base(i_LicenseNumber, k_NumberOfWheels)
        {
        }

        public override void CreateEngine(EnergyType.energyType i_EnergySource)
        {
            this.AllocateEngine(i_EnergySource);
            this.Engine.UpdateMaximumEnergyCapcity(k_MaxFuelCapacity);
            ((Fuel)this.Engine).SetFuelType = Fuel.eFuelType.soler;
        }

        public override void CreateWheels()
        {
            this.InitializeWheels(k_NumberOfWheels);
        }

        public override void FillInfo(DetailsForm i_details)
        {
            this.m_baggaeCapacity = i_details.BaggageCapacity;
            this.m_IsHazardousMaterialBaggage = i_details.IsHazardousMateriaBaggage;
        }

        public override string GetSpecificDetailsForm()
        {
            string isHazardousMaterialBaggage = this.m_IsHazardousMaterialBaggage == true ? "YES" : "NO";

            return string.Format(
                "Details: cargo volume: {0}, the baaggae {1} contains hazardous materials",
                this.m_baggaeCapacity.ToString(), isHazardousMaterialBaggage);
        }

        public override float CurrentEnergyPercent()
        {
            return this.Engine.GetCurrentEnergy() / k_MaxFuelCapacity * 100;
        }
    }
}
