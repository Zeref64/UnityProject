using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

    [System.Serializable]
    public class ContactData
    {
        public string Name;
        public string Number;

        public ContactData(string name, string number)
        {
            Name = name;
            Number = number;
        }
    }

