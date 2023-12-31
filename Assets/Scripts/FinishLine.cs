using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{

    [SerializeField] float timeReloadDelay = 1.0f;
    [SerializeField] ParticleSystem finishEffect;
    bool hasFinished = false;
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasFinished && other.tag == "Player")
        {
            hasFinished = true;
            finishEffect.Play();
            Debug.Log("You're finished");
            GetComponent<AudioSource>().Play();
            FindObjectOfType<PlayerController>().canMove = false;
            Invoke("ReloadScene", timeReloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
