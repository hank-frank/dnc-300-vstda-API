using Microsoft.VisualStudio.TestTools.UnitTesting;
using dnc_300_vstda_api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnc_300_vstda_api.Models;

namespace dnc_300_vstda_api.Controllers.Tests
{
    [TestClass()]
    public class TodosControllerTests
    {
        TodosController tc = new TodosController();
        List<Todo> mockTodos = new List<Todo>()
        {
            new Todo(0, "an item", 3, false),
            new Todo(1, "another item", 2, false),
            new Todo(2, "a done item", 1, true),
        };

        [TestMethod()]
        public void GetTest()
        {
            List<Todo> todos = (List<Todo>)tc.Get();
            for (int i = 0; i < mockTodos.Count; i++)
            {
                Assert.AreEqual(mockTodos[i], todos[i]);
            }
        }

        [TestMethod()]
        public void GetByIDTest()
        {
            Todo todo = tc.Get(1);
            Assert.AreEqual(mockTodos[1], todo);
        }

        [TestMethod()]
        public void PostTest()
        {
            Todo mockTodo = new Todo(3, "yet another item", 3, false);
            int initTodoCount = tc.Get().Count();
            Todo newTodo = tc.Post(mockTodo);
            Assert.AreEqual(mockTodo, newTodo);
            Assert.AreEqual(initTodoCount + 1, tc.Get().Count());
        }

        [TestMethod()]
        public void PutTest()
        {
            Todo mockTodo = new Todo(0, "an updated item", 2, false);
            Todo updatedTodo = tc.Put(mockTodo.todoItemId, mockTodo);
            Assert.AreEqual(mockTodo, updatedTodo);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Todo mockTodo = new Todo(0, "an updated item", 2, false);
            int initTodoCount = tc.Get().Count();
            Todo deletedTodo = tc.Delete(0);
            Assert.AreEqual(mockTodo, deletedTodo);
            Assert.AreEqual(initTodoCount - 1, tc.Get().Count());
        }
    }
}