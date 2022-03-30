using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSourceComponent;

    [SerializeField] private AudioClip[] audioClips;

    [SerializeField]private int randomSongIndex;

    private void Awake()
    {
        audioSourceComponent = GetComponent<AudioSource>();

        randomSongIndex = Random.Range(0, audioClips.Length);
        audioSourceComponent.clip = audioClips[randomSongIndex];
    }
}
