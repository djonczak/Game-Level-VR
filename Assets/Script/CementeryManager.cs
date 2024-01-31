using System.Collections;
using UnityEngine;

public class CementeryManager : MonoBehaviour
{
    public static CementeryManager instance;

    private bool _hasTeleportationStone;
    private bool _hasTeleported;
    private bool _hasFirstCrystal;
    private bool _hasSecondCrystal;
    private bool _hasThirdCrystal;

    [SerializeField] private GameObject TeleportCrystal;
    [SerializeField] private GameObject BloodCrystal1;
    [SerializeField] private GameObject BloodCrystal2;
    [SerializeField] private GameObject BloodCrystal3;

    [SerializeField] private Animator _bloodCrystalInfo;
    [SerializeField] private Animator _teleportationCrystalInfo;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        Cursor.visible = false;
        CheckItem();
    }

    public void TakeItem(int index)
    {
        if (index == 1)
        {
            _hasTeleportationStone = true;
            _teleportationCrystalInfo.SetTrigger("Show");
        }
        if (index == 2)
        {
            _hasFirstCrystal = true;
            _bloodCrystalInfo.SetTrigger("Show");
        }
        if (index == 3)
        {
            _hasSecondCrystal = true;
            _bloodCrystalInfo.SetTrigger("Show");
        }
        if (index == 4)
        {
            _hasThirdCrystal = true;
            _bloodCrystalInfo.SetTrigger("Show");
        }
    }

    private void CheckItem()
    {
        if (_hasFirstCrystal)
        {
            BloodCrystal1.SetActive(false);
        }
        if (_hasSecondCrystal)
        {
            BloodCrystal2.SetActive(false);
        }
        if (_hasThirdCrystal)
        {
            BloodCrystal3.SetActive(false);
        }
        if (_hasTeleported || _hasTeleportationStone)
        {
            TeleportCrystal.SetActive(false);
        }
    }

    public void SetItemFirstCrystal(bool active)
    {
        _hasFirstCrystal = active;
    }

    public void SetItemSecondCrystal(bool active)
    {
        _hasSecondCrystal = active;
    }

    public void SetItemThirdCrystal(bool active)
    {
        _hasThirdCrystal = active;
    }

    public void SetItemTeleportStone(bool active)
    {
        _hasTeleportationStone = active;
    }

    public void SetIfTeleported(bool active)
    {
        _hasTeleported = active;
    }

    public bool ReturnFirstCrystal()
    {
        return _hasFirstCrystal;
    }

    public bool ReturnSecondCrystal()
    {
        return _hasSecondCrystal;
    }

    public bool ReturnThirdCrystal()
    {
        return _hasThirdCrystal;
    }

    public bool ReturnTeleportStone()
    {
        return _hasTeleportationStone;
    }

    public bool ReturnIfTeleported()
    {
        return _hasTeleported;
    }
}
