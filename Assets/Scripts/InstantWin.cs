using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantWin : MonoBehaviour
{
    public int Value = 50;

    public AudioClip PickupAudioClip;
    public ParticleSystem WreathParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        AudioSource.PlayClipAtPoint(PickupAudioClip, transform.position);

        GameManager.Instance.UpdateScore(Value);

        if (WreathParticleSystem != null)
        {
            ParticleSystem wreathParticleSystem = Instantiate(WreathParticleSystem, transform.position, Quaternion.identity);
            WreathParticleSystem.transform.SetParent(null);
            WreathParticleSystem.Play();
        }

        Destroy(gameObject);

        GameManager.Instance.Player.SetActive(false);

        GameManager.Instance.NextLevelCanvas.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("InstantWin");
    }
}
