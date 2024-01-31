using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Menu : MonoBehaviour
{
    [SerializeField] private Language _polish;
    [SerializeField] private Language _english;
    [SerializeField] private Language _german;

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _loadButton;

    [SerializeField] private List<Text> _menuText;

    [SerializeField] Texture2D _cursorTexture;

    private string _language;
    private string _saveStatus;

    private void Awake()
    {
        var language = PlayerPrefs.GetString("LANG");
        ExchangeLanguage(language);

        if (System.IO.File.Exists(Application.dataPath + "/save.json"))
        {
            _loadButton.SetActive(true);
        }
        else
        {
            _loadButton.SetActive(false);
        }

        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Start()
    {
        _settings.SetActive(false);
        Cursor.visible = true;
    }

    public void NewGame()
    {
        _saveStatus = "0";
        PlayerPrefs.SetString("Saves", _saveStatus);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        _saveStatus = "1";
        PlayerPrefs.SetString("Saves", _saveStatus);
        SceneManager.LoadScene("Test");
    }

    public void Settings()
    {
        _settings.SetActive(true);
        _menu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        _settings.SetActive(false);
        _menu.SetActive(true);
    }

    public void SetPolish()
    {
        _language = "PL";
        PlayerPrefs.SetString("LANG", _language);
        ExchangeLanguage("PL");
    }

    public void SetEnglish()
    {
        _language = "ENG";
        PlayerPrefs.SetString("LANG", _language);
        ExchangeLanguage("ENG");
    }


    public void SetGerman()
    {
        _language = "GER";
        PlayerPrefs.SetString("LANG", _language);
        ExchangeLanguage("GER");
    }

    private void ExchangeLanguage(string texts)
    {
        if(texts == "PL"){
            for (int i = 0; i < _menuText.Count; i++)
            {
                _menuText[i].text = _polish.Text[i];
            }
        }

        if (texts == "ENG")
        {
            for (int i = 0; i < _menuText.Count; i++)
            {
                _menuText[i].text = _english.Text[i];
            }
        }

        if (texts == "GER")
        {
            for (int i = 0; i < _menuText.Count; i++)
            {
                _menuText[i].text = _german.Text[i];
            }
        }
    }
}
    

