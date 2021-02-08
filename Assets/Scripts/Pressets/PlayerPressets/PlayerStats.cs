using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Player stats", menuName = "RoguelikeTemplate/Player Asset")]
public class PlayerStats : ScriptableObject
{
    //FOR THE CHARACTER SLECTOR
    public string characterName = "";
    public Sprite characterSprite = null;
    public float BaseDamage = 0;

    //FOR IN GAME 
    public float playerSpeed = 1f;
    public float playerLife = 1f;
    public float playerShootingDelay = 1f;
    public float Luck = 0f;
    public float Devil = 0f;
    public float Holly = 0f;

    public int money = 0;
    public int bombs = 0;
    public int key = 0;
}