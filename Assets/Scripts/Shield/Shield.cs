using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Player player;
    [Header("Shield Energy")]
    public float maxShieldEnergy;
    public float currentShieldEnergy;
    public float shieldEnergyIncrementor;
    public float shieldEnergyDecrementor;
    public float reflectingEnergyLimit;

    public bool canReflect;

    private UIManager uIManager;

    private void Start() 
    {
        uIManager = FindObjectOfType<UIManager>();
        currentShieldEnergy = maxShieldEnergy;
    }
    private void Update()
    {
        transform.position = player.transform.position;
        Reflection();
    }
    void Reflection()
    {
        if(Input.GetKey(KeyCode.C) && currentShieldEnergy > reflectingEnergyLimit )
        {
            canReflect = true;
            currentShieldEnergy -= shieldEnergyDecrementor * Time.deltaTime;
        }
        else
        {
            canReflect = false;
            if(currentShieldEnergy < maxShieldEnergy)
                currentShieldEnergy += shieldEnergyIncrementor * Time.deltaTime;
        }
        
        if(currentShieldEnergy < 0 ) 
            currentShieldEnergy = 0;
        else if(currentShieldEnergy > maxShieldEnergy )
            currentShieldEnergy = maxShieldEnergy;
        
        uIManager.UpdateShieldImage(currentShieldEnergy/100);
    }
}
