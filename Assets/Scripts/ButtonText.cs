using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonText : MonoBehaviour
{
    public TMP_Text[] textComponents;
    public Button[] buttons;

    private string[] powerUps = new string[] { "HealthBoost", "SpeedBoost", "FireRateBoost", "DamageBoost", "HealthRegen"};

    [SerializeField] private Stats stats;
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private GameManager gameManager;


    void Start()
    {
        //Shuffeling the array
        ArrayShuffle(powerUps);

        for(int i = 0; i < textComponents.Length; i++)
        {
            textComponents[i].text = powerUps[i];
            int index = i;
            buttons[i].onClick.AddListener(() => ApplyPowerUp(powerUps[index]));
        }
       
    }
    // shuffeling the array PowerUps to never have duplicates 
    void ArrayShuffle(string[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            (array[i] , array[randomIndex]) = (array[randomIndex], array[i]);
        }
    }

    void ApplyPowerUp(string powerUp)
    {
        switch(powerUp)
        {
            case "HealthBoost":
                stats.maxHealth += 10.0f;
                break;

            case "SpeedBoost":
                stats.movementSpeed = Mathf.Round(stats.movementSpeed * 1.1f * 100f) / 100f;
                break;

            case "FireRateBoost":
                stats.fireRate /= 1.1f;
                stats.fireRate = Mathf.Round(stats.fireRate * 100f) / 100f;
                break;

            case "DamageBoost":
                Debug.Log("Damage");
                break;
            case "HealthRegen":
                stats.healthRegen += 1.0f;
                playerControl.StartHealthRegen();
                break;
        }
        gameManager.LootBoxScreenOff();
    }

}
