using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Room : MonoBehaviour
{
    public float xMin,xMax,yMin,yMax;
    public Player player;
    public List<GameObject> enemys;
    public List<GameObject> gates;
    bool triggered = false;
    
    private void Awake() 
    {
        player = FindObjectOfType<Player>();
        enemys.ForEach(s => s.SetActive(false));
        gates.ForEach(s => s.SetActive(false));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.transform.CompareTag("Player") && !triggered)
        {
            triggered = true;
            Debug.Log("Player in");
            enemys.ForEach(s => s.SetActive(true));
            gates.ForEach(s => s.SetActive(true));
        }
    }
    private void Update() {
        if(triggered)
        {
            if(enemys.Count == 0)
            {
                gates.ForEach(s => s.SetActive(false));
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
