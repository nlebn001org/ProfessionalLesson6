using System;
using Library;

namespace ProfessionalLesson6Task2
{    
    // Задание переделал под себя, чтобы лучше понять тему рефлексии. 
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("Sean", 15);
            c1.Buy(7);
            c1.Buy(15);
        }
    }
}
