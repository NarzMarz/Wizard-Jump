using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    
    private bool hasTriggered = false;
    public GameObject[] roadSections;
    private int currentIndex = 0;
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Trigger")&& !hasTriggered){
            Instantiate(roadSections[currentIndex],new Vector3(0, -1.02f, 104f),Quaternion.identity);
            // currentIndex = (currentIndex + 1) % roadSections.Length;
            currentIndex = Random.Range(0,roadSections.Length);
            hasTriggered = true;
            StartCoroutine(ResetTrigger());


        }
    }
    IEnumerator ResetTrigger(){
       yield return new WaitForSeconds(1f);
       hasTriggered = false; 
    }

}
