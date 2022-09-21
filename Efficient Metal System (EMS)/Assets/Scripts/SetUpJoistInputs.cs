using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpJoistInputs : MonoBehaviour
{
    [SerializeField]
    public GameObject viewPortPanel,
        inputContent,
        confirmPanel,
        inputFieldPrefab;
    TMPro.TMP_InputField[] labelInputFieldArr, lengthInputFieldArr, minInputFieldArr, maxInputFieldArr;
    string[] labels;
    float[] lengths;
    int[] mins, maxs;
    int jCount;
    private void OnEnable()
    {
        SetUpInputs();
    }

    public void SetUpInputs()
    {
        Transform parent = inputContent.transform;
        jCount = DataManager.JTypeCount;
        labelInputFieldArr = new TMPro.TMP_InputField[jCount];
        lengthInputFieldArr = new TMPro.TMP_InputField[jCount];
        minInputFieldArr = new TMPro.TMP_InputField[jCount];
        maxInputFieldArr = new TMPro.TMP_InputField[jCount];
        for (int i = 0; i < jCount; i++)
        {
            GameObject labelFieldPrefab = Instantiate(inputFieldPrefab, parent, false);
            labelFieldPrefab.name = "Label_InputField" + i.ToString();
            labelInputFieldArr[i] = labelFieldPrefab.GetComponent<TMPro.TMP_InputField>();
        }
        for (int i = 0; i < jCount; i++)
        {
            GameObject lengthFieldPrefab = Instantiate(inputFieldPrefab, parent, false);
            lengthFieldPrefab.name = "Length_InputField" + i.ToString();
            TMPro.TMP_InputField lengthTMP = lengthFieldPrefab.GetComponent<TMPro.TMP_InputField>();
            lengthTMP.placeholder.gameObject.GetComponent<TMPro.TMP_Text>().text = "Enter Length....";
            lengthTMP.contentType = TMPro.TMP_InputField.ContentType.DecimalNumber;
            lengthTMP.characterLimit = 6;
            lengthInputFieldArr[i] = lengthTMP;
        }
        for (int i = 0; i < jCount; i++)
        {
            GameObject minFieldPrefab = Instantiate(inputFieldPrefab, parent, false);
            minFieldPrefab.name = "Min_InputField" + i.ToString();
            TMPro.TMP_InputField minTMP = minFieldPrefab.GetComponent<TMPro.TMP_InputField>();
            minTMP.placeholder.gameObject.GetComponent<TMPro.TMP_Text>().text = "Enter Minimum Amount....";
            minTMP.contentType = TMPro.TMP_InputField.ContentType.IntegerNumber;
            minTMP.characterLimit = 3;
            minInputFieldArr[i] = minTMP;
        }
        for (int i = 0; i < jCount; i++)
        {

            GameObject maxFieldPrefab = Instantiate(inputFieldPrefab, parent, false);
            maxFieldPrefab.name = "Max_InputField" + i.ToString();
            TMPro.TMP_InputField maxTMP = maxFieldPrefab.GetComponent<TMPro.TMP_InputField>();
            maxTMP.placeholder.gameObject.GetComponent<TMPro.TMP_Text>().text = "Enter Maximum Amount....";
            maxTMP.contentType = TMPro.TMP_InputField.ContentType.IntegerNumber;
            maxTMP.characterLimit = 3;
            maxInputFieldArr[i] = maxTMP;
        }
    }

    public void ClearJoistsInputs()
    {
        for (int i = 0; i < DataManager.JTypeCount; i++)
        {
            labelInputFieldArr[i].text = "";
            lengthInputFieldArr[i].text = "";
            minInputFieldArr[i].text = "";
            maxInputFieldArr[i].text = "";
        }
    }

    public void SetUpJoistNextButton()
    {
        if (CheckInputs() == true)
        {
            ErrorMessage.ClearErrorMessage();
            labels = new string[jCount];
            lengths = new float[jCount];
            mins = new int[jCount];
            maxs = new int[jCount];
            for (int i = 0; i < jCount; i++)
            {
                labels[i] = labelInputFieldArr[i].text;
                lengths[i] = float.Parse(lengthInputFieldArr[i].text);
                mins[i] = int.Parse(minInputFieldArr[i].text);
                maxs[i] = int.Parse(maxInputFieldArr[i].text);
            }
            DataManager.JoistLabels = labels;
            DataManager.JoistLengths = lengths;
            DataManager.JoistMinimums = mins;
            DataManager.JoistMaximums = maxs;
            confirmPanel.gameObject.SetActive(true);
        }
    }
    bool CheckInputs()
    {
        for (int i = 0; i < jCount; i++)
        {
            if (labelInputFieldArr[i].text == "")
            {
                ErrorMessage.InputErrorMessage("Fill in label input field #" + (i + 1).ToString());
                return false;
            }
            if (lengthInputFieldArr[i].text == "")
            {
                ErrorMessage.InputErrorMessage("Fill in length input field #" + (i + 1).ToString());
                return false;
            }
            else if (float.Parse(lengthInputFieldArr[i].text) <= 0)
            {
                ErrorMessage.InputErrorMessage("Length input field #" + (i + 1).ToString() + " must be more than 0");
                return false;
            }
            if (minInputFieldArr[i].text == "")
            {
                ErrorMessage.InputErrorMessage("Fill in min input field #" + (i + 1).ToString());
                return false;
            }
            else if (float.Parse(minInputFieldArr[i].text) < 0)
            {
                ErrorMessage.InputErrorMessage("Min input field #" + (i + 1).ToString() + " must be at least 0");
                return false;
            }
            if (maxInputFieldArr[i].text == "")
            {
                ErrorMessage.InputErrorMessage("Fill in max input field #" + (i + 1).ToString());
                return false;
            }
            else if (float.Parse(maxInputFieldArr[i].text) <= 0)
            {
                ErrorMessage.InputErrorMessage("Max input field #" + (i + 1).ToString() + " must be more than 0");
                return false;
            }
            if (float.Parse(minInputFieldArr[i].text) > float.Parse(maxInputFieldArr[i].text))
            {
                ErrorMessage.InputErrorMessage("The min of input field #" + (i + 1).ToString() +
                    " cannot be larger than the max of input field #" + (i + 1).ToString());
                return false;
            }
        }
        return true;
    }


    public void ClearUpJoistInputs()
    {
        for (int i = 0; i < inputContent.transform.childCount; i++)
        {
            Destroy(inputContent.transform.GetChild(i).transform.gameObject);
        }
    }
}
