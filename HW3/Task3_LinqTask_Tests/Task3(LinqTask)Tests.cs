using System;
using NUnit.Framework;

namespace Task3_LinqTask_
{
    public class Tests
    {
        private BusinessLogic businessLogic = new BusinessLogic();

        [Test, Order(1)]
        public void GetUsersBySurname()
        {
            Assert.AreEqual("Strazov", businessLogic.GetUsersBySurname("Strazov")[0].Surname);
        }

        [Test, Order(2)]
        public void GetUserByID()
        {
            Assert.AreEqual(businessLogic.GetUser(0), businessLogic.GetUserByID(235));
            Assert.Throws<NotImplementedException>(() => businessLogic.GetUserByID(333));
        }

        [Test, Order(3)]
        public void GetUsersBySubstring()
        {
            Assert.Contains(businessLogic.GetUser(4), businessLogic.GetUsersBySubstring("trova"));
        }

        [Test]
        public void GetAllUniqueNames()
        {
            Assert.AreEqual(5, businessLogic.GetAllUniqueNames().Count);
        }

        [Test]
        public void GetAllAuthors()
        {
            Assert.AreEqual(4, businessLogic.GetAllAuthor().Count);
        }

        //[Test]
        //public void GetUsersDictionary()
        //{
        //    Assert.AreEqual(4, businessLogic.GetUsersDictionary().Count);
        //}

        [Test]
        public void GetMaxID()
        {
            Assert.AreEqual(businessLogic.GetUser(2).ID, businessLogic.GetMaxID());
            Assert.AreNotEqual(businessLogic.GetUser(3).ID, businessLogic.GetMaxID());
        }

        [Test]
        public void GetOrderedUsers()
        {
            Assert.AreEqual(businessLogic.GetUser(0), businessLogic.GetOrderedUsers()[0]);
            Assert.AreEqual(businessLogic.GetUser(1), businessLogic.GetOrderedUsers()[1]);
            Assert.AreEqual(businessLogic.GetUser(3), businessLogic.GetOrderedUsers()[2]);
            Assert.AreEqual(businessLogic.GetUser(4), businessLogic.GetOrderedUsers()[3]);
            Assert.AreEqual(businessLogic.GetUser(2), businessLogic.GetOrderedUsers()[4]);
        }

        [Test]
        public void GetDescendingOrderedUsers()
        {
            Assert.AreEqual(businessLogic.GetUser(2), businessLogic.GetDescendingOrderedUsers()[0]);
            Assert.AreEqual(businessLogic.GetUser(4), businessLogic.GetDescendingOrderedUsers()[1]);
            Assert.AreEqual(businessLogic.GetUser(3), businessLogic.GetDescendingOrderedUsers()[2]);
            Assert.AreEqual(businessLogic.GetUser(1), businessLogic.GetDescendingOrderedUsers()[3]);
            Assert.AreEqual(businessLogic.GetUser(0), businessLogic.GetDescendingOrderedUsers()[4]);
        }

        [Test]
        public void GetReversedUsers()
        {
            Assert.AreEqual(businessLogic.GetUser(4), businessLogic.GetReversedUsers()[0]);
            Assert.AreEqual(businessLogic.GetUser(3), businessLogic.GetReversedUsers()[1]);
            Assert.AreEqual(businessLogic.GetUser(2), businessLogic.GetReversedUsers()[2]);
            Assert.AreEqual(businessLogic.GetUser(1), businessLogic.GetReversedUsers()[3]);
            Assert.AreEqual(businessLogic.GetUser(0), businessLogic.GetReversedUsers()[4]);
        }

        [Test]
        public void GetUsersPage()
        {
            Assert.AreEqual(1, businessLogic.GetUsersPage(1, 4).Count);
        }
    } 
}