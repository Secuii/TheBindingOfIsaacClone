using UnityEngine;

public class ItemsController : MonoBehaviour, IItems
{
    public Items items = null;

    public void Action(PlayerController player, ProjectileController projectileObj)
    {
        ProjectileController projectile = projectileObj.GetComponent<ProjectileController>();

        //Player
        player.Ps.playerSpeed += items.playerSpeed;
        player.Ps.playerShootingDelay += items.projectileDelay;
        player.Ps.playerSpeed += items.projectileSpeed;
        player.Ps.Luck += items.Luck;
        player.Ps.Devil += items.Devil;
        player.Ps.Holly += items.Holly;

        //PROJECTILE
        //TODO crear la estructura de la bala para setearla al conseguir items
        projectile.projectileStats.projectileSpeed += items.projectileSpeed;
        projectile.projectileStats.projectileRange += items.projectileRange;
        projectile.projectileStats.projectileDamage += items.projectileDamage;

        Destroy(gameObject);
    }
}