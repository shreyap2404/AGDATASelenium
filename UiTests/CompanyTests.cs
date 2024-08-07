using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UiTests
{
    

    [TestFixture]
    public class CompanyTests : BaseTest
    {
        private CompanyPage _companyPage;
        private ContactPage _contactPage;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp();
            _companyPage = new CompanyPage(Driver);
            _contactPage = new ContactPage(Driver);
        }

        [Test]
        public void VerifyCompanyOverviewPageAndContactNavigation()
        {
            _companyPage.NavigateToOverview();
            var values = _companyPage.GetPageValues();
            Assert.IsNotEmpty(values, "The values on the overview page should not be empty.");

            _companyPage.ClickGetStarted();
            Assert.IsTrue(_contactPage.IsContactPageDisplayed(), "Contact page should be displayed.");
        }
    }

}
