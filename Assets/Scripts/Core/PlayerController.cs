using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectile = null;

    [SerializeField] private Transform UpSpawn = null;
    [SerializeField] private Transform DownSpaw = null;
    [SerializeField] private Transform LeftSpawn = null;
    [SerializeField] private Transform RightSpawn = null;
    [SerializeField] private UIController uiController = null;


    private Controller controller = null;

    //Shoot Move
    private float vMove = 0f;
    private float hMove = 0f;

    private float hShoot = 0f;
    private float vShoot = 0f;

    private float ShootDelayCount = 1f;

    public ProjectileController ProjectileController { get; set; } = null;
    public SpriteRenderer PlayerSprite  = null;
    public PlayerStats Ps { get; set; } = null;

    

    private void Start()
    {
        PlayerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();

        ProjectileController = projectile.GetComponent<ProjectileController>();
        ShootDelayCount = Ps.playerShootingDelay;
    }

    void LateUpdate()
    {
        vMove = controller.Player.Movement.ReadValue<Vector2>().y;
        hMove = controller.Player.Movement.ReadValue<Vector2>().x;

        vShoot = controller.Player.Shoot.ReadValue<Vector2>().y;
        hShoot = controller.Player.Shoot.ReadValue<Vector2>().x;
        
        transform.Translate((new Vector3(hMove, vMove, 0f) * 4.5f )* Ps.playerSpeed * Time.deltaTime);

        ShootDelayCount += Time.deltaTime;

        if (ShootDelayCount >= Ps.playerShootingDelay / 30)
        {
            switch (vShoot)
            {
                case 1:
                    Shoot(UpSpawn);
                    break;
                case -1:
                    Shoot(DownSpaw);
                    break;
                default:
                    break;
            }

            switch (hShoot)
            {
                case 1:
                    Shoot(RightSpawn);
                    break;
                case -1:
                    Shoot(LeftSpawn);
                    break;
                default:
                    break;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            other.GetComponent<IInteractable>().Action();
        }
        if (other.GetComponent<IItems>() != null)
        {
            other.GetComponent<IItems>().Action(this, ProjectileController);
            uiController.UpdateGameUI();
        }
    }

    public void Shoot(Transform spawn)
    {
        GameObject shoot = Instantiate(projectile, spawn.position, Quaternion.identity);
        shoot.GetComponent<ProjectileController>().ProjectileDirection = new Vector2(hShoot, vShoot);
        ShootDelayCount = 0f;
    }


    public void SetGameStart()
    {
        transform.position = new Vector2();
        ShootDelayCount = Ps.playerShootingDelay;
        uiController.UpdateGameUI();
    }


    private void Awake()
    {
        controller = new Controller();
    }

    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }
}