using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TMP_InputField marginOfErrorInput, frontEndInput, backEndInput;
    private void OnEnable()
    {
        marginOfErrorInput.placeholder.GetComponent<TMPro.TMP_Text>().text = DataManager.MarginOfError.ToString();
        frontEndInput.placeholder.GetComponent<TMPro.TMP_Text>().text = DataManager.FrontEndWaste.ToString();
        backEndInput.placeholder.GetComponent<TMPro.TMP_Text>().text = DataManager.BackEndWaste.ToString();
    }
    public void SaveSettings()
    {
        if (marginOfErrorInput.text != "")
        {
            float f = float.Parse(marginOfErrorInput.text);
            PlayerPrefs.SetFloat("Settings/MarginOfError", f);
            DataManager.MarginOfError = f;
        }
        if (frontEndInput.text != "")
        {
            float f = float.Parse(frontEndInput.text);
            PlayerPrefs.SetFloat("Settings/FrontEndWaste", f);
            DataManager.FrontEndWaste = f;
        }
        if (backEndInput.text != "")
        {
            float f = float.Parse(backEndInput.text);
            PlayerPrefs.SetFloat("Settings/BackEndWaste", f);
            DataManager.BackEndWaste = f;
        }
        ErrorMessage.InputErrorMessage("Data has been Saved");
    }

    public void ClearSettingInputs()
    {
        frontEndInput.text = "";
        backEndInput.text = "";
        marginOfErrorInput.text = "";
    }
}
