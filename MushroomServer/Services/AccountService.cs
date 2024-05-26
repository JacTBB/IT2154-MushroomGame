// Jackie Soon 221139Y //
using MushroomServer.Models;

namespace MushroomServer.Services
{
    public class AccountService
    {
        #region Singleton
        private static readonly AccountService instance = new AccountService();
        public static AccountService Instance { get { return instance; } }

        private AccountService() { }
        #endregion

        public DBContext dbContext = new DBContext();
        public Dictionary<string, Player> PlayerSessions { get; set; } = new Dictionary<string, Player>();

        /// <summary>
        /// Login into a multiplayer user.
        /// </summary>
        public string Login(string username, string password)
        {
            Player? player = dbContext.Players.FirstOrDefault(p => p.Username == username && p.Password == password);

            if (player == null)
            {
                return "";
            }

            string connectId = Guid.NewGuid().ToString();
            PlayerSessions.Add(connectId, player);

            return connectId;
        }

        /// <summary>
        /// Registers a new multiplayer user.
        /// </summary>
        public bool Register(string username, string password)
        {
            Player? usernameCheck = dbContext.Players.FirstOrDefault(p => p.Username == username);

            if (usernameCheck != null)
            {
                return false;
            }

            Player player = new Player(username, password);
            dbContext.Add(player);
            dbContext.SaveChanges();

            if (player == null)
            {
                return false;
            }
            return true;
        }
    }
}
