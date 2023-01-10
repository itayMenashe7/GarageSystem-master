namespace Ex03_GarageLogic
{
    using System;

    public class MotorCycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 28f;
        private const float k_maxBatteryCapacity = 1.6f;
        private const float k_MaxFuelCapacity = 6f;
        private float m_EngineCapacity;
        private eLicenseType m_LicenseType;

        public MotorCycle(string i_LicenseNumber)
            : base(i_LicenseNumber, k_NumberOfWheels)
        {
        }

        public enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B,
        }

        public static string[] GetLicenseTypeOption()
        {
            return Enum.GetNames(typeof(eLicenseType));
        }

        public override void CreateEngine(EnergyType.energyType i_EnergySource)
        {
            this.AllocateEngine(i_EnergySource);

            if (this.Engine is Electric)
            {
                this.Engine.UpdateMaximumEnergyCapcity(k_maxBatteryCapacity);
            }
            else
            {
                this.Engine.UpdateMaximumEnergyCapcity(k_MaxFuelCapacity);
                ((Fuel)this.Engine).SetFuelType = Fuel.eFuelType.Octan98;
            }
        }

        public override void CreateWheels()
        {
            this.InitializeWheels(k_MaxAirPressure);
        }

        public override void FillInfo(DetailsForm i_details)
        {
            this.m_LicenseType = i_details.LicenceType;
            this.m_EngineCapacity = i_details.EngineCapacity;
        }

        public override float CurrentEnergyPercent()
        {
            if (this.Engine is Electric)
            {
                return this.Engine.GetCurrentEnergy() / k_maxBatteryCapacity * 100;
            }
            else
            {
                return this.Engine.GetCurrentEnergy() / k_MaxFuelCapacity * 100;
            }
        }

        public override string GetSpecificDetailsForm()
        {
            string licenseType = null;

            licenseType = this.m_LicenseType.ToString();
            return string.Format("Details: license type: {0}, engine capacity: {1}", licenseType, this.m_EngineCapacity);
        }
    }
}
