namespace Ex03_GarageLogic
{
    public class DetailsForm
    {
        private Car.eColorType m_color;
        private Car.eNumberOfDoors m_doors;
        private MotorCycle.eLicenseType m_licenceType;
        private int m_EngineCapacity;
        private bool m_IsHazardousMateriaBaggage;
        private float m_baggageCapacity;

        public Car.eColorType CarColor
        {
            get { return this.m_color; }
            set { this.m_color = value; }
        }

        public Car.eNumberOfDoors NumberOfDoors
        {
            get { return this.m_doors; }
            set { this.m_doors = value; }
        }

        public bool IsHazardousMateriaBaggage
        {
            get { return this.m_IsHazardousMateriaBaggage; }
            set { this.m_IsHazardousMateriaBaggage = value; }
        }

        public float BaggageCapacity
        {
            get { return this.m_baggageCapacity; }
            set { this.m_baggageCapacity = value; }
        }

        public MotorCycle.eLicenseType LicenceType
        {
            get { return this.m_licenceType; }
            set { this.m_licenceType = value; }
        }

        public int EngineCapacity
        {
            get { return this.m_EngineCapacity; }
            set { this.m_EngineCapacity = value; }
        }
    }
}
