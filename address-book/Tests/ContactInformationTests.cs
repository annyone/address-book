using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace address_book_tests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void CompareContactInfoFromTableAndFormTest()
        {
            ContactData fromTable = app.Contacts.GetContactInfoFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInfoFromForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void CompareContactInfoFromFormAndDetailsTest()
        {
            ContactData fromDetails = app.Contacts.GetContactInfoFromDetails(0);
            ContactData fromForm = app.Contacts.GetDetailsContactInfoFromForm(0);

            Assert.AreEqual(fromDetails.DetailsInfo, fromForm.DetailsInfo);
        }
    }
}
