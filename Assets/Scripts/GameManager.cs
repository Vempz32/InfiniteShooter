using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PausedMenu;
    public Button ReturnButton;

  
    void Start()
    {
        ReturnButton.onClick.AddListener(OnReturnButtonClick);
    }


    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggeling the visbilty of the PausedMenu
            PausedMenu.SetActive(!PausedMenu.activeSelf);
            Time.timeScale = 0f;
        }
    }
    
    void OnReturnButtonClick()
    {
        {
            // hide the PausedMenu 
            PausedMenu.SetActive(false);
            //resume the game
            Time.timeScale = 1f;
        }
    }
        
}
