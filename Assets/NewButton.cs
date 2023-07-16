using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewButton : MonoBehaviour
{
    public void PreviousScreen()
    {
        SceneManager.LoadScene("AddNewObject");
    }
}
