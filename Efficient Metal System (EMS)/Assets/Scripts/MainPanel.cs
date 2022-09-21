using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Settings/MarginOfError"))
        {
            DataManager.MarginOfError = PlayerPrefs.GetFloat("Settings/MarginOfError");
        }
        if (PlayerPrefs.HasKey("Settings/FrontEndWaste"))
        {
            DataManager.FrontEndWaste = PlayerPrefs.GetFloat("Settings/FrontEndWaste");
        }
        if (PlayerPrefs.HasKey("Settings/BackEndWaste"))
        {
            DataManager.BackEndWaste = PlayerPrefs.GetFloat("Settings/BackEndWaste");
        }
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
