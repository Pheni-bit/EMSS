using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmInfo : MonoBehaviour
{
    [SerializeField]
    public TMPro.TMP_Text jCountText, metalTypeText, coilWeightText, 
        feetPerPoundText, coilLengthInches, coilLengthFeet, frontEndWaste, backEndWaste, marginOfError;
    [SerializeField]
    public GameObject confirmContent, lines , contentTextInputPrefab, verticalLinesPrefabs, loadingScreen;
    int jCount, maxStringLengthCount;
    GridLayoutGroup layoutGroup;
    // Start is called before the first frame update
    public void InfoHasBeenConfirmed()
    {
        loadingScreen.SetActive(true);
        DataManager.PlugNPlay();
    }

    private void OnEnable()
    {
        maxStringLengthCount = 0;
        layoutGroup = confirmContent.GetComponent<GridLayoutGroup>();
        jCount = DataManager.JTypeCount;
        jCountText.text = jCount.ToString();
        metalTypeText.text = DataManager.MetalTypeLabels[DataManager.MetalTypeIndex];
        coilWeightText.text = DataManager.WeightOfCoilPounds.ToString();
        feetPerPoundText.text = DataManager.FeetPerPound.ToString();
        coilLengthFeet.text = DataManager.CoilLengthFeet.ToString("#.00");
        coilLengthInches.text = DataManager.CoilLengthInches.ToString("#.00");
        backEndWaste.text = DataManager.BackEndWaste.ToString();
        frontEndWaste.text = DataManager.FrontEndWaste.ToString();
        marginOfError.text = DataManager.MarginOfError.ToString();
        Transform parent = confirmContent.transform;
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
        layoutGroup.cellSize = new Vector2(13.4f * maxStringLengthCount, layoutGroup.cellSize.y);
        SetupVerticalLines();
    }

    void SetupVerticalLines()
    {
        /*
        float lastPos = 0;
        GameObject parent = lines.transform.Find("Vertical Lines").gameObject;
        for (int i = 1; i < jCount; i++)
        {
            GameObject vertcalLine = Instantiate(verticalLinesPrefabs);
            vertcalLine.transform.parent = parent.transform;
            float thisPos = AddPadding(i) + layoutGroup.cellSize.x + (layoutGroup.spacing.x / 2);
            RectTransform rect = vertcalLine.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(thisPos + lastPos,
                rect.localPosition.y, rect.localPosition.z);
            lastPos += thisPos;
        }*/
    }

    float AddPadding(int x)
    {
        if (x == 1)
            return layoutGroup.padding.left;
        return 0;
    }
    void FindLargestStringLength(string str)
    {
        int i = str.Length;
        if (i > maxStringLengthCount)
            maxStringLengthCount = i;
    }
    public void ClearUpConfirmInputs()
    {
        for (int i = 0; i < confirmContent.transform.childCount; i++)
        {
            Destroy(confirmContent.transform.GetChild(i).transform.gameObject);
        }
    }
}
