using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField] private float healthAmount;
    
    public void OnCollected(GameObject player)
    {
        player.GetComponent<HealthController>().AddHealth(healthAmount);
    }
}
