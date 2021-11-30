using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        float volume = Random.Range(0.7f, 1.2f);
        aud.PlayOneShot(sound, volume);
    }
}