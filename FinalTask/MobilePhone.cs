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

    public class MobilePhone : Telephone
    {
        private string color;
        private int memoryVolume;
        public string Color { get { return color; } set { color = value; } }
        public int MemoryVolume { get { return memoryVolume; } set { memoryVolume = value; } }
        public MobilePhone()
        { }
        public MobilePhone(string name, string firm, float price, string color, int memoryVolume) : base(name, firm, price)
        {
            this.color = color;
            this.memoryVolume = memoryVolume;
        }
    }
}
