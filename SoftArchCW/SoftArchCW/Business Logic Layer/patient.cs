using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftArchCW
{
    class patient
    {
        public string patientname
        {
            get { return PatientName; }
            set { PatientName = value; }
        }
        private string PatientName;

        public int nhsnumber
        {
            get { return NHSNumber; }
            set { NHSNumber = value; }
        }
        private int NHSNumber;

        public string address
        {
            get { return Address; }
            set { Address = value; }
        }
        private string Address;

        public string medicalcond
        {
            get { return MedicalCond; }
            set { MedicalCond = value; }
        }
        private string MedicalCond;

        public string patienttime
        {
            get { return PatientTime; }
            set { PatientTime = value; }
        }
        private string PatientTime;

        public string patientloc
        {
            get { return PatientLoc; }
            set { PatientLoc = value; }
        }
        private string PatientLoc;
    }
}
