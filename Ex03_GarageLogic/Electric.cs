namespace Ex03_GarageLogic
{
    public class Electric : EnergyType
    {
        private const float k_MinEnergyCapacity = 0;
        private float m_CurrentBatteryTime;
        private float m_MaximumBatteryTime;

        public float MinimumBattery
        {
            get { return k_MinEnergyCapacity; }
        }

        public float CurrentBatteyTime
        {
            get { return this.m_CurrentBatteryTime; }
        }

        public float MaxBattery
        {
            get { return this.m_MaximumBatteryTime; }
        }

        public override void UpdateMaximumEnergyCapcity(float i_MaxEnergyCapacity)
        {
            this.m_MaximumBatteryTime = i_MaxEnergyCapacity;
        }

        public void ChargeBattery(float i_AmountBatteryToAdd)
        {
            if (i_AmountBatteryToAdd + this.m_CurrentBatteryTime <= this.m_MaximumBatteryTime)
            {
                this.m_CurrentBatteryTime += i_AmountBatteryToAdd;
            }
            else
            {
                string errorMessage = string.Format(
                    "You entered invallid value, the current battery" +
                    "time is {0} and it should be between", this.m_CurrentBatteryTime);

                throw new ValueOutOfRangeException(errorMessage, this.m_MaximumBatteryTime, k_MinEnergyCapacity);
            }
        }

        public override float GetCurrentEnergy()
        {
            return this.CurrentBatteyTime;
        }

        public override void AddEnergyAmount(float i_AmountOfBatteryToAdd)
        {
            if (this.m_CurrentBatteryTime + i_AmountOfBatteryToAdd <= this.m_MaximumBatteryTime)
            {
                this.m_CurrentBatteryTime += i_AmountOfBatteryToAdd;
            }
            else
            {
                string errorMessage = string.Format(
                    "You entered invallid input, the current " +
                    "battery time is {0} and should be between", this.m_CurrentBatteryTime);

                throw new ValueOutOfRangeException(errorMessage, this.m_MaximumBatteryTime, k_MinEnergyCapacity);
            }
        }

        public string GetElectricInfo()
        {
            return string.Format("Current battery time: {0}", this.m_CurrentBatteryTime.ToString());
        }
    }
}
