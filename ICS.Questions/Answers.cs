using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Questions
{
    
    public class Answers
    {
        //Question # 2
        public void Answer2()
        {
            string someString = "Orange";
            Fruit? someFruit = someString.ConvertToEnum<Fruit>();
        }

        //Question # 3
        public string[] Answer3(List<string[]> lisOfArray)
        {
            return lisOfArray.SelectMany(s=>s).Distinct().ToArray();
        }
    }
}
