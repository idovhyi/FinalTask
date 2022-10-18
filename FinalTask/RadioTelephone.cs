using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalTask
{
    [Serializable]
    [XmlInclude(typeof(RadioTelephone)), XmlInclude(typeof(MobilePhone))]

    public class RadioTelephone : Telephone
    {
        private int radiusOfOperation;
        private bool presenceOfAnsweringMachine;
        public int RadiusOfOperation { get { return radiusOfOperation; } set { radiusOfOperation = value; } }
        public bool PresenceOfAnsweringMachine { get { return presenceOfAnsweringMachine; } set { presenceOfAnsweringMachine = value; } }
        public RadioTelephone()
        { }
        public RadioTelephone(string name, string firm, float price, int radiusOfOperation, bool presenceOfAnsweringMachine) : base(name, firm, price)
        {
            this.radiusOfOperation = radiusOfOperation;
            this.presenceOfAnsweringMachine = presenceOfAnsweringMachine;
        }
    }
}
