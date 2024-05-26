using MushroomServer.Models;
using MushroomServer.Models.Characters;
using System.Globalization;
using System.Net.WebSockets;

namespace MushroomServer.Services
{
    public class GameService
    {
        private WebsocketService websocketService = WebsocketService.Instance;
        private DBContext dbContext = AccountService.Instance.dbContext;
        private Player player;
        private string connectId;
        public bool Stopped = false;
        public static List<MushroomMaster> MushroomMastersList;

        public GameService(Player _player, string _connectId)
        {
            player = _player;
            connectId = _connectId;
        }

        #region Websocket
        private void SendData(string data)
        {
            websocketService.SendData(connectId, data);
        }

        private async Task<string> GetResponse(string data)
        {
            string response = await websocketService.GetResponse(connectId, "Get;"+data);
            return response;
        }
        #endregion

        public async void Main()
        {
            //MushroomMaster criteria list for checking character transformation availability.   
            List<MushroomMaster> mushroomMasters = new List<MushroomMaster>(){
            new MushroomMaster("Daisy", 2, "Peach"),
            new MushroomMaster("Wario", 3, "Mario"),
            new MushroomMaster("Waluigi", 1, "Luigi")
            };
            MushroomMastersList = mushroomMasters;

            SendData($"Hello {player.Username}. Welcome to Multiplayer!");
            while (Stopped == false)
            {
                if (!await Menu())
                {
                    break;
                }
            }
            websocketService.CloseWebsocket(connectId);
        }

        private async Task<bool> Menu()
        {
            SendData(new String('*', 30));
            SendData("Welcome to Mushroom Pocket App");
            SendData(new String('*', 30));
            SendData("(1). Add Mushroom's character to my pocket");
            SendData("(2). List character(s) in my pocket");
            SendData("(3). Check if I can transform my characters");
            SendData("(4). Transform characters(s)");
            SendData("(5). Remove characters");
            SendData("(6). Begin adventure");
            SendData("(7). Revive dead characters to 100 HP");
            SendData("(8). Show profile, coins & inventory");
            SendData("(9). Shop");
            SendData("(0). Multiplayer Battle");

            string option = await GetResponse("Please only enter [1,2,3,4,5,6,7] or Q to quit: ");
            SendData("\n");

            switch (option.ToLower())
            {
                case "1":
                    await Add();
                    break;
                case "2":
                    List();
                    break;
                case "3":
                    CheckTransform();
                    break;
                case "4":
                    Transform();
                    break;
                //    case "5":
                //        Remove();
                //        break;
                //    case "6":
                //        Adventure();
                //        break;
                //    case "7":
                //        Revive();
                //        break;
                case "8":
                    ShowInventory();
                    break;
                //    case "9":
                //        Shop();
                //        break;
                //    case "0":
                //        await MPBattle();
                //        break;
                case "q":
                    return false;
                default:
                    SendData("Invalid Input");
                    break;
            }

            SendData("\n");

            return true;
        }

        /// <summary>
        /// Adds a new character
        /// </summary>
        public async Task Add()
        {
            string name;
            int hp = 100;
            int exp = 0;

            string resName = await GetResponse("Enter Character's Name: ");
            name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(resName);

            Character character;
            switch (name)
            {
                case "Waluigi":
                    character = new Waluigi(hp, exp);
                    break;
                case "Daisy":
                    character = new Daisy(hp, exp);
                    break;
                case "Wario":
                    character = new Wario(hp, exp);
                    break;
                default:
                    SendData("Invalid Character");
                    return;
            }

            character.Player = player;
            dbContext.Characters.Add(character);
            dbContext.SaveChanges();

            SendData($"{name} has been added.");
            SendData($"HP: {character.HP}");
            SendData($"EXP: {character.EXP}");
            SendData($"Skill: {character.Skill}");
        }

        /// <summary>
        /// List all characters be HP Descending
        /// </summary>
        public void List()
        {
            foreach (Character character in player.Characters.OrderByDescending(c => c.HP).ToList())
            {
                SendData(new String('-', 20));
                SendData($"Name: {character.Name}");
                SendData($"HP: {character.HP}");
                SendData($"EXP: {character.EXP}");
                SendData($"Skill: {character.Skill}");
                SendData(new String('-', 20));
            }
        }

        /// <summary>
        /// Checks if characters can transform
        /// </summary>
        public void CheckTransform()
        {
            Dictionary<string, int> Counter = new Dictionary<string, int>
            {
                { "Waluigi", 0 },
                { "Daisy", 0 },
                { "Wario", 0 }
            };

            foreach (Character character in player.Characters.ToList())
            {
                foreach (MushroomMaster mushroom in MushroomMastersList)
                {
                    if (character.Name == mushroom.Name)
                    {
                        Counter[character.Name]++;
                    }
                }
            }

            foreach (string name in Counter.Keys)
            {
                int count = Counter[name];
                foreach (MushroomMaster mushroom in MushroomMastersList)
                {
                    if (name == mushroom.Name && count >= mushroom.NoToTransform)
                    {
                        SendData($"{name} --> {mushroom.TransformTo}");
                    }
                }
            }
        }

        /// <summary>
        /// Transforms eligible characters
        /// </summary>
        public void Transform()
        {
            Dictionary<string, int> Counter = new Dictionary<string, int>
            {
                { "Waluigi", 0 },
                { "Daisy", 0 },
                { "Wario", 0 }
            };

            foreach (Character character in player.Characters.ToList())
            {
                foreach (MushroomMaster mushroom in MushroomMastersList)
                {
                    if (character.Name == mushroom.Name)
                    {
                        Counter[character.Name]++;
                    }
                }
            }

            foreach (string name in Counter.Keys)
            {
                int count = Counter[name];
                foreach (MushroomMaster mushroom in MushroomMastersList)
                {
                    if (name == mushroom.Name && count >= mushroom.NoToTransform)
                    {
                        SendData($"{name} has been transformed to {mushroom.TransformTo}");

                        Character newCharacter;
                        switch (mushroom.TransformTo)
                        {
                            case "Luigi":
                                newCharacter = new Luigi();
                                break;
                            case "Peach":
                                newCharacter = new Peach();
                                break;
                            case "Mario":
                                newCharacter = new Mario();
                                break;
                            default:
                                return;
                        }

                        newCharacter.Player = player;
                        dbContext.Characters.Add(newCharacter);
                        dbContext.Characters.RemoveRange(dbContext.Characters.Where(c => c.Name == name).Take(count));
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Shows user's current coins and inventory
        /// </summary>
        public void ShowInventory()
        {
            // Coins
            int Coins = player.Coins;
            SendData($"You have {Coins} coins.");

            // Inventory
            if (player.Items.Count() == 0)
            {
                SendData("You have no items!");
                return;
            }

            Dictionary<string, int> counter = new Dictionary<string, int>();
            foreach (Item item in player.Items.ToList())
            {
                if (counter.ContainsKey(item.Name))
                {
                    counter[item.Name]++;
                }
                else
                {
                    counter.Add(item.Name, 1);
                }
            }

            SendData("\nItems:");
            foreach (KeyValuePair<string, int> item in counter)
            {
                SendData($"{item.Value} {item.Key}");
            }
        }
    }
}
