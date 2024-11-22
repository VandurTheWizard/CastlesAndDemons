using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ControlTrigers : MonoBehaviour
{
    private bool canPlace = true;
    private List<GameObject> notBuildZone = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tower") || other.CompareTag("NoBuildZone"))
        {
            notBuildZone.Add(other.gameObject);

            canPlace = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tower") || other.CompareTag("NoBuildZone"))
        {
            notBuildZone.Remove(other.gameObject);
            
            if(notBuildZone.Count == 0)
            {
                canPlace = true;
            }
        }
    }

    public bool CanPlace()
    {
        return canPlace;
    }
}
