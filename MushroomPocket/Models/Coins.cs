using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MushroomServer.Models
{
    public class Coins
    {
        [Key]
        public string GUID { get; set; }
        public int Amount { get; set; }

        public Coins() { } // For EntityFramework
        public Coins(int amount)
        {
            GUID = Guid.NewGuid().ToString();
            Amount = amount;
        }
    }
}
