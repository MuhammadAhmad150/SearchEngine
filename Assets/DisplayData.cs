using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayData : MonoBehaviour
{
    public Text nameText;
    public Text healthText;
    public Text manaText;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName") &&
            PlayerPrefs.HasKey("PlayerHealth") &&
            PlayerPrefs.HasKey("PlayerMana"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            int playerHealth = PlayerPrefs.GetInt("PlayerHealth");
            int playerMana = PlayerPrefs.GetInt("PlayerMana");

            nameText.text = "Name: " + playerName;
            healthText.text = "Health: " + playerHealth;
            manaText.text = "Mana: " + playerMana;
        }
    }
}
