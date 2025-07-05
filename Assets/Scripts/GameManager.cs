using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winText;
    public static bool isGameOver = false;  

    void Update()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");

        if (stars.Length == 0 && !isGameOver)
        {
            winText.SetActive(true);
            isGameOver = true;  
        }
    }
}
