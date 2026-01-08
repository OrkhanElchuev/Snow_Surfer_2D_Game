using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayAfterLosing = 1f;
    [SerializeField] ParticleSystem crashParticles;

    PlayerController playerController;
    int floorLayer;

    void Awake()
    {
        if (!playerController)
        {
            playerController = FindFirstObjectByType<PlayerController>();
        }
        
        floorLayer = LayerMask.NameToLayer("Floor");
    }

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == floorLayer)
        {
            playerController.DisableControls();
            crashParticles.Play();
            Invoke(nameof(ReloadScene), delayAfterLosing);
        }
    }

    void ReloadScene()
    {
        // 0 - Level 1 Scene
        SceneManager.LoadScene(0);
    }
}
