using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] runClips;
    public AudioClip attackClip;
    public AudioClip attackMissClip;
    public AudioClip deathClip;

    public void PlayRunSound()
    {
        if (runClips.Length == 0)
            return;

        int index = Random.Range(0, runClips.Length);
        audioSource.PlayOneShot(runClips[index]);
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackClip);
    }

    public void PlayAttackMissSound()
    {
        audioSource.PlayOneShot(attackMissClip);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }
}
