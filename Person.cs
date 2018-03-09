using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//Életkor változáskor értesítést küld --> delegate

namespace beagyki2
{
    // 1
    public delegate void AgeChangingDelegate(int oldAge,
                                            int newAge
                                            );
    [XmlRoot("Ember")]
    public class Person
    {

        // 2
        public event AgeChangingDelegate AgeChanging;

        private int age;
        [XmlAttribute("Eletkor")]
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                // 3 változás értesítés előtt
                AgeChanging?.Invoke(age, value);    //Changed, if we do after age=value
                age = value;
            }
        }
        [XmlIgnore]
        public string Name { get; set; }    // name+get,set in one line; private set to only read outside
        public int SzuletesiEv              //read only property
        {
            get
            {
                return DateTime.Today.Year - age;
            }
        }
    }
}
