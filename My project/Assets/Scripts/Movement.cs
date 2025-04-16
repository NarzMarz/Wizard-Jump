using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (0, 0, -20) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Destroy")){
            Destroy(gameObject);
        }
    }
}
