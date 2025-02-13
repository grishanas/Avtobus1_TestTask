using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CodeGenerator
    {
        const string chars = "ABCEDFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890@$&";
        Random random = new Random();
        public CodeGenerator() 
        {

        }  
        public string Generate()
        {

            var randomString = new string(Enumerable.Repeat(chars, 9)
                .Select(x => x[random.Next(x.Length)])
                .ToArray()
            );
            return randomString;
        }
    }
}
