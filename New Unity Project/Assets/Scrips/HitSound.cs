using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    private AudioSource powerUpSound;
    [SerializeField] private AudioClip hitSound;
    void Start()
    {
        powerUpSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            powerUpSound.PlayOneShot(hitSound);
        }
    }
}
