using UnityEngine;

public class BarrierPedestal : ItemInteraction
{
    [SerializeField] private Animator _text1;
    [SerializeField] private Animator _text2;
    [SerializeField] private Animator _barrierDown;
  
    private bool _isOpen;

    public override void ShowInteraction()
    {
        if (_isOpen == false)
        {
            if (CementeryManager.instance.ReturnFirstCrystal() && CementeryManager.instance.ReturnSecondCrystal() && CementeryManager.instance.ReturnThirdCrystal())
            {
                _text2.SetTrigger("Show");
            }
            else
            {
                _text1.SetTrigger("Show");
            }
        }
    }

    public override void Interact()
    {
        if (_isOpen == false)
        {
            _isOpen = true;
            _barrierDown.SetTrigger("Show");
            _text1.SetTrigger("Hide");
            _text2.SetTrigger("Hide");
        }
    }

    public override void HideInteraction()
    {
        if (CementeryManager.instance.ReturnFirstCrystal() && CementeryManager.instance.ReturnSecondCrystal() && CementeryManager.instance.ReturnThirdCrystal())
        {
            _text2.SetTrigger("Hide");
        }
        else
        {
            _text1.SetTrigger("Hide");
        }
    }
}
