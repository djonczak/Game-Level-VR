using UnityEngine;

public class LightController : MonoBehaviour 
{

    [SerializeField] private float _lightIntensity = 0.1f;
    private Light _light;

	private void Awake () 
    {
        _light = GetComponent<Light>();
        _light.intensity = _lightIntensity;
	}

    private void Start()
    {
        _light.intensity = _lightIntensity;
    }
}
