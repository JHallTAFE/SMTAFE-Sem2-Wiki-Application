using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wiki_Application
{
    // Programming Criteria 6.1
    public class Information : IComparable<Information>
    {
        private string _name;
        private string _category;
        private string _structure;
        private string _definition;

        public Information()
        {
            _name = String.Empty;
            _category = String.Empty;
            _structure = String.Empty;
            _definition = String.Empty;
        }

        public Information(string name, string category, string structure, string definition)
        {
            _name = name;
            _category = category;
            _structure = structure;
            _definition = definition;
        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public string GetCategory() {
            return _category;
        }
        public void SetCategory(string category)
        {
            _category = category;
        }
        public string GetStructure()
        {
            return _structure;
        }
        public void SetStructure(string structure)
        {
            _structure = structure;
        }
        public string GetDefinition()
        {
            return _definition;
        }
        public void SetDefinition(string definition) {
            _definition = definition;
        }
        public int CompareTo(Information info)
        {
            return _name.CompareTo(info._name);
        }
    }
}