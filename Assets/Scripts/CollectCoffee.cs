using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectCoffee : MonoBehaviour
{
    [SerializeField] AudioSource coffeeFX;

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) {
        coffeeFX.Play();
        MasterInfo.coffeeCount += 1;
        this.gameObject.SetActive(false);
        }
    }
}
