using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    const float flipThreshold = 330f;

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] ParticleSystem powerupParticles;
    [SerializeField] ScoreManager scoreManager;

    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    SurfaceEffector2D surfaceEffector2D;

    Vector2 moveVector;
    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;
    int activePowerupCount;

    void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        if (!canControlPlayer) return;
        
        RotatePlayer();
        BoostPlayer();
        CalculateFlips();
    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        float rotationInput = moveVector.x;
        myRigidBody2D.AddTorque(-rotationInput * torqueAmount);
    }

    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if (Math.Abs(totalRotation) > flipThreshold)
        {
            totalRotation = 0;
            scoreManager.AddScore(10);
        }
        previousRotation = currentRotation;
    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }

    public void ActivatePowerup(PowerupScriptableObject powerup)
    {
        powerupParticles.Play();
        activePowerupCount += 1;

        switch (powerup.GetPowerupType())
        {
            case "speed":
                baseSpeed += powerup.GetValueChange();
                boostSpeed += powerup.GetValueChange();
                break;

            case "torque":
                torqueAmount += powerup.GetValueChange();
                break;
        }
    }

    public void DeactivatePowerup(PowerupScriptableObject powerup)
    {
        activePowerupCount -= 1;
        if (activePowerupCount == 0)
        {
            powerupParticles.Stop();
        }

        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostSpeed -= powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            torqueAmount -= powerup.GetValueChange();
        }
    }
}
