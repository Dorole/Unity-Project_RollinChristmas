using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public int Value = 5;

    //public AudioClip PickupAudioClip;
    public ParticleSystem PresentParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        //AudioSource.PlayClipAtPoint(PickupAudioClip, transform.position);

        if (gameObject.tag == "RegularPresent")
            FindObjectOfType<AudioManager>().Play("RegularPresent");
        else if (gameObject.tag == "ExtraPresent")
            FindObjectOfType<AudioManager>().Play("ExtraPresent");

        GameManager.Instance.UpdateScore(Value);

        if (PresentParticleSystem != null)
        {
            ParticleSystem presentParticleSystem = Instantiate(PresentParticleSystem, transform.position, Quaternion.identity);
            PresentParticleSystem.transform.SetParent(null);
            PresentParticleSystem.Play();
        }

        Destroy(gameObject);
    }



}
