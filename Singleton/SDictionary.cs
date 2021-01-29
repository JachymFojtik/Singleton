using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Singleton
{
    class SDictionary
    {
        static SDictionary singleSingletonDictionary = null;
        static Dictionary<string, string[]> DictHumans;
        static readonly object lockingObject = new object();
        public string[] HumanInfo(string name, string surname, string birthday, string birthnum)
        {
            return new string[4] { name, surname, birthday, birthnum };
        }
        SDictionary()
        {
            DictHumans = new Dictionary<string, string[]>
            {
                ["Pepa"] = HumanInfo("Pepa", "Novák", "5.4.2001", "010405/146"),
                ["Adam"] = HumanInfo("Adam", "Novotný", "7.12.1999", "991207/784"),
                ["Petr"] = HumanInfo("Petr", "Němec", "14.6.2000", "000614/340"),
                ["Čeněk"] = HumanInfo("Čeněk", "Lhoták", "14.6.2000", "000614/340")
            };
        }
        public static SDictionary Instance
        {
            get
            {
                lock (lockingObject)
                {
                    if (singleSingletonDictionary == null)
                    {
                        singleSingletonDictionary = new SDictionary();
                    }
                }
                MessageBox.Show("Dictionary Already Exists");
                return singleSingletonDictionary;
            }

        }

        public void View(string key, TextBox tb)
        {
            foreach (string item in DictHumans[key])
            {
                tb.Text += item;
                tb.Text += " ";
            }
            tb.Text += "\n";
        }
    }
}
