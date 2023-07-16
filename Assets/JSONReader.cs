using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;

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

    void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);

        // Sort the player list alphabetically by player name
        myPlayerList.player = myPlayerList.player.OrderBy(player => player.name).ToArray();

        Player desiredPlayer = null;
        foreach (Player player in myPlayerList.player)
        {
            if (player.name == "Warrior" || player.name == "Wizard")
            {
                desiredPlayer = player;
                break;
            }
        }
    }
}
