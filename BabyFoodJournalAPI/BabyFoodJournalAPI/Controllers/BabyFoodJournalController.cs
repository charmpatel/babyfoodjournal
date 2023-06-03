using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Data.SqlClient;

using System.Threading.Tasks;


namespace BabyFoodJournalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BabyFoodJournalController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BabyFoodJournalController> _logger;

        public BabyFoodJournalController(ILogger<BabyFoodJournalController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<BabyFoodJournal> Get()
        {
            IList<BabyFoodJournal> babyFoodJournal = new List<BabyFoodJournal>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "."; 
                builder.IntegratedSecurity = true;
                builder.InitialCatalog = "BabyFoodJournal";
                builder.TrustServerCertificate = true;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    String sql = "SELECT * FROM BabyFoodJournal.dbo.FoodEntries";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                babyFoodJournal.Add(new BabyFoodJournal { Id = reader.GetString(0), Date = reader.GetDateTime(1), Notes = reader.GetString(2), FoodEntry = reader.GetString(3), CreatedAt = reader.GetDateTime(4), UpdatedAt = reader.GetDateTime(5) });
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return babyFoodJournal;
        }

        [HttpPost]
        public HttpPostAttribute AddBabyFoodEntry(BabyFoodJournal babyfoodentry)
        {
            // this is a new baby food entry 
            // We have to generate a new unique id (generate guid) 
            // save this record to database. 



            return null;
        }

        [HttpPut]
        public HttpPutAttribute UpdateBabyFoodEntry(BabyFoodJournal babyfoodentry)
        {
            return null;
        }

        [HttpDelete]
        public HttpDeleteAttribute DeleteBabyFoodEntry(BabyFoodJournal babyfoodentry)
        {
            return null;
        }

    }

}






