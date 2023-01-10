namespace Ex03_GarageLogic
{
    public abstract class EnergyType
    {
        internal const float m_MinEnergyCapcity = 0;

        public enum energyType
        {
            fuel = 1,
            electric,
        }

        public abstract void AddEnergyAmount(float i_EnergyToAdd);

        public abstract float GetCurrentEnergy();

        public abstract void UpdateMaximumEnergyCapcity(float i_i_MaxEnergyCapacity);
    }
}
