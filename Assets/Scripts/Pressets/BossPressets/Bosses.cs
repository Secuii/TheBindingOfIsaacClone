using UnityEngine;

[CreateAssetMenu(fileName = "Boss stats", menuName = "RoguelikeTemplate/Boss Asset")]
public class Bosses : ScriptableObject
{
    public float bossSpeed;
    public float bossDamage;
    public float bossLife;

    public bool canFly;
    public bool specialBoss;
}
