using System.Collections;
using UnityEngine;

public class SpawnBombs : MonoBehaviour
{
    public GameObject bomb;
    private Timer t;

    void Start()
    {
        t = FindObjectOfType<Timer>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn ()
    {
        while (!Player.lose)
        {
            Instantiate(bomb, new Vector2(Random.Range(-2.35f, 2.35f), 5.45f), Quaternion.identity);
            if(t.second >= 2000 && t.minute < 100)
                yield return new WaitForSeconds(1f);
            else if(t.minute >= 100)
                yield return new WaitForSeconds(0.4f);
            else
                yield return new WaitForSeconds(2f);
        }
    }
}
