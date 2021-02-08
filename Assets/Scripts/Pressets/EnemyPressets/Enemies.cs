using UnityEngine;

[CreateAssetMenu(fileName = "Enemy stats", menuName = "RoguelikeTemplate/Enemy Asset")]
public class Enemies : ScriptableObject
{
    public float enemySpeed;
    public float enemyDamage;
    public float enemyLife;

    public bool canFly;
    public bool specialEnemy;
}
