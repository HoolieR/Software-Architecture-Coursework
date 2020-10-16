using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftArchCW
{
    class hospital
    {
        public string hospitalname
        {
            get { return HospitalName; }
            set { HospitalName = value; }
        }
        private string HospitalName;

        public string hospitaladdress
        {
            get { return HospitalAddress; }
            set { HospitalAddress = value; }
        }
        private string HospitalAddress;

        public string hospitalcity
        {
            get { return HospitalCity; }
            set { HospitalCity = value; }
        }
        private string HospitalCity;

        public string hospitalpostcode
        {
            get { return HospitalPostCode; }
            set { HospitalPostCode = value; }
        }
        private string HospitalPostCode;
    }
}
