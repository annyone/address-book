using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace address_book_tests
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetupAppManager()
        {
            app = AppManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            Random rnd = new Random();
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223))); 

            }

            return builder.ToString();
        }
    }
}
