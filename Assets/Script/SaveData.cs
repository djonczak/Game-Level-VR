using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    [SerializeField] private Animator _infoText;

    private Transform _player;
    private PlayerInfo _playerSave = new PlayerInfo();

    private string _saveFileName;
    private string _saveInfo;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _saveFileName = Application.dataPath + "/save.json";
        _saveInfo = PlayerPrefs.GetString("Saves", _saveInfo);
        CheckSave(_saveInfo);
    }


    public void SaveGame()
    {
        _playerSave.PlayerPosition = new Vector3(_player.position.x, _player.position.y, _player.position.z);
        _playerSave.HasTeleported = CementeryManager.instance.ReturnIfTeleported();
        _playerSave.HasTeleportationStone = CementeryManager.instance.ReturnTeleportStone();
        _playerSave.HasFirstCrystal = CementeryManager.instance.ReturnFirstCrystal();
        _playerSave.HasSecondCrystal = CementeryManager.instance.ReturnSecondCrystal();
        _playerSave.HasThirdCrystal = CementeryManager.instance.ReturnThirdCrystal();

        string json = JsonUtility.ToJson(_playerSave);
        File.WriteAllText(_saveFileName, json);
        _infoText.SetTrigger("Show");
    }

    public void LoadSave()
    {
        string json = File.ReadAllText(_saveFileName);
        JsonUtility.FromJsonOverwrite(json, _playerSave);
        _player.transform.position = new Vector3(_playerSave.PlayerPosition.x, _playerSave.PlayerPosition.y, _playerSave.PlayerPosition.z);
        CementeryManager.instance.SetIfTeleported(_playerSave.HasTeleported);
        CementeryManager.instance.SetItemTeleportStone(_playerSave.HasTeleportationStone);
        CementeryManager.instance.SetItemFirstCrystal(_playerSave.HasFirstCrystal);
        CementeryManager.instance.SetItemSecondCrystal(_playerSave.HasSecondCrystal);
        CementeryManager.instance.SetItemThirdCrystal(_playerSave.HasThirdCrystal);
    }

    void CheckSave(string check)
    { 
       if (check == "1")
       {
            LoadSave();
            _saveInfo = "0";
            PlayerPrefs.SetString("Saves", _saveInfo);
        }
    }
}

[System.Serializable]
public class PlayerInfo
{
    public Vector3 PlayerPosition;
    public bool HasTeleported;
    public bool HasTeleportationStone;
    public bool HasFirstCrystal;
    public bool HasSecondCrystal;
    public bool HasThirdCrystal;
}

