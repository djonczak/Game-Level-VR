using UnityEngine;

public class PickUpItem :  ItemInteraction
{
    [SerializeField] private int _itemNumber;
    [SerializeField] Animator _textAnimation;

    public override void ShowInteraction()
    {
        _textAnimation.SetTrigger("Show");
    }

    public override void HideInteraction()
    {
        _textAnimation.SetTrigger("Hide");
    }

    public override void Interact()
    {
        CementeryManager.instance.TakeItem(_itemNumber);
        gameObject.SetActive(false);
    }
}
