using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CoinsMoneda : MonoBehaviour
{
    public int coinValue = 10; //Valor de puntuación de la moneda
    public event Action<CoinsMoneda> onCollected; //Action Event para cuando el objeto (moneda) es recolectado
    [SerializeField]int velocidadRotacion;
    void Update()
    {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
    //Cuando el Player choca con la moneda, se invoca el Action Event y sus métodos suscritos
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            onCollected?.Invoke(this); //Los métodos suscritos requieren que se les pase un objeto de tipo S3Coin, en este caso, se pasa la misma moneda que será coleccionada
            gameObject.SetActive(false);
        }
    }
}
