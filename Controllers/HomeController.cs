using LinqQueryEf.Models.DB_EF;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Web.Mvc;
using System.Collections.Generic;

namespace LinqQueryEf.Controllers
{
    public class HomeController : Controller
    {
        // MongoDB connection string
        private const string connectionUri = "mongodb+srv://ragul:Ipwfj5e03Ik2Uj2Y@cluster0.4ppe5l0.mongodb.net/?retryWrites=true&w=majority";
        private IMongoDatabase database;
        private IMongoCollection<EmpDetails> empCollection;

        public HomeController()
        {
            var client = new MongoClient(connectionUri);
            database = client.GetDatabase("MyDatabase"); // Use your MongoDB DB name
            empCollection = database.GetCollection<EmpDetails>("EmpDetails"); // Collection name
        }

        // Index page
        public ActionResult Index()
        {
            return View();
        }

        // Insert employee
        [HttpPost]
        public ActionResult InsertRecords(EmpDetails form)
        {
            empCollection.InsertOne(form);
            TempData["Alertmsg"] = "Inserted Successfully";
            return RedirectToAction("Index");
        }

        // View all employees
        public ActionResult ViewEmployee()
        {
            var selectData = empCollection.Find(new BsonDocument()).ToList();
            return View(selectData);
        }
        public ActionResult UpdateEmployee()
        {
            var selectdata = empCollection.Find(new BsonDocument()).ToList();
            return View(selectdata);
        }
        // View particular employee (Partial View)
        public ActionResult View_Employee(string id)
        {
            var employee = empCollection.Find(e => e.Id == id).FirstOrDefault();
            return PartialView("View_Employee", employee);
        }

        // Update employee
        [HttpPost]
        public ActionResult Update_Employee(string id, string empusername, string empemail, string emppassword)
        {
            var filter = Builders<EmpDetails>.Filter.Eq(e => e.Id, id);
            var update = Builders<EmpDetails>.Update
                .Set(e => e.empusername, empusername)
                .Set(e => e.empemail, empemail)
                .Set(e => e.emppassword, emppassword);

            var result = empCollection.UpdateOne(filter, update);
            TempData["Alertmsg"] = result.ModifiedCount > 0 ? "Employee updated successfully!" : "Employee not found!";
            return RedirectToAction("ViewEmployee");
        }

        // Delete employee
        public ActionResult DeleteEmployee(string id)
        {
            var result = empCollection.DeleteOne(e => e.Id == id);
            TempData["Alert"] = result.DeletedCount > 0 ? "Deleted Successfully" : "Employee not found!";
            return RedirectToAction("ViewEmployee");
        }
    }
}
