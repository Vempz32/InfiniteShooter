using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject PausedMenu;
    public GameObject GameOverMenu;
    public GameObject LootBoxScreen;
    public Button ReturnButton;
    public Button RestartButton;

    private bool isPaused = false;
    void Start()
    {
        LootBoxScreen.SetActive(false);
        ReturnButton.onClick.AddListener(OnReturnButtonClick);
        RestartButton.onClick.AddListener(OnResartButtonClick);
    }


    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggeling the visbilty of the PausedMenu
            isPaused = !isPaused;
            PausedMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScreen");
    }

    public void GameOverScreen()
    {

        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LootBoxScreenOn()
    {
        LootBoxScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LootBoxScreenOff()
    {
        LootBoxScreen.SetActive(false);
        Time.timeScale = 1f;
    }
        
}
