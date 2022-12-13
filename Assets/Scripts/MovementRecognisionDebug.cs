using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovementRecognisionDebug : MonoBehaviour
{
    public static MovementRecognisionDebug Instance;

    TMP_Text text;

    private void Awake()
    {
        Instance = this;
        text = GetComponent<TMP_Text>();
    }

    public void Text(string newText)
    {
        text.text = newText;
    }
}
