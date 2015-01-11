using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroDAL;
using System.Collections.Generic;

namespace PomodoroUnitTest
{
    [TestClass]
    public class PomodoroDALUnitTest
    {
        [TestMethod]
        // [IgnoreAttribute]
        public void TestClearDB()
        {
            // Arrange:
            Methods methods = new Methods();

            // Act:
            methods.ClearDB();
            int expected = 0;
            int actual = methods.GetEntries().Count;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // [IgnoreAttribute]
        public void TestInitDB()
        {
            // Arrange:
            Methods methods = new Methods();

            // Act:
            methods.InitDB();
            string expected = "8 10 8";
            string actual = String.Format("{0} {1} {2}", methods.GetEntries().Count, methods.GetTags().Count, methods.GetComments().Count);

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestAddNewComment()
        {
            // Arrange:
            Methods methods = new Methods();
            Entry entry = new Entry() { Description = "This is a description.", Timestamp = DateTime.UtcNow };
            entry = methods.AddNewEntry(entry);
            Comment comment = new Comment() { Content = "This is a comment.", Entry = entry };

            // Act:
            string expected = comment.Content;
            string actual = methods.AddNewComment(comment).Content;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestAddNewEntry()
        {
            // Arrange:
            Methods methods = new Methods();
            string description = String.Format("This is a description added at {0}", DateTime.UtcNow);
            Entry newEntry = new Entry() { Description = description, Timestamp = DateTime.UtcNow };

            // Act:
            string expected = description;
            string actual = methods.AddNewEntry(newEntry).Description;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestAddNewEntryFromElements()
        {
            // Arrange:
            Methods methods = new Methods();
            DateTime timestamp = DateTime.UtcNow;
            string description = String.Format("This is a description created at {0}", timestamp);
            string tags = "Test_001, Test_002, Test_003 Test_004";
            
            // Act:
            string expected = description;
            string actual = methods.AddNewEntryFromElements(timestamp, description, tags).Description;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestAddNewTag()
        {
            // Arrange:
            Methods methods = new Methods();
            string tagName = String.Format("{0}", DateTime.UtcNow);

            // Act:
            string expected = tagName;
            string actual = methods.AddNewTag(tagName).TagName;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestGetEntryById()
        {
            // Arrange:
            Methods methods = new Methods();
            methods.InitDB();
            Entry entryInDB = methods.GetEntries()[0];

            // Act:
            int expected = entryInDB.Id;
            int actual = methods.GetEntryById(entryInDB.Id).Id;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestUpdateEntry()
        {
            // Arrange:
            Methods methods = new Methods();

            methods.InitDB();

            Entry entry = methods.GetEntries()[0];
            string updatedDescription = String.Format("{0} was modified at {1}", entry.Description, DateTime.UtcNow);
            entry.Description = updatedDescription;

            // Act:
            methods.UpdateEntry(entry);

            string expected = updatedDescription;
            string actual = methods.GetEntryById(entry.Id).Description;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestGetEntries()
        {
            // Arrange:
            Methods methods = new Methods();

            methods.InitDB();

            // Act:
            int expected = 8;
            int actual = methods.GetEntries().Count;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestGetTags()
        {
            // Arrange:
            Methods methods = new Methods();

            methods.InitDB();

            // Act:
            int expected = 10;
            int actual = methods.GetTags().Count;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        public void TestGetComments()
        {
            // Arrange:
            Methods methods = new Methods();

            methods.InitDB();

            // Act:
            int expected = 8;
            int actual = methods.GetComments().Count;

            // Assert:
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        // [IgnoreAttribute]
        [ExpectedException(typeof(System.Data.Entity.Infrastructure.DbUpdateConcurrencyException))]
        public void TestOptimisticConcurrency()
        {
            // Arrange:
            Methods methods = new Methods();

            methods.InitDB();

            Entry entryAtDavid = methods.GetEntries()[0];
            Entry entryAtRoger = methods.GetEntryById(entryAtDavid.Id);

            entryAtDavid.Description = String.Format("{0} was modified at {1} by David", entryAtDavid.Description, DateTime.UtcNow);
            entryAtRoger.Description = String.Format("{0} was modified at {1} by Roger", entryAtRoger.Description, DateTime.UtcNow);

            // Act:
            methods.UpdateEntry(entryAtRoger);
            methods.UpdateEntry(entryAtDavid);

            // Assert:
            // We will never get here
        }
    
    
    
    }
}
