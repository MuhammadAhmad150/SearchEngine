using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
//using UnityEditor;

public class ButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Scrollbar scrollbar;
    public TextAsset textJSON;   
    public GameObject ContentHolder;
    public GameObject[] Element;
    public GameObject SearchBar;
    public int totalElements; 
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
        Debug.Log("Returned");

        string filePath2 = Path.Combine(Application.persistentDataPath, "dara.json");
        if (!File.Exists(filePath2))
        {
            //Debug.Log("Not Exists");
            string jsonContent = textJSON.text;
            File.WriteAllText(filePath2, jsonContent);
        }
        else Debug.Log("FileExixsts");
        //File.WriteAllText(Path.Combine(Application.persistentDataPath, "playerData1.json"), "");
        string filePath = Path.Combine(Application.persistentDataPath, "dara.json");
        string json = File.ReadAllText(filePath);

    //    string filePath1 = Path.Combine(Application.persistentDataPath, "example.json");
    //   string json = File.ReadAllText(filePath);
    //    Debug.Log(filePath1);
      //    Debug.Log("fileCreated");
      //  File.WriteAllText(filePath1, "Hello, world!");

    // Load a prefab from the Resources folder
        //GameObject prefab = Resources.Load<GameObject>("Assets/Resources/playerData.json");
        // #if UNITY_EDITOR
          //AssetDatabase.Refresh();
        // #endif
        //     string assetPath="/Resources/playerData.json";
        //      loadedAsset = Resources.Load<TextAsset>(assetPath);
        //  //TextAsset textJSON=Resources.Load<TextAsset>(assetPath);   
       // string json = File.ReadAllText("Assets/Resources/playerData.json");
        //File.WriteAllText("Assets/Resources/playerData.json", json);       
        //Error
        //ArgumentException: Getting control 1's position in a group with only 1 controls when doing repaint
        // string sourceJsonFilePath = "Assets/Resources/playerData.json";
        // string destinationJsonFilePath = "Assets/Resources/playerData.json";
        // string json = File.ReadAllText(sourceJsonFilePath);
        // File.WriteAllText(destinationJsonFilePath, json);
        //int xaxis = 100;
        int yaxis = 0;
        int zaxis = 0;
        GameObject buttonsearch = Instantiate(buttonPrefab, transform);
        buttonsearch.GetComponentInChildren<Text>().text = "NOT_FOUND";

            { buttonsearch.SetActive(false); }
        buttonsearch.name = "searchedButton";
        buttonsearch.transform.position = new Vector3(buttonsearch.transform.position.x, buttonsearch.transform.position.y + yaxis, buttonsearch.transform.position.z + zaxis);
        yaxis -= 30;
        //FIRST:Y Generate buttons dynamically (example)
        //myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
       
      myPlayerList = JsonUtility.FromJson<PlayerList>(json);
       //myPlayerList = JsonUtility.FromJson<PlayerList>(filePath);
       
// { 
        // Player newPlayer = new Player();
        // newPlayer.name = "Test11";
        // newPlayer.health = 100;
        // newPlayer.mana = 100;        
        // List<Player> playerList = myPlayerList.player.ToList();
        // playerList.Add(newPlayer);
        // myPlayerList.player = playerList.ToArray();

//         string json = JsonUtility.ToJson(myPlayerList);
//         File.WriteAllText("playerData.json", json);
// }
        // foreach (Player player in myPlayerList.player)
        // {
        //     Debug.Log(player.name + " " +player.health +" "+ player.mana+"\n");
        // }
        myPlayerList.player = myPlayerList.player.OrderBy(player => player.name).ToArray();
        
        foreach (Player player in myPlayerList.player)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponentInChildren<Text>().text = player.name;
            button.name = player.name;

            button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y+yaxis, button.transform.position.z+zaxis);
            yaxis -= 80;
            
            Button tempButton = button.GetComponent<Button>();
            //int tempInt = i;

            //tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
            tempButton.onClick.AddListener(() => ButtonClicked(player.name, player.health, player.mana));
        }
        Destroy(buttonPrefab);
    }

    private void Update()
    {
        // Adjust scrollbar visibility based on the number of buttons
        scrollbar.gameObject.SetActive(transform.childCount > 0);
           totalElements = ContentHolder.transform.childCount;
        Element = new GameObject[totalElements];
        for (int i = 0; i < totalElements; i++)
        {
            Element[i] = ContentHolder.transform.GetChild(i).gameObject;
        }
                
    }
    public void Search()
    {
        string searchText = SearchBar.GetComponent<InputField>().text.ToLower();
        int characterCount = 0;
        GameObject firstElement = Element[0];
        foreach (GameObject ele in Element)
        {
            Text textComponent = ele.GetComponentInChildren<Text>();
            //Element[0].SetActive(true);
            if (string.IsNullOrEmpty(searchText))
            {
                if(Element[0]==ele)
                //if(ele.GetComponentInChildren<Text>().text== "NOT_FOUND")
                    ele.SetActive(false);
                else 
                    ele.SetActive(true);

            }
            else if (textComponent != null)
            {
                bool b = textComponent.text.ToLower().Contains(searchText);
                if(b==false)break;
                //if (textComponent.text.ToLower().Equals(searchText))
                {
                    //Element[0].GetComponentInChildren<Text>().text = textComponent;
                    Element[0].GetComponentInChildren<Text>().text = ele.GetComponentInChildren<Text>().text;
                    Element[0].name = ele.name;
                    //Element[0].SetActive(true);
                    foreach (Player player in myPlayerList.player)
                    {
                        if(player.name==Element[0].name)
                        {
                           // Button tempButton = ele.GetComponent<Button>();
                            //tempButton.onClick.AddListener(() => ButtonClicked(player.name, player.health, player.mana));
                            ButtonClicked(player.name, player.health, player.mana);
                        }
                        
        //84
                    }
                    characterCount += textComponent.text.Length;
                }
                // else
                // {
                //     ele.SetActive(false);
                // }
            }
        }
    }
    public void ButtonClicked(string buttonNo, int health, int mana)
    {
        {string Health = health.ToString();
        string Mana = mana.ToString();
        string onestring = " Name:" + buttonNo + " Health:" + Health + " Mana:" + Mana;
        //Debug.Log(onestring);
        //86
        PlayerPrefs.SetString("PlayerName", buttonNo);
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetInt("PlayerMana", mana);
        SceneManager.LoadScene("DestinationScene");}
    }
}

