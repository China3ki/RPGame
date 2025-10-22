using Newtonsoft.Json;
using RPGGame.Components.Gui;
using RPGGame.Gameplay.Characters;
namespace RPGGame.Components
{
    static internal class SaveManager
    {
        static private string _path = "../../../Saves";
        static public void SaveGame(Player player)
        {
            string savePath = $"{_path}/{player.SavePath}.json";
            if (!File.Exists(savePath)) File.Create(savePath).Dispose();
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };
            var save = JsonConvert.SerializeObject(player, settings);
            File.WriteAllText(savePath, save);
            View.RenderInfo("Gra została zapisana!", ConsoleColor.Green);
            Thread.Sleep(500);
        }
        static public Player LoadGame(int index)
        {
            string[] files = Directory.GetFiles(_path);
            string json = File.ReadAllText(files[index]);
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };
            var deserialize = JsonConvert.DeserializeObject<Player>(json, settings);
            if (deserialize != null) return deserialize;
            else throw new InvalidOperationException("File does not found!");
        }
        static public List<Player> GetSavedGames()
        {
            string[] files = Directory.GetFiles(_path);
            List<Player> ?playerList = [];
            foreach(string file in files)
            {
                string json = File.ReadAllText(file);
                var player = JsonConvert.DeserializeObject<Player>(json);
                if(player != null) playerList.Add(player);
            }
            return playerList;
        }
    }
}
