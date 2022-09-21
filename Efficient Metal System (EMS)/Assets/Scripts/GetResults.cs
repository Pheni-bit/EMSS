using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class GetResults : MonoBehaviour
{
    [SerializeField]
    public Text wasteInputText;
    public Text totalLengthInputText;
    public Text coilLengthInputText;
    public GameObject resultContent, contentTextInputPrefab, loadingScreen;
    int maxStringLengthCount;
    private void OnEnable()
    {
        loadingScreen.SetActive(false);
        maxStringLengthCount = 0;
        wasteInputText.text = DataManager.ResultWasteLength.ToString();
        totalLengthInputText.text = DataManager.ResultTotalLength.ToString();
        coilLengthInputText.text = DataManager.CoilLengthInches.ToString();

        int jCount = DataManager.JTypeCount;
        Transform parent = resultContent.transform;
        for (int i = 0; i < jCount; i++)
        {
            GameObject labelPrefab = Instantiate(contentTextInputPrefab, parent, false);
            labelPrefab.name = "Label_Text" + i.ToString();
            TMPro.TMP_Text text = labelPrefab.GetComponent<TMPro.TMP_Text>();
            text.fontStyle = TMPro.FontStyles.Underline;
            string str = DataManager.JoistLabels[i];
            text.text = str;
            FindLargestStringLength(str);
        }
        for (int i = 0; i < jCount; i++)
        {
            GameObject lengthPrefab = Instantiate(contentTextInputPrefab, parent, false);
            lengthPrefab.name = "Length_Text" + i.ToString();
            TMPro.TMP_Text text = lengthPrefab.GetComponent<TMPro.TMP_Text>();
            string str = DataManager.JoistLengths[i].ToString("#.00");
            text.text = str;
            FindLargestStringLength(str);
        }
        for (int i = 0; i < jCount; i++)
        {
            GameObject minPrefab = Instantiate(contentTextInputPrefab, parent, false);
            minPrefab.name = "Min_Text" + i.ToString();
            TMPro.TMP_Text text = minPrefab.GetComponent<TMPro.TMP_Text>();
            string str = DataManager.JoistMinimums[i].ToString();
            text.text = str;
            FindLargestStringLength(str);
        }
        for (int i = 0; i < jCount; i++)
        {
            GameObject maxPrefab = Instantiate(contentTextInputPrefab, parent, false);
            maxPrefab.name = "Max_Text" + i.ToString();
            TMPro.TMP_Text text = maxPrefab.GetComponent<TMPro.TMP_Text>();
            string str = DataManager.JoistMaximums[i].ToString();
            text.text = str;
            FindLargestStringLength(str);
        }
        for (int i = 0; i < jCount; i++)
        {
            GameObject labelPrefab = Instantiate(contentTextInputPrefab, parent, false);
            labelPrefab.name = "Result_Text" + i.ToString();
            TMPro.TMP_Text text = labelPrefab.GetComponent<TMPro.TMP_Text>();
            text.fontStyle = TMPro.FontStyles.Underline;
            string str = DataManager.BestCombination[i].ToString();
            text.text = str;
            FindLargestStringLength(str);
        }
    }
    void FindLargestStringLength(string str)
    {
        int i = str.Length;
        if (i > maxStringLengthCount)
            maxStringLengthCount = i;
    }
    public void ClearUpResultInputs()
    {
        for (int i = 0; i < resultContent.transform.childCount; i++)
        {
            Destroy(resultContent.transform.GetChild(i).transform.gameObject);
        }
    }
}
