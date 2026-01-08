using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float winDelayAmount = 1f;
    [SerializeField] ParticleSystem finishParticles;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        // Layer Index 6 "Player"
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {   
            finishParticles.Play();
            // Delay
            Invoke("ReloadScene", winDelayAmount);
        }
    }

    void ReloadScene()
    {
        // 0 - Level 1 Scene
        SceneManager.LoadScene(0);
    }
}
