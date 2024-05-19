using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MushroomPocket.Models
{
    public class Coins
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }

        public Coins() { } // For EntityFramework
        public Coins(int amount)
        {
            Id = 1;
            Amount = amount;
        }
    }
}
