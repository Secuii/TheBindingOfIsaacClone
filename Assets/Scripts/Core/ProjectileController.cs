using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Vector2 ProjectileDirection { get; set; } = new Vector2();
    private float ProjectileSpeed;
    private float count = 0f;

    public ProjectileStats projectileStats;

    private void Start()
    {
        projectileStats = Instantiate(projectileStats);
        ProjectileSpeed = projectileStats.projectileSpeed;
    }

    private void FixedUpdate()
    {
        transform.Translate((new Vector3(ProjectileDirection.x, ProjectileDirection.y, 0)* 10) * ProjectileSpeed * Time.deltaTime);
        DestroyProjectileCount();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (!projectileStats.isSpectral)
            {
                Destroy(gameObject);
            }
        }
    }

    private void DestroyProjectileCount()
    {
        count += Time.deltaTime;
        if (count >= projectileStats.projectileRange / 26f)
        {
            Destroy(gameObject);
        }
    }
}