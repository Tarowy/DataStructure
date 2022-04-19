using System;

namespace DataStructure.OrderlyArray_Search
{
    public class Student: IComparable<Student>
    {
        private string _name;
        private int _tall;

        public Student(string name, int tall)
        {
            _name = name;
            _tall = tall;
        }

        public override string ToString()
        {
            return $"{_name} : {_tall}";
        }


        public int CompareTo(Student other)
        {
            if (this._tall > other._tall) return 1;
            if (this._tall < other._tall) return -1;
            return 0;
        }
    }
}