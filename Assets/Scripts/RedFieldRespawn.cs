using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class RedFieldRespawn : MonoBehaviour
{
    [SerializeField]
    private Material originalColor;

    [SerializeField]
    private Material shieldedColor;
    [SerializeField] private GameObject particle;

    [SerializeField] GameObject playerObj;
    private void Update(){
        if(Switchers.shielded == true){
            gameObject.GetComponent<MeshRenderer>().material = shieldedColor;
        }
        else{
            gameObject.GetComponent<MeshRenderer>().material = originalColor;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if(other.CompareTag("RedZone") && Switchers.shielded == false){
            Vector3 deathPos = other.transform.position;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            particle.transform.position = deathPos;
            particle.SetActive(true);
            StartCoroutine(Dead());
        }
    }

    private IEnumerator Dead(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Instantiate(playerObj);
    }
}
