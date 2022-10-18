using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

//  1.Визначити абстрактний клас(або інтерфейс) «телефон» (назва, фірма, ціна).
//  Визначити 2 похідні від нього класи: «мобільний телефон» (колір, об’єм пам’яті ), «радіотелефон» (радіус дії, наявність автовідповідача).
//  У двох текстових файлах задано дані про телефони двох різних фірм.
//  Зчитати ці дані в один масив  і вивести у текстовий файл:
//  1)всі телефони, посортовані за ціною із зазначенням загальної суми;
//  2) радіотелефони з автовідповідачем

//  Розробити консольну(або WindowsForms або WPF) програму для розв’язування поставленої задачі. 
//  Підключити StyleCop та виправити всі його зауваження, також код писати, дотримуючись Clean Code
//  Створити додатковий проект для юніт тестування, в який додаємо юніт тести для розробленого коду
//  Введення-виведення здійснювати в файл, крім того передбачити сериалізацію-десериалізацію даних в xml (json) форматах
//  Реалізувати перехоплення ексепшинів з їх логування у файли з допомогою одного з логерів ( пр. Log4net)

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace FinalTask
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static List<Telephone> ReadFile(string filePath)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Telephone>));
            Stream stream = new FileStream(filePath, FileMode.Open);
            List<Telephone> telephones = xml.Deserialize(stream) as List<Telephone>;
            return telephones;
        }
        static void SaveToFile(List<Telephone> telephones, string filePath)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Telephone>));
            Stream stream = new FileStream(filePath, FileMode.Create);
            formatter.Serialize(stream, telephones);
            stream.Close();
        }
        static void Main(string[] args)
        {
            List<Telephone> telephones = new List<Telephone>();

            List<Telephone> сompanyTelephone1 = new List<Telephone>();
            string fileNameToRead1 = "iPhone.xml";
            сompanyTelephone1 = ReadFile(fileNameToRead1);
            if (сompanyTelephone1.Count == 0)
                log.Error($"The file {fileNameToRead1} is empty");
            else
                telephones.AddRange(сompanyTelephone1);

            List<Telephone> сompanyTelephone2 = new List<Telephone>();
            string fileNameToRead2 = "Samsung.xml";
            сompanyTelephone2 = ReadFile(fileNameToRead2);
            if (сompanyTelephone2.Count == 0)
                log.Error($"The file {fileNameToRead2} is empty");
            else
                telephones.AddRange(сompanyTelephone2);

            telephones.Sort();
            string fileNameToSave1 = "sortTelephones.xml";
            SaveToFile(telephones, fileNameToSave1);

            List<Telephone> radioTelephonesWithAnsweringMachine = new List<Telephone>();
            foreach (Telephone telephone in telephones)
            {
                if (telephone is RadioTelephone)
                {
                    RadioTelephone radioTelephone = telephone as RadioTelephone;
                    if (radioTelephone.PresenceOfAnsweringMachine)
                        radioTelephonesWithAnsweringMachine.Add(telephone);
                }
            }
            string fileNameToSave3 = "radioTelephone.xml";
            SaveToFile(radioTelephonesWithAnsweringMachine, fileNameToSave3);
            log.Debug("Done");
        }
    }
}
