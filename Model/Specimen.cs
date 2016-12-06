using System;
namespace RuRo.Model
{
    [Serializable]
    public partial class Specimen
    {
        public Specimen()
        { }
        #region Model
        private int _id;
        private string _patientname;
        private string _sex;
        private string _specimennum;
        private string _patientnum;
        private string _department;
        private string _atsample;
        private string _age;
        private string _billingtime;
        private string _collectiondate;
        private string _collectiontime;
        private string _collectionby;
        private string _receivedate;
        private string _receivetime;
        private string _receiveby;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatientName
        {
            set { _patientname = value; }
            get { return _patientname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SpecimenNum
        {
            set { _specimennum = value; }
            get { return _specimennum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatientNum
        {
            set { _patientnum = value; }
            get { return _patientnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string atSample
        {
            set { _atsample = value; }
            get { return _atsample; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BillingTime
        {
            set { _billingtime = value; }
            get { return _billingtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string collectionDate
        {
            set { _collectiondate = value; }
            get { return _collectiondate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string collectionTime
        {
            set { _collectiontime = value; }
            get { return _collectiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string collectionby
        {
            set { _collectionby = value; }
            get { return _collectionby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Receivedate
        {
            set { _receivedate = value; }
            get { return _receivedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceiveTime
        {
            set { _receivetime = value; }
            get { return _receivetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Receiveby
        {
            set { _receiveby = value; }
            get { return _receiveby; }
        }
        #endregion Model

    }
}

