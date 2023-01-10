namespace Ex03_GarageLogic
{
    using System;

    public class CustomerDetails
    {
        private string m_CustomerName;
        private string m_CustomerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public CustomerDetails()
        {
        }

        public CustomerDetails(string i_name, string i_phoneNumber)
        {
            this.m_CustomerName = i_name;
            this.m_CustomerPhoneNumber = i_phoneNumber;
        }

        public enum eVehicleStatus
        {
            Fixed = 1,
            InProcess,
            payed,
        }

        public string CustomerName
        {
            get { return this.m_CustomerName; }
            set { this.m_CustomerName = value; }
        }

        public string PhoneNumber
        {
            get { return this.m_CustomerPhoneNumber; }
            set { this.m_CustomerPhoneNumber = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set { this.m_VehicleStatus = value; }
        }

        public static string[] GetStatusOptions()
        {
            return Enum.GetNames(typeof(eVehicleStatus));
        }
    }
}
