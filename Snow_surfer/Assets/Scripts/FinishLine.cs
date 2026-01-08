using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float winDelayAmount = 1f;

    void OnTriggerEnter2D(Collider2D collision) 
    {
        // Layer Index 6 "Player"
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {   
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
