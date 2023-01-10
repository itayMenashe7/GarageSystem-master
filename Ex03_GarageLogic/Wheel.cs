namespace Ex03_GarageLogic
{
    public class Wheel
    {
        private const float k_MinPressure = 0;
        private float m_MaxPressure;
        private float m_CurrentPressure;
        private string m_Manufacturer;

        public Wheel(float i_MaxPressure)
        {
            this.m_MaxPressure = i_MaxPressure;
        }

        public string Manufacturer
        {
            get { return this.m_Manufacturer; }
            set { this.m_Manufacturer = value; }
        }

        public float CurrentPressure
        {
            get { return this.m_CurrentPressure; }
        }

        public float AirPressureDiffToMaxmimum()
        {
            return this.m_MaxPressure - this.m_CurrentPressure;
        }

        public void InflatingWheels(float i_AddPressureValue)
        {
            if (this.m_CurrentPressure + i_AddPressureValue <= this.m_MaxPressure)
            {
                this.m_CurrentPressure = this.m_CurrentPressure + i_AddPressureValue;
            }
            else
            {
                string errorMessage = string.Format(
                    "You Entered invallid value, the current " +
                    "value of air pressure is {0} it should be between", this.m_CurrentPressure);
                throw new ValueOutOfRangeException(errorMessage, this.m_MaxPressure, k_MinPressure);
            }
        }
    }
}
