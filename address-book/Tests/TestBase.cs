﻿using System;
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
    }
}
