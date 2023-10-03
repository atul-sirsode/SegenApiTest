using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using SegenApi.Models;

namespace SegenApi.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        [HttpGet]
        public List<Item> GetItems()
        {
            var items = new List<Item>();

            using (var conn = new SqlConnection("Server=localhost;Database=segenDev;Trusted_Connection=true;"))
            {
                var sqlCommand = new SqlCommand("SELECT * FROM Items", conn);
                conn.Open();

                var reader = sqlCommand.ExecuteReader(CommandBehavior.Default);

                while (reader.Read())
                    items.Add(new Item
                    {
                        Id = reader.GetGuid("Id"),
                        Name = reader.GetString("Name"),
                        Description = reader.GetString("Description"),
                        Price = reader.GetDecimal("Price"),
                        CreatedAt = reader.GetDateTime("CreatedAt"),
                        ModifiedAt = reader.GetDateTime("ModifiedAt")
                    });
            }

            return items;
        }
    }
}