using UnityEngine;

[CreateAssetMenu(fileName = "Projectile stats", menuName = "RoguelikeTemplate/Projectile Asset")]
public class ProjectileStats : ScriptableObject
{
    public float projectileRange = 1f;
    public float projectileSpeed = 1f;
    public float projectileDamage = 3.5f;

    public bool isSpectral = false;
}
