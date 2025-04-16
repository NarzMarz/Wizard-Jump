using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsTrigger : MonoBehaviour
{
    private bool hasTriggered = false;
    public AudioSource coinSound;
    public PointsManager pointsManager;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Coin") && !hasTriggered){
            coinSound.Play();
            pointsManager.AddPoints();
            Debug.Log("triggerEnter");
            Destroy(other.gameObject);
            hasTriggered = true;
            StartCoroutine(ResetTrigger());
        }
    }
    IEnumerator ResetTrigger(){
        yield return new WaitForSeconds(0.2f);
        hasTriggered = false;
    }
}
