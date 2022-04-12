
using MongoDB.Bson;
using MongoDB.Driver;
using MongoTest;
using System.Linq;

MongoClient _client = new MongoClient("mongodb+srv://dbUser:Ee21ert34rfv@mongocluster1.3slgp.mongodb.net/test");

var database = _client.GetDatabase("MongoProjectDb");
var categoryCollection = database.GetCollection<Category>("Categories"); 
var categoryList = categoryCollection.Find(u=>u.CategoryName != null).ToList();

foreach (var category in categoryList)
{
    Console.WriteLine(category.CategoryName);
}