using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip win;
    public AudioClip wallTouch;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlayDeathSound()
    {
        SFXSource.PlayOneShot(death);
    }

    public void PlayWinSound()
    {
        SFXSource.PlayOneShot(win);
    }

    public void PlayWallTouchSound()
    {
        SFXSource.PlayOneShot(wallTouch);
    }
}
