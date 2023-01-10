namespace Ex03_GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(string i_ErrorMessage, float i_MaxValue, float I_MinValue)
            : base(i_ErrorMessage)
        {
            this.r_MaxValue = i_MaxValue;
            this.r_MinValue = I_MinValue;
        }

        public float MaxValue
        {
            get { return this.r_MaxValue; }
        }

        public float MinValue
        {
            get { return this.r_MinValue; }
        }
    }
}
