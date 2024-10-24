using ToDoList.Data;
using ToDoList.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ToDoList.Controllers.Tests
{
    [TestClass]
    public class TodoControllerTests
    {
        TodoController controller = new TodoController(new Mock<IToDoRepo>().Object);

        [TestMethod]
         public void PostEntryTest()
        {
            var name = "testing...";
            var response = controller.PostEntry(new Entry(name));

            var result = response.Result.Result as CreatedAtActionResult;
            var entry = result?.Value as Entry;

            Assert.IsNotNull(result);
            Assert.IsNotNull(entry);
            Assert.AreEqual(entry.Name, name);
            Assert.IsFalse(entry.IsCompleted);
        }
    }
}