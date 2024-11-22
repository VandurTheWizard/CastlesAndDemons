using UnityEngine;

public class ObjectMagnet: MonoBehaviour
{
    private GameObject parentObject;

    void Start()
    {
        parentObject = transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(parentObject.GetComponent<Health>() != null)
                parentObject.GetComponent<Health>().IsMagnetActive = true;
            else if(parentObject.GetComponent<Orb>() != null)
                parentObject.GetComponent<Orb>().IsMagnetActive = true;
        }
    }
}
