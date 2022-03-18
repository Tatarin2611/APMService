using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMService.ServiceFolder
{
    public class RandomClass
    {
        public static string Saver = null;
        public static string Rand(int lenght)
        {
            string cif = "qwertyuiopasdfghjklzxcvbnm1234567890" +
                "QWERTYUIOPASDFGHJKLZXCVBNM";
            string result = "";
            Random rnd = new Random();
            for (int i = 1; i <= lenght; i++)
            {


                result += cif[rnd.Next(0, cif.Length)];
            }
            return result;
        }
    }
}
