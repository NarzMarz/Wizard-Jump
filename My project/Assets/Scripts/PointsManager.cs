using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{   
    public TMP_Text currentPointsText;
    public TMP_Text recordPointsText;
    private int currentPoints = 0;
    private int recordPoints = 0;
    public static PointsManager pointsManager;
    void Start()
    {
        currentPoints = PlayerPrefs.GetInt("CurrentPoints", 0);
        recordPoints = PlayerPrefs.GetInt("RecordPoints", 0);
        currentPointsText.text = currentPoints.ToString();
        recordPointsText.text = recordPoints.ToString();
    }

    public void AddPoints(){
        currentPoints++;
        PlayerPrefs.SetInt("CurrentPoints", currentPoints);
        PlayerPrefs.Save();
        currentPointsText.text = currentPoints.ToString();
        if(currentPoints > recordPoints){
            recordPoints = currentPoints;
            PlayerPrefs.SetInt("RecordPoints", recordPoints);
            PlayerPrefs.Save();
            recordPointsText.text = recordPoints.ToString();
        }

    }

    void Awake()
    {
        if(pointsManager == null){
            pointsManager = this;
        } else {
            Destroy(gameObject);
        }
    }
}
