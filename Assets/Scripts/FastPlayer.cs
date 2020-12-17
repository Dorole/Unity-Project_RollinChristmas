using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPlayer : MonoBehaviour
{
    public float Boost;
    //public AudioClip PickupAudioClip;
    public ParticleSystem SledParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        //AudioSource.PlayClipAtPoint(PickupAudioClip, transform.position);
        FindObjectOfType<AudioManager>().Play("Boost");

        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.Speed *= Boost;

        if (SledParticleSystem != null)
        {
            ParticleSystem sledParticleSystem = Instantiate(SledParticleSystem, transform.position, Quaternion.identity);
            SledParticleSystem.transform.SetParent(null);
            SledParticleSystem.Play();
        }

        Destroy(gameObject);
    }

}
