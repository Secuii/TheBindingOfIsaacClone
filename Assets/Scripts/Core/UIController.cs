using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text playerSpeedText = null;
    [SerializeField] private TMP_Text projectileRangeText= null;
    [SerializeField] private TMP_Text ProjectileDelayText = null;
    [SerializeField] private TMP_Text ProjectileSpeedText = null;
    [SerializeField] private TMP_Text ProjectileDamageText = null;
    [SerializeField] private TMP_Text LuckText = null;
    [SerializeField] private TMP_Text DevilText = null;
    [SerializeField] private TMP_Text HollyText = null;

    private PlayerController player = null;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        UpdateGameUI();
            
    }

    public void UpdateGameUI()
    {
        //Player
        playerSpeedText.text = player.Ps.playerSpeed.ToString("0.00");
        ProjectileDelayText.text = (player.Ps.playerShootingDelay).ToString();
        LuckText.text = player.Ps.Luck.ToString();
        DevilText.text = player.Ps.Devil.ToString("0.00");
        HollyText.text = player.Ps.Holly.ToString("0.00");

        //Projectil
        projectileRangeText.text = player.ProjectileController.projectileStats.projectileRange.ToString("0.00");
        ProjectileSpeedText.text = player.ProjectileController.projectileStats.projectileSpeed.ToString("0.00");
        ProjectileDamageText.text = player.ProjectileController.projectileStats.projectileDamage.ToString("0.00");
    }
}
