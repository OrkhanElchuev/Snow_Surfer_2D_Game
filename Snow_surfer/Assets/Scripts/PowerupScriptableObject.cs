using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Powerup Script Obj")]
public class PowerupScriptableObject : ScriptableObject
{
    [Header("Powerup Settings")]
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float duration;

    public string GetPowerupType() => powerupType;
    public float GetValueChange() => valueChange;
    public float GetDuration() => duration;
}
