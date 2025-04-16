using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
     //public string sceneName;
     [SerializeField] private string sceneName;

     public void SceneChange(){
        if (!string.IsNullOrEmpty(sceneName)){
            SceneManager.LoadScene(sceneName);
        }else{
            Debug.LogError("Scene name is not set in the inspector");
        }
     }
}
