using UnityEngine;
using UnityEngine.Audio;

public class FootstepSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepSounds;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private FirstPersonController fpController;
    [SerializeField] private float minStepInterval = 0.5f;
    [SerializeField] private float maxStepInterval = 0.1f;

    private float lastStepTime;
    private float currentStepInterval;

    private void Update()
    {
        float speed = fpController.rb.linearVelocity.magnitude;
        currentStepInterval = Mathf.Lerp(maxStepInterval, minStepInterval, speed / fpController.walkSpeed);

        if (Time.time - lastStepTime > currentStepInterval)
        {
            PlayRandomFootstepSound();
        }
    }

    private void PlayRandomFootstepSound()
    {
        int randomIndex = Random.Range(0, footstepSounds.Length);
        audioSource.PlayOneShot(footstepSounds[randomIndex]);
        lastStepTime = Time.time;
    }
}