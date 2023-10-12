using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPCSC
{
    public class Tarjeta
    {
        private bool? _ActiveCycle;
        public bool? ActiveCycle
        {
            get { return _ActiveCycle; }
            set { _ActiveCycle = value; }
        }
        private int? _CodeAgreement1;

        public int? CodeAgreement1
        {
            get { return _CodeAgreement1; }
            set { _CodeAgreement1 = value; }
        }
        private int? _CodeAgreement2;

        public int? CodeAgreement2
        {
            get { return _CodeAgreement2; }
            set { _CodeAgreement2 = value; }
        }
        private int? _CodeAgreement3;

        public int? CodeAgreement3
        {
            get { return _CodeAgreement3; }
            set { _CodeAgreement3 = value; }
        }
        private int? _CodeAgreement4;

        public int? CodeAgreement4
        {
            get { return _CodeAgreement4; }
            set { _CodeAgreement4 = value; }
        }
        private string _CodeCard;

        public string CodeCard
        {
            get { return _CodeCard; }
            set { _CodeCard = value; }
        }
        private bool? _Courtesy;

        public bool? Courtesy
        {
            get { return _Courtesy; }
            set { _Courtesy = value; }
        }
        private DateTime? _DateTimeEntrance;

        public DateTime? DateTimeEntrance
        {
            get { return _DateTimeEntrance; }
            set { _DateTimeEntrance = value; }
        }
        private string _EntranceModule;

        public string EntranceModule
        {
            get { return _EntranceModule; }
            set { _EntranceModule = value; }
        }
        private string _EntrancePlate;

        public string EntrancePlate
        {
            get { return _EntrancePlate; }
            set { _EntrancePlate = value; }
        }
        private DateTime? _PaymentDateTime;

        public DateTime? PaymentDateTime
        {
            get { return _PaymentDateTime; }
            set { _PaymentDateTime = value; }
        }
        private string _PaymentModule;


        public string PaymentModule
        {
            get { return _PaymentModule; }
            set { _PaymentModule = value; }
        }
        private bool? _Replacement;

        public bool? Replacement
        {
            get { return _Replacement; }
            set { _Replacement = value; }
        }
        private bool? _SafetyExit;

        public bool? SafetyExit
        {
            get { return _SafetyExit; }
            set { _SafetyExit = value; }
        }
        private bool? _ValetParking;

        public bool? ValetParking
        {
            get { return _ValetParking; }
            set { _ValetParking = value; }
        }

        private long _CodeAuthorized;

        public long CodeAuthorized
        {
            get { return _CodeAuthorized; }
            set { _CodeAuthorized = value; }
        }

        private int _lane;

        public int lane
        {
            get { return _lane; }
            set { _lane = value; }
        }

    }
}
