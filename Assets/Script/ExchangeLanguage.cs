using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeLanguage : MonoBehaviour {

    [SerializeField] private Language Polish;
    [SerializeField] private Language English;
    [SerializeField] private Language German;

    [SerializeField] private List<Text> _levelTexts = new List<Text>();

    private void Start()
    {
        var language = PlayerPrefs.GetString("LANG");
        Exchange(language);
    }

    private void Exchange(string text)
    {
        if (text == "PL")
        {
            for (int i = 0; i < _levelTexts.Count; i++)
            {
                _levelTexts[i].text = Polish.Text[i];
            }
        }

        if (text == "ENG")
        {
            for (int i = 0; i < _levelTexts.Count; i++)
            {
                _levelTexts[i].text = English.Text[i];
            }
        }


        if (text == "GER")
        {
            for (int i = 0; i < _levelTexts.Count; i++)
            {
                _levelTexts[i].text = German.Text[i];
            }
        }
    }
}

