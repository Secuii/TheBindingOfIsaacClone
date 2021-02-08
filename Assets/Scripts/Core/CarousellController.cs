using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarousellController : MonoBehaviour
{
    [SerializeField] private TMP_Text CharacterName = null;
    [SerializeField] private TMP_Text CharacterAttk = null;
    [SerializeField] private TMP_Text CharacterLife = null;
    [SerializeField] private TMP_Text CharacterSpeed = null;

    [SerializeField] private PlayerStats[] playerStats= null;       //TODO Colocar en los objetos de cada personaje de la lista en vez e en este codigo Crear nuevo codigo para eso

    private PlayerController playerController = null;
    private RectTransform[] Characters = null;
    private Vector2[] CharacterPositions = null;
    private Image[] CharacterImage = null;
    private Canvas[] CharacterSortingLayer = null;
    private int[] layers = null;

    private float[] characterAlphaColor = null;
    private float[] characterYPosition = null;
    private float[] characterXPosition = null;

    private bool inCharacterSelector = false;
    private Controller controller = null;

    public bool ChangingCharacter { get; set; } = true;
    public int NextCarousellPos { get; private set; } = 0;
    public int NextCarousellName { get; private set; } = 0;

    private double alpha = 0;
    private double Ypos = 0;
    private double Xpos = 0;
    private int layer = 0;

    private readonly float xValuemin = -1000;
    private readonly float xValuemax = 300;
    private readonly float yValuemin = -200;
    private readonly float yValuemax = 0;
    private readonly float layerMin = 300;
    private readonly float layerMax = 700;

    public int vlaor;

    

    private void Start()
    {
        controller.UI.Move.performed += _ => ChangeCharacter();
        controller.UI.Move.canceled += _ => ChangingCharacter = true;

        SetCharacter(0);

        Characters = new RectTransform[transform.childCount];
        CharacterPositions = new Vector2[transform.childCount];
        CharacterImage = new Image[transform.childCount];
        characterAlphaColor = new float[transform.childCount];
        CharacterSortingLayer = new Canvas[transform.childCount];
        layers = new int[transform.childCount];

        int count = 0;
        foreach (RectTransform character in transform)
        {
            Characters[count] = character;
            //CharacterPositions[count] = character.anchoredPosition;
            CharacterImage[count] = Characters[count].GetComponent<Image>();
            CharacterSortingLayer[count] = Characters[count].GetComponent<Canvas>();
            count++;
        }


        for (int i = 0; i < transform.childCount; i++)
        {
            CharacterImage[i].sprite = playerStats[i].characterSprite;
        }
    }

    private void Update()
    {

        for (int i = 0; i < characterAlphaColor.Length; i++)
        {
            float lerp = Mathf.InverseLerp(transform.childCount, 0, i);

            if (i >= Mathf.Round(characterAlphaColor.Length / 2))
            {
                alpha = Math.Round((float)Mathf.Lerp(1f, .3f, lerp), 1);
                Ypos = Math.Round((float)Mathf.Lerp(yValuemin, yValuemax, lerp), 1);

                Xpos = Math.Round((float)Mathf.Lerp(xValuemax, xValuemin, lerp), 1);
                layer = Mathf.RoundToInt(Mathf.Lerp(layerMax, layerMin, lerp));

            }
            else
            {
                alpha = Math.Round((float)Mathf.Lerp(.3f, 1f, lerp), 1);
                Ypos = Math.Round((float)Mathf.Lerp(yValuemax, yValuemin, lerp), 1);

                Xpos = Math.Round((float)Mathf.Lerp(xValuemin, xValuemax, lerp), 1);
                layer = Mathf.RoundToInt(Mathf.Lerp(layerMin, layerMax, lerp));

            }


            characterAlphaColor[i] = (float)alpha;
            CharacterPositions[(i + characterAlphaColor.Length / 4) % transform.childCount].x = (float)Xpos;
            CharacterPositions[i].y = (float)Ypos;
            layers[i] = layer;
        }


        for (int i = 0; i < transform.childCount; i++)
        {
            Characters[i].anchoredPosition = Vector2.Lerp(Characters[i].anchoredPosition, CharacterPositions[(i + NextCarousellPos) % transform.childCount], 0.2f);

            CharacterSortingLayer[i].sortingOrder = layers[(i + NextCarousellPos) % transform.childCount];

            Color TempColor;
            TempColor = CharacterImage[i].color;
            TempColor.r = characterAlphaColor[(i + NextCarousellPos) % transform.childCount];
            TempColor.g = characterAlphaColor[(i + NextCarousellPos) % transform.childCount];
            TempColor.b = characterAlphaColor[(i + NextCarousellPos) % transform.childCount];
            CharacterImage[i].color = TempColor;

            Vector2 TempSize;
            TempSize.x = characterAlphaColor[(i + NextCarousellPos) % transform.childCount] * 100;
            TempSize.y = characterAlphaColor[(i + NextCarousellPos) % transform.childCount] * 100;
            Characters[i].sizeDelta = TempSize;
        }
    }

    public void ChangeCharacter()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(CharacterDelay));
    }

    public IEnumerator CharacterDelay()
    {
        if (ChangingCharacter && inCharacterSelector)
        {

            if (controller.UI.Move.ReadValue<Vector2>().x == 1f)
            {
                NextCarousellPos --;
                NextCarousellName++;
                ChangingCharacter = false;

            }
            else if (controller.UI.Move.ReadValue<Vector2>().x == -1f)
            {
                NextCarousellPos ++;
                NextCarousellName--;
                ChangingCharacter = false;
            }

            if (NextCarousellPos < 0)
            {
                NextCarousellPos = transform.childCount - 1;
            }
            if(NextCarousellName < 0)
            {
                NextCarousellName = transform.childCount - 1;
            }

            SetCharacter(NextCarousellName % transform.childCount);


            yield return new WaitForSeconds(.3f);
            ChangingCharacter = true;
        }
    }

    public void SetCharacter(int index)
    {
        CharacterName.text = playerStats[index].characterName;
        CharacterLife.text = playerStats[index].playerLife.ToString();
        CharacterSpeed.text = playerStats[index].playerSpeed.ToString();
        CharacterAttk.text = playerStats[index].BaseDamage.ToString();

        playerController.PlayerSprite.sprite = playerStats[index].characterSprite;

        playerController.Ps = Instantiate(playerStats[index]);
    }

    public void ChangeSelectorMode(bool active)
    {
        inCharacterSelector = active;
    }

    private void Awake()
    {
        controller = new Controller();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

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