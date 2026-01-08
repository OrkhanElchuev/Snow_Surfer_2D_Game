using UnityEngine;

public class CharSelectManager : MonoBehaviour
{   
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject penguinSprite;
    [SerializeField] GameObject sharkSprite;


    void Start()
    {
        Time.timeScale = 0;
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChoosePenguin()
    {
        penguinSprite.SetActive(true);
        BeginGame();
    }

    public void ChooseShark()
    {
        sharkSprite.SetActive(true);
        BeginGame();
    }
}
