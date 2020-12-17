using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDamage : MonoBehaviour
{
    public int Value = -5;

    //public AudioClip CollisionAudio;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        //AudioSource.PlayClipAtPoint(CollisionAudio, transform.position);
        FindObjectOfType<AudioManager>().Play("DamageScore");

        GameManager.Instance.UpdateScore(Value);

    }
}
