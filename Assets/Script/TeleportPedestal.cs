using UnityEngine;

public class TeleportPedestal : ItemInteraction
{
    [SerializeField] private GameObject _teleportEffect;
    [SerializeField] private GameObject _teleportCollider;
    [SerializeField] private Animator _text1;
    [SerializeField] private Animator _text2;

    private bool _portalActivated;

    private void Start()
    {
        if (CementeryManager.instance.ReturnIfTeleported())
        {
            _teleportEffect.SetActive(true);
        }
        else
        {
            _teleportEffect.SetActive(false);
        }
    }

    public override void ShowInteraction()
    {
        if (_portalActivated == false)
        {
            if (CementeryManager.instance.ReturnTeleportStone())
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
        if (_portalActivated == false)
        {
            _teleportEffect.SetActive(true);
            _text1.SetTrigger("Hide");
            _text2.SetTrigger("Hide");
            _teleportCollider.SetActive(true);
            _portalActivated = true;
        }
    }

    public override void HideInteraction()
    {
        if (CementeryManager.instance.ReturnTeleportStone())
        {
            _text2.SetTrigger("Hide");
        }
        else
        {
            _text1.SetTrigger("Hide");
        }
    }
}
