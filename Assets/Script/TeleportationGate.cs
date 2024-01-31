using UnityEngine;

public class TeleportationGate : MonoBehaviour
{
    [SerializeField] private Transform _teleportPosition;
    [SerializeField] private Animator _whiteScreen;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        Teleport(other.gameObject);
    }

    private void Teleport(GameObject player)
    {
        _whiteScreen.SetTrigger("Blink");
        CementeryManager.instance.SetIfTeleported(true);
        player.transform.position = _teleportPosition.position;
    }
}
