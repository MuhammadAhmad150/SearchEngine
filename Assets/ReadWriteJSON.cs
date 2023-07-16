//ReadWriteJSON Working

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class ReadWriteJSON : MonoBehaviour
{
    public TextAsset textJSON;   

    public InputField NameInputField;
    public InputField HealthInputField;
    public InputField ManaInputField;

    [System.Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int mana;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();            

    public void Start()
    {
        //myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);

       
       string filePath = Path.Combine(Application.persistentDataPath, "dara.json");
       //Debug.Log(filePath);
        string json = File.ReadAllText(filePath);
        myPlayerList = JsonUtility.FromJson<PlayerList>(json);
    }
    public void Save()
    {
        //myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
      
        { 
            Player newPlayer = new Player();
            newPlayer.name = NameInputField.text;
            newPlayer.health = int.Parse(HealthInputField.text);
            newPlayer.mana = int.Parse(ManaInputField.text);  

            List<Player> playerList = myPlayerList.player.ToList();
            playerList.Add(newPlayer);
            myPlayerList.player = playerList.ToArray();

            string json = JsonUtility.ToJson(myPlayerList);

            //File.WriteAllText("playerData.json", json);
            //FOR COMPUTER
            //File.WriteAllText(Application.dataPath + "/playerData.json", json);
            
            //File.WriteAllText(Application.dataPath + "/Resources/playerData.json", json);
            
            string filePath = Path.Combine(Application.persistentDataPath, "dara.json");
            File.WriteAllText(filePath, json);
        }
    }
}


