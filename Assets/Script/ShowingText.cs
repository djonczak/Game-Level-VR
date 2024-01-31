using UnityEngine;

public class ShowingText : MonoBehaviour {

    [SerializeField] private Animator _text;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _text.SetTrigger("Show");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _text.SetTrigger("Hide");
        }
    }
}
