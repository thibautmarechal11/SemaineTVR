using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDebug : MonoBehaviour
{
    public static TextDebug Instance;

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
