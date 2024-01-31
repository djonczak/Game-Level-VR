using UnityEngine;

public class ReyInteract : MonoBehaviour
{
    [SerializeField] private string _interactionTag = "Interact";
    [SerializeField] private float _rayDistance = 20f;
    [SerializeField] private Transform _selected;
    private bool _assigned;
    private bool _interacted;

    private void Update()
    {
        if(_selected != null && _assigned && _interacted)
        {
            _selected.GetComponent<ItemInteraction>().HideInteraction();
            _interacted = false;
            _selected = null;
        }

        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance))
        {
            var selected = hit.transform;
            if (selected.CompareTag(_interactionTag))
            {
                if (_interacted == false)
                {
                    _interacted = true;
                    _assigned = false;
                    selected.GetComponent<ItemInteraction>().ShowInteraction();
                    _selected = selected;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    selected.GetComponent<ItemInteraction>().Interact();
                    _interacted = false;
                    _selected = null;
                }
            }
            else
            {
                _assigned = true;
            }
        }
    }
}
