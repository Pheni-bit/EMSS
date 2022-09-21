using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectMetalNextButton : MonoBehaviour
{
    // Start is called before the first frame update
    int medtalTypeIndex;
    float weightOfCoilPounds;
    int jTypeCount;
    [SerializeField]
    public Dropdown metalTypeDropDown;
    [SerializeField]
    public TMPro.TMP_InputField weightInputField, jCountInputField;
    [SerializeField]
    public GameObject joistInputPanel;
    public Button clearButton;

    public void SelectMetalNextButtonClicked()
    {
        medtalTypeIndex = metalTypeDropDown.value;
        if (weightInputField.text == "")
        {
            ErrorMessage.InputErrorMessage("Enter the weight");
            return;
        }
        if (jCountInputField.text == "")
        {
            ErrorMessage.InputErrorMessage("Enter the joist count");
            return;
        }
        weightOfCoilPounds = float.Parse(weightInputField.text);
        jTypeCount = int.Parse(jCountInputField.text);
        if (CheckInputs(medtalTypeIndex, weightOfCoilPounds, jTypeCount) == true)
        {
            ErrorMessage.ClearErrorMessage();
            DataManager.WeightOfCoilPounds = weightOfCoilPounds;
            DataManager.MetalTypeIndex = medtalTypeIndex;
            DataManager.JTypeCount = jTypeCount;
            joistInputPanel.SetActive(true);
        }
    }
    bool CheckInputs(int typeIndex, float weight, int j)
    {
        if (typeIndex == 0)
        {
            ErrorMessage.InputErrorMessage("Select the metal type");
            return false;
        }
        if (weight <= 0)
        {
            ErrorMessage.InputErrorMessage("The weight entered is too small");
            return false;
        }
        if (j <= 0)
        {
            ErrorMessage.InputErrorMessage("Joist type count must be more than 0");
            return false;
        }
        else
            return true;
    }

    public void ClearButtonClicked()
    {
        clearButton.onClick.Invoke();
    }
}
