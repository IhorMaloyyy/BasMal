using UnityEngine;

public class HitSound : MonoBehaviour
{
    private AudioSource powerUpSound;
    [SerializeField] private AudioClip hitSound;

    private readonly float volumeScale = 0.1f;

    private void Start()
    {
        powerUpSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            powerUpSound.PlayOneShot(hitSound, volumeScale);
        }
    }

    public void BusketSound()
    {
        powerUpSound.PlayOneShot(hitSound);
    }
}
