using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayAfterLosing = 1f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // layer 7, "Floor"
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            Invoke("ReloadScene", delayAfterLosing);
        }
    }

    void ReloadScene()
    {
        // 0 - Level 1 Scene
        SceneManager.LoadScene(0);
    }
}
