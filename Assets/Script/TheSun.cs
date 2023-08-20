using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheSun : MonoBehaviour
{
    public GameObject theSun;
    private float Radius = 9f;
    float latitudeAngle = 45.565f;
    float longitudeAngle = 45f;
    bool N, S, W, E;


    void Start()
    {
        N = true;
        E = true;
        PositionTheSun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PositionTheSun()
    {
        if (N) latitudeAngle = Mathf.Abs(latitudeAngle);      
        else latitudeAngle = -latitudeAngle;

        if (E) longitudeAngle = Mathf.Abs(longitudeAngle);
        else longitudeAngle = -longitudeAngle;


        float ridiusSublatitude = Radius * Mathf.Sin(((90 - latitudeAngle) * (2f * Mathf.PI)) / 360);  //Ban kinh cua vi do co goc latitude
        float Giam = Radius * Mathf.Cos((90 - latitudeAngle) * (2f * Mathf.PI / 360));     // khoanr cach cuar tam duong tron vi do mois so voi vi do goc
        float x = ridiusSublatitude * Mathf.Cos(longitudeAngle * (2f * Mathf.PI / 360));
        float y = ridiusSublatitude * Mathf.Sin(longitudeAngle * (2f * Mathf.PI / 360));
        //Debug.Log("DO DAI : " + ridiusViDo);
        //Debug.Log("DO DAI Giam : " + Giam);
        //Debug.Log("DO DAI TONG : " + (Giam + ridiusViDo));

        Vector3 positionSun = new Vector3(x, Giam, y);
        theSun.transform.position = positionSun;
    }
}
