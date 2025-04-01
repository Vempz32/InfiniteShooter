using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonText : MonoBehaviour
{
    public TMP_Text[] textComponents;
    private string[] powerUps = new string[] { "HealthBoost", "SpeedBoost", "FireRateBoost", "DamageBoost", "Piercing"};
   
    void Start()
    {
        //Shuffeling the array
        ArrayShuffle(powerUps);

        for(int i = 0; i < textComponents.Length; i++)
        {
            textComponents[i].text = powerUps[i];
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

}
