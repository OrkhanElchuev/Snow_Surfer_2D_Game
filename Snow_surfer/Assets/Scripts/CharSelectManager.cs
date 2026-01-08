using UnityEngine;

public class CharSelectManager : MonoBehaviour
{   
    [SerializeField] GameObject scoreCanvas;

    void Start()
    {
        Time.timeScale = 0;
    }

    private void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseCharacter(GameObject characterSprite)
    {
        characterSprite.SetActive(true);
        BeginGame();
    }
}
