using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image shieldEnergyImage;
    public Image[] hearts;
    public void UpdateShieldImage( float amount )
    {
        shieldEnergyImage.fillAmount = amount;
    }
    public void UpdateHealthImage(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < currentHealth; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }
}
