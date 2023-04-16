using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private UnityEvent onHit;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            onHit?.Invoke();
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class S3PlatformerController : MonoBehaviour
{
    [SerializeField] private UnityEvent onHit;
    //Cuando el Player colisione con este objeto, se llamará el evento onHit y sus
    métodos suscritos y se eliminará el GameObject.
private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            onHit?.Invoke();
            Destroy(this.gameObject);
        }
    }
}*/
