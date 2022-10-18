using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalTask
{
    [XmlInclude(typeof(RadioTelephone)), XmlInclude(typeof(MobilePhone))]
    public abstract class Telephone : IComparable
    {
        private string name;
        private string firm;
        private float price;
        public string Name { get { return name; } set { name = value; } }
        public string Firm { get { return firm; } set { firm = value; } }
        public float Price { get { return price; } set { price = value; } }
        public Telephone()
        {
            this.name = "no name";
            this.firm = "no firm";
            this.price = 0;
        }
        public Telephone(string name, string firm, float price)
        {
            this.name = name;
            this.firm = firm;
            this.price = price;
        }

        public int CompareTo(object obj)
        {
            Telephone telephone = obj as Telephone;
            if (telephone == null)
                throw new ArgumentException("Object is not a telephone");
            else
                return (int) telephone.price*100 - (int) this.price*100;
        }
    }
}
