using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using ContactManager.Controllers;
using ContactManager.Infrastructure;
using ContactManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactManager.Tests
{
    [TestClass]
    public class ContactControllerTest
    {
        Mock<IContactRepository> _contactRepository;
        ContactController contactController;
        List<Contact> _contacts;

        #region Constructor
        public ContactControllerTest()
        {
            _contactRepository = new Mock<IContactRepository>();
            contactController = new ContactController(_contactRepository.Object);
        }

        #endregion Constructor

        #region Private Methods
        private List<Contact> MockContacts()
        {
            List<Contact> mockContacts = new List<Contact>()
            {
                new Contact()
                {
                    Id = 1,
                    FirstName = "Mak",
                    LastName = "Lakinson",
                    PhoneNumber = "23-343334454",
                    Email = "mak@lakinson.com",
                    Status = true
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = "Pat",
                    LastName = "Parkson",
                    PhoneNumber = "34-5465477886",
                    Email = "pat@parkson.com",
                    Status = false
                }
            };

            return mockContacts;
        }

        #endregion Private Methods

        #region Initialize Data
        [TestInitialize]
        public void InitializeMockData()
        {
            _contacts = MockContacts();
        }

        #endregion Initialize Data

        #region GetById Tests
        [TestMethod]
        public void Get_Returns_Contact_With_Same_Id()
        {            
            _contactRepository.Setup(c => c.Get(1)).Returns(_contacts.Where(c => c.Id == 1).First());

            IHttpActionResult result = contactController.Get(1);

            var okResult = result as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(okResult);
            Assert.IsNotNull(okResult.Content);
            Assert.AreEqual(1, okResult.Content.Id);
        }        

        [TestMethod]
        public void Get_Returns_Notfound()
        {
            IHttpActionResult result = contactController.Get(1);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        #endregion GetById Tests

        #region GetAll Tests
        [TestMethod]
        public void GetAll_Returns_Contacts()
        {
            _contactRepository.Setup(c => c.GetAll()).Returns(_contacts.AsQueryable());

            IEnumerable<Contact> result = contactController.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetAll_Returns_No_Contacts()
        {
            IEnumerable<Contact> result = contactController.Get();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        #endregion GetAll Tests

        #region Create Tests
        [TestMethod]
        public void Post_Creates_New_Contact()
        {
            IHttpActionResult result = contactController.Post(new Contact() { Id = 40, FirstName = "Ambrish", LastName = "Atlapure", Email = "ambrish@atlapure.com", PhoneNumber = "324324234234", Status = true });
            var createdResult = result as CreatedAtRouteNegotiatedContentResult<Contact>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(40, createdResult.RouteValues["id"]);
        }

        [TestMethod]
        public void Post_Returns_BadRequest()
        {
            IHttpActionResult result = contactController.Post(null);

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        #endregion Create Tests

        #region Update Tests
        [TestMethod]
        public void Put_Updates_Existing_Contact()
        {
            _contactRepository.Setup(c => c.Get(1)).Returns(_contacts.Where(c => c.Id == 1).First());

            IHttpActionResult result = contactController.Put(1, new Contact() { Id = 1, FirstName = "Updated fname", LastName = "Updated lname", Email = "updupdated.com", PhoneNumber = "113232323", Status = true });
            var contentResult = result as NegotiatedContentResult<Contact>;

            Assert.IsNotNull(contentResult);
            Assert.AreEqual("Updated fname", contentResult.Content.FirstName);
        }

        #endregion Update Tests

        #region Delete Tests
        [TestMethod]
        public void Delete_Returns_ok()
        {
            _contactRepository.Setup(c => c.GetAll()).Returns(_contacts.AsQueryable());
            IHttpActionResult result = contactController.Delete(2);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void Delete_Returns_NotFound()
        {
            _contactRepository.Setup(c => c.GetAll()).Returns(_contacts.AsQueryable());
            IHttpActionResult result = contactController.Delete(42);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        #endregion Delete Tests
    }
}
