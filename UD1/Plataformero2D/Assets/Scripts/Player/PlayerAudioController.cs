using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip secondJumpClip;
    public AudioClip landClip;
    public AudioClip[] runClips;
    public AudioClip latchClip;
    public AudioClip attackClip;
    public AudioClip attackMissClip;
    public AudioClip hurtClip;
    public AudioClip deathClip;
    public AudioClip coinPickupClip;
    public AudioClip healthPickupClip;

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    public void PlaySecondJumpSound()
    {
        audioSource.PlayOneShot(secondJumpClip);
    }

    public void PlayLandSound()
    {
        audioSource.PlayOneShot(landClip);
    }

    public void PlayRunSound()
    {
        if (runClips.Length == 0)
            return;

        int index = Random.Range(0, runClips.Length);
        audioSource.PlayOneShot(runClips[index]);
    }

    public void PlayLatchSound()
    {
        audioSource.PlayOneShot(latchClip);
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackClip);
    }

    public void PlayAttackMissSound()
    {
        audioSource.PlayOneShot(attackMissClip);
    }

    public void PlayHurtSound()
    {
        audioSource.PlayOneShot(hurtClip);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }

    public void PlayCoinPickupSound()
    {
        audioSource.PlayOneShot(coinPickupClip);
    }

    public void PlayHealthPickupSound()
    {
        audioSource.PlayOneShot(healthPickupClip);
    }
}
