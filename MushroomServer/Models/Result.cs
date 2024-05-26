using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MushroomServer.Models
{
    public class Result
    {
        [Key]
        public string ResultID { get; set; }
        public string Status { get; set; }
        public string P1BattleLogString { get; set; }
        public string P2BattleLogString { get; set; }
        public string OriginalCharacter1 { get; set; }
        public string OriginalCharacter2 { get; set; }

        public Result() { } // For EntityFramework
    }
}
