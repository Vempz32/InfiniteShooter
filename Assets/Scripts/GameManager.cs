using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PausedMenu;
    public GameObject GameOverMenu;
    public Button ReturnButton;
    public Button RestartButton;
    

  
    void Start()
    {
        ReturnButton.onClick.AddListener(OnReturnButtonClick);
        RestartButton.onClick.AddListener(OnResartButtonClick);
    }


    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggeling the visbilty of the PausedMenu
            PausedMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    void OnReturnButtonClick()
    {
        // hide the PausedMenu 
        PausedMenu.SetActive(false);
        //resume the game
        Time.timeScale = 1f;
    }

    void OnResartButtonClick()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1f;
    }

    public void GameOverScreen()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
        
}
