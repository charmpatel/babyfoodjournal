using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyFoodJournalAPI
{
    public class BabyFoodJournal
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }

        public string Notes { get; set; }
        public string FoodEntry { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
