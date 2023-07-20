using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float timeReloadDelay = 1.0f;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
        {
            Debug.Log("Ouch !! hit my head");
            Invoke("ReloadScene", timeReloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
