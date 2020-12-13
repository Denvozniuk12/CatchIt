using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject restart, mainMenu;
    public static bool lose = false;

    void Awake()
    {
        lose = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bomb") {
            lose = true;
            restart.SetActive(true);
            mainMenu.SetActive(true);
        }
    }
}
