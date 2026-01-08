using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupScriptableObject powerup;
    
    PlayerController player;
    SpriteRenderer spriteRenderer;
    float timeLeft;
    int playerLayer;

    void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerup.GetDuration();
    }

    void Update()
    {
        CountDownTimer();
    }

    void CountDownTimer()
    {
        if (spriteRenderer.enabled == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            
                if (timeLeft <= 0)
                {
                    player.DeactivatePowerup(powerup);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer && spriteRenderer.enabled)
        {   
            spriteRenderer.enabled = false;
            player.ActivatePowerup(powerup);
        }
    }
}
