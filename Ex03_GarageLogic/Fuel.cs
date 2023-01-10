namespace Ex03_GarageLogic
{
    using System;

    public class Fuel : EnergyType
    {
        private const float k_MinEnergyCapacity = 0;
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxEnergyCapacity;

        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            soler,
        }

        public float CurrentFuelAmount
        {
            get { return this.m_CurrentFuelAmount; }
        }

        public float MaximumFuelAmount
        {
            get { return this.m_MaxEnergyCapacity; }
        }

        public eFuelType SetFuelType
        {
            get { return this.m_FuelType; }
            set { this.m_FuelType = value; }
        }

        public static string[] FuelTypeOptions()
        {
            return Enum.GetNames(typeof(eFuelType));
        }

        public override float GetCurrentEnergy()
        {
            return this.CurrentFuelAmount;
        }

        public override void AddEnergyAmount(float i_EnergyToAdd)
        {
            string errorMessage;

            if (this.m_CurrentFuelAmount + i_EnergyToAdd <= this.m_MaxEnergyCapacity)
            {
                this.m_CurrentFuelAmount += i_EnergyToAdd;
            }
            else
            {
                errorMessage = string.Format(
                    "You entered invallid value please try again, " +
                    "the current amount of fuel is {0} and should be between", this.m_CurrentFuelAmount);
                throw new ValueOutOfRangeException(errorMessage, this.m_MaxEnergyCapacity, k_MinEnergyCapacity);
            }
        }

        public override void UpdateMaximumEnergyCapcity(float i_MaxEnergyCapacity)
        {
            this.m_MaxEnergyCapacity = i_MaxEnergyCapacity;
        }

        public void RefuelEnergy(float i_EnergyToAdd, eFuelType i_FuelType)
        {
            if (this.m_FuelType != i_FuelType)
            {
                throw new ArgumentException("The type of fuel energy is not suitable to vehicle type " +
                    "energy");
            }
            else
            {
                this.AddEnergyAmount(i_EnergyToAdd);
            }
        }

        public string GetFuelDetails()
        {
            string fuelDetails = string.Format(
                "Fuel type: {0} Current fuel amount: {1}", this.m_FuelType.ToString(), this.m_CurrentFuelAmount.ToString());
            return fuelDetails;
        }
    }
}
