using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LaserEffectController : MonoBehaviour
{
    public Image laserEffectImage;
    public float laserDuration = 0.5f;
    public AudioClip wordRemovedSound;

    private bool isLaserActive = false;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (laserEffectImage == null) return;

        if (isLaserActive)
        {
            laserEffectImage.gameObject.SetActive(true);
        }
        else
        {
            laserEffectImage.gameObject.SetActive(false);
        }
    }

    public void ActivateLaser()
    {
        if (!isLaserActive)
        {
            isLaserActive = true;
            // Play the sound effect
            audioSource.PlayOneShot(wordRemovedSound, 0.5f);
            StartCoroutine(DeactivateLaser());
        }
    }

    IEnumerator DeactivateLaser()
    {
        yield return new WaitForSeconds(laserDuration);
        isLaserActive = false;
    }
}
