using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
