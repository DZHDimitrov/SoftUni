using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            FamilyList = new List<Person>();
        }
        public List<Person> FamilyList { get; set; }

        public void AddMember(Person person)
        {
            FamilyList.Add(person);
        }
        public Person GetOldestMember(List<Person> people)
        {
            return people.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
