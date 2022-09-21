using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour
{
    public static Text errorText;
    void Start()
    {
        errorText = gameObject.GetComponent<Text>();
    }

    public static void InputErrorMessage(string message)
    {
        errorText.text = message;
    }
    public static void ClearErrorMessage()
    {
        errorText.text = "";
    }
}
