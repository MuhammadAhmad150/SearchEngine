using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPreviousScene : MonoBehaviour
{
    public void PreviousScreen()
    {
        SceneManager.LoadScene("SampleScene");
    }
}