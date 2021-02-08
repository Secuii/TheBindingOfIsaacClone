using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas = null;
    [SerializeField] private GameObject gameCanvas = null;
    [SerializeField] private LevelGeneration levelGeneration = null;

    private PlayerController playerController = null;
    private Controller controller;

    private void Awake()
    {
        controller = new Controller();
    }

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        controller.Player.RestartGame.performed += _ => RestartGame();
    }
    public void OnStartGame()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        levelGeneration.StartGame();
    }
    public void RestartGame()
    {
        playerController.SetGameStart();
        levelGeneration.RestartGame();
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