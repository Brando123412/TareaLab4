using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControllerManager : MonoBehaviour
{
    private int coinsCollected = 0;
    [SerializeField] private List<CoinsMoneda> coinsOnMap;
    [SerializeField] private CoinsMoneda grandCoin;
    private List<CoinsMoneda> coinsRemaining;
    private int score = 0;
    [SerializeField] private UnityEvent OnLost;

    [SerializeField] private UnityEvent onWinGame;

    [SerializeField] private List<PowerUp> powerUpOnMap;
    private List<PowerUp> powerUpRemaining;
    [SerializeField] private List<GameObject> camera;

    //enemigos
    [SerializeField] private List<Enemy1> enemigoOnMap;
    private List<Enemy1> enemigoRemaining;
    [SerializeField]int life=100;
    void Start(){
        powerUpRemaining = new List<PowerUp>(powerUpOnMap);
        foreach (PowerUp powerUp in powerUpRemaining)
        {
            if (powerUp)
            {
                powerUp.onPower += CinemachineCamara;
            }
        }
        //Moneda
        coinsRemaining = new List<CoinsMoneda>(coinsOnMap); 
        foreach (CoinsMoneda coin in coinsRemaining)
        {
            coin.onCollected += HandleCollected;
        }
        coinsRemaining.Add(grandCoin);
        grandCoin.onCollected += HandleCollected;
        //enemi
        enemigoRemaining = new List<Enemy1>(enemigoOnMap); 
        foreach (Enemy1 enemy in enemigoRemaining)
        {
            enemy.Ongolpe += GolpeEnemy;
        }
    }
    private void OnGUI() {
        GUI.Label(new Rect(250, 10, 500, 20), string.Format("Coins Collected: {0}", coinsCollected));
        GUI.Label(new Rect(250, 40, 500, 20), string.Format("Total Score: {0}", score));
        GUI.Label(new Rect(250, 70, 500, 20), string.Format("Vida: {0}", life));
    }
    private void CinemachineCamara(PowerUp powerUp)
    {
        powerUpOnMap.RemoveAt(0);
        powerUpRemaining.Remove(powerUp);
        if (powerUpRemaining.Count %2==0)
        {
            camera[0].SetActive(true);
            camera[1].SetActive(false);
        }else{
            camera[0].SetActive(false);
            camera[1].SetActive(true);
        }
    }
    private void HandleCollected(CoinsMoneda coin){
        coinsRemaining.Remove(coin);

        coinsCollected++;

        score += coin.coinValue;

        if(coinsRemaining.Count == 0){
            onWinGame?.Invoke(); //Invocar el evento cuando se termina el minijuego
        }
    }
    private void GolpeEnemy(Enemy1 golpe){
        life-=golpe.golpeValue;
        if(life<=0)
        {
            OnLost?.Invoke();
        }

    }
}
