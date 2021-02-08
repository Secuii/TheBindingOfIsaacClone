using UnityEngine;

[CreateAssetMenu(fileName = "Item stats", menuName = "RoguelikeTemplate/Item Asset")]
public class Items : ScriptableObject
{
    public float playerSpeed = 0f;
    public float projectileRange = 0f;
    public float projectileDelay = 0f;
    public float projectileSpeed = 0f;
    public float projectileDamage = 30f;
    public float Luck = 0f;
    public float Devil = 0f;
    public float Holly = 0f;
}
