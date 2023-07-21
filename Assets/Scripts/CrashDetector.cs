using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float timeReloadDelay = 1.0f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
        {
            crashEffect.Play();
            Debug.Log("Ouch !! hit my head");
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            FindObjectOfType<PlayerController>().canMove = false;
            Invoke("ReloadScene", timeReloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
