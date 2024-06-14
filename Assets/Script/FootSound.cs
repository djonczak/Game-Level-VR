using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.InputSystem;

public class FootSound : MonoBehaviour
{
    public InputActionProperty leftHandMoveAction;
    public InputActionProperty rightHandMoveAction;
    [SerializeField] private float _stepInterval;
    [SerializeField] [Range(0f, 1f)] private float runstepLenghten;
    private float _nextStep = 0f;
    [SerializeField] private AudioClip[] _footstepSounds;
    private CharacterController _characterController;
    private AudioSource _audioSource;
    private float _stepCycle = 0f;

    private bool _isWalking = true;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        ProgressStepCycle(3f);
    }

    private void ProgressStepCycle(float speed)
    {
        var leftHandValue = leftHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
        var rightHandValue = rightHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

        if (_characterController.velocity.sqrMagnitude > 0 && (leftHandValue.magnitude != 0 || rightHandValue.magnitude != 0))
            _stepCycle += (_characterController.velocity.magnitude + (speed * 1f) * Time.fixedDeltaTime);

        if (!(_stepCycle > _nextStep)) return;

        _nextStep = _stepCycle + _stepInterval;

        PlayFootStepAudio();
    }

    private void PlayFootStepAudio()
    {
        if (!_characterController.isGrounded) return;
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, _footstepSounds.Length);
        _audioSource.clip = _footstepSounds[n];
        _audioSource.PlayOneShot(_audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        _footstepSounds[n] = _footstepSounds[0];
        _footstepSounds[0] = _audioSource.clip;
    }

}
