using UnityEngine;

public class MoveMenuController : MonoBehaviour
{

    private RectTransform nextMenu = null;

    void Update()
    {
        if (nextMenu != null)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition =
                Vector2.Lerp(gameObject.GetComponent<RectTransform>().anchoredPosition,
                                                new Vector2(nextMenu.anchoredPosition.x * -1f,
                                                            nextMenu.anchoredPosition.y * -1f),
                                                            0.5f);
        }
    }

    public void ChangeMenu(RectTransform nextMenu)
    {
        this.nextMenu = nextMenu;
    }
}
