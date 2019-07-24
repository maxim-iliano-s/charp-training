using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : BaseHelper
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create()
        {
            InitContactCreation();
            SubmitContactCreation();
            return this;
        }

        internal ContactHelper ContactModification(int contact_id, ContactData contact)
        {

            /*if (!IsContactPresent())
                {
                ContactData cont = new ContactData() { };
                Create();
                v = 1;
                }*/

            //IsContactPresent_2(contact_id);
            CountPresentContact(contact_id);


            SelectContact(contact_id);
            EditContactForm(contact);
            SubmitContactModification();
            return this;
        }


        internal int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry'] td:nth-child(2)")).Count;
        }


        private List<ContactData> contactCahce = null;

        public List<ContactData> GetContactsList()
        {
            if (contactCahce == null)
            {
                contactCahce = new List<ContactData>();
                manager.Navigator.GoToHomePage();

                ICollection<IWebElement> lName = driver.FindElements(By.CssSelector("tr[name='entry'] td:nth-child(2)"));
                ICollection<IWebElement> fName = driver.FindElements(By.CssSelector("tr[name='entry'] td:nth-child(3)"));
                for (int i = 0; i < lName.Count(); i++)
                {
                    contactCahce.Add(new ContactData(fName.ElementAt(i).Text, lName.ElementAt(i).Text));
                }
            }

            //for (int i=0; i<lName.Count();i++)
            //{
            //   contacts.Add(new ContactData(fName.ElementAt(i).Text, lName.ElementAt(i).Text));
            //}

            /*foreach (IWebElement element in fName)
            {
                //++index;
                contacts.Add(new ContactData(element.Text, lName.ElementAt(index++).Text));
                //Console.WriteLine("contacts firstname Text: " + element.Text);
            }*/

            return new List<ContactData>(contactCahce);
        }

        public void DisplayContact()
        {
            manager.Navigator.GoToHomePage();
            Console.WriteLine("contacts td:nth-child(4) Text: " + driver.FindElement(By.CssSelector("tr[name='entry'] td:nth-child(4)")).Text);
        }


        public ContactHelper IsContactPresent_2(int contact_id)
        {
            if(!IsElementPresent(By.Name("selected[]")))
            {
                //ContactData cont = new ContactData() { };
                Create(new ContactData());
                
                return this;
            }
        return this;
        }

        public ContactHelper EditContactForm(ContactData contact)
        {
            /*driver.FindElement(By.CssSelector("input[name=\"firstname\"]")).Click();
            driver.FindElement(By.CssSelector("input[name=\"firstname\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"firstname\"]")).SendKeys(contact.Firstname);
            driver.FindElement(By.CssSelector("input[name=\"lastname\"]")).Click();
            driver.FindElement(By.CssSelector("input[name=\"lastname\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"lastname\"]")).SendKeys(contact.Lastname);
            driver.FindElement(By.CssSelector("textarea[name=\"address\"]")).Click();
            driver.FindElement(By.CssSelector("textarea[name=\"address\"]")).Clear();
            driver.FindElement(By.CssSelector("textarea[name=\"address\"]")).SendKeys(contact.Address);*/

            Type(By.CssSelector("input[name=\"firstname\"]"), contact.Firstname);
            Type(By.CssSelector("input[name=\"lastname\"]"), contact.Lastname);
            Type(By.CssSelector("textarea[name=\"address\"]"), contact.Address);

            return this;
        }

        public ContactHelper SelectContact(int contact_id)
        {
            ++contact_id;
            driver.FindElement(By.XPath("//a[contains(text(),'home')]")).Click();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + contact_id + "]/td/input")).Click();
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//img[@title='Edit']")).Click();

            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCahce = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@name='update']")).Click();
            //driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCahce = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"),contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"),contact.Mobile);
            Type(By.Name("email"),contact.Email);
            Type(By.Name("homepage"),contact.Homepage);

            // --> Day of the Birth
            //driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
           // new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.CssSelector("option[value=\"" + contact.Bmonth + "\"]")).Click();
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.CssSelector("option[value=\"" + contact.Bday + "\"]")).Click();
            Type(By.Name("byear"), contact.Byear);
            // <-- Day of the Birth
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        private bool acceptNextAlert = true;

        //public ContactHelper Remove(int index)

        public ContactHelper Remove(int contact_id)
        {
            //manager.Navigator.GoToHomePage();
            //++index;
            driver.FindElement(By.XPath("//a[contains(text(),'home')]")).Click();
            //driver.FindElement(By.CssSelector("a:value='home'")).Click();
            //IsContactPresent_2();
            CountPresentContact(contact_id);
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + contact_id + "]/td/input")).Click();
acceptNextAlert = true;
            //driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            contactCahce = null;
            return this;
        }

        public ContactHelper CountPresentContact(int contact_id)
        {
            manager.Navigator.GoToHomePage();
            int contactCount = driver.FindElements(By.Name("selected[]")).Count();
            if (contact_id > contactCount)
            {
                for (int i = 1; i <= contact_id; i++)
                {
                    ContactData cont = new ContactData() { };
                    Create();
                    //return this;
                }
                manager.Navigator.GoToHomePage();
            }
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}