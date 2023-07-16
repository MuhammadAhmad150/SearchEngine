using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SearchScript : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject[] Element;
    public GameObject SearchBar;
    public int totalElements;

    
    void Update()
    {
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
        Debug.Log("Muhammad");
    
        GameObject firstElement = Element[0];
        foreach (GameObject ele in Element)
        {
            Text textComponent = ele.GetComponentInChildren<Text>();
            //Debug.Log(textComponent);
         
            if (string.IsNullOrEmpty(searchText))
            {
                if(Element[0]==ele)
                //if(ele.GetComponentInChildren<Text>().text== "NOT_FOUND")
                    ele.SetActive(false);
                else 
                    ele.SetActive(true);
            }
            //else if (textComponent != null)
            else 
            {
                bool b = textComponent.text.ToLower().Contains(searchText);
                if(b==true)
                {
                    Element[0].GetComponentInChildren<Text>().text = ele.GetComponentInChildren<Text>().text;
                    Element[0].name = ele.name;
                    characterCount += textComponent.text.Length;
                    //Changed these 2
                    ele.SetActive(true);
                    Element[0].SetActive(false);
                }
                else
                {
                    ele.SetActive(false);
                }
            }
        }
    } 
    void ButtonClicked(string buttonNo, int health, int mana)
    {
        string Health = health.ToString();
        string Mana = mana.ToString();
        string onestring = " Name:" + buttonNo + " Health:" + Health + " Mana:" + Mana;
        //84
        PlayerPrefs.SetString("PlayerName", buttonNo);
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetInt("PlayerMana", mana);
        SceneManager.LoadScene("DestinationScene");
    }
}








