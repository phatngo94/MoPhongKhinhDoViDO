using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class TheSun : MonoBehaviour
{
    public GameObject theSun;
    private float Radius = 9f;
    public GameObject cube;
    public GameObject shadow;
    public Transform underCube;
    public Transform topCube;
    

    public LineRenderer line;

    public static TheSun Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Vector3 fwd = transform.TransformDirection((topCube.transform.position - theSun.transform.position));
        Debug.DrawRay(theSun.transform.position, fwd * 50f, Color.blue);

    }

    public void PositionTheSun(float latitudeAngle, float longitudeAngle,bool north,bool east)
    {
        float shadowDirection = longitudeAngle;
        shadow.transform.position =new Vector3(underCube.position.x,underCube.position.y+0.01f,underCube.position.z);
        if (north) latitudeAngle = Mathf.Abs(latitudeAngle);      
        else latitudeAngle = -latitudeAngle;

        if (east) longitudeAngle = Mathf.Abs(longitudeAngle);
        else longitudeAngle = -longitudeAngle;


        float ridiusSublatitude = Radius * Mathf.Sin(((90 - latitudeAngle) * (2f * Mathf.PI)) / 360);  //Ban kinh cua vi do co goc latitude
        float X0 = Radius * Mathf.Cos((90 - latitudeAngle) * (2f * Mathf.PI / 360));     // khoan cach  tam duong tron vi do mois so voi vi do goc
        float x = ridiusSublatitude * Mathf.Cos(longitudeAngle * (2f * Mathf.PI / 360));
        float y = ridiusSublatitude * Mathf.Sin(longitudeAngle * (2f * Mathf.PI / 360));       

        Vector3 positionSun = new Vector3(x, X0, y);
        theSun.transform.position = positionSun;
        Debug.Log("POSITION: " + positionSun);
       
        RayCastHit(theSun.transform, topCube,shadowDirection);
      
    }

    private void RayCastHit(Transform p1, Transform p2,float longitudeAngle)
    {
        Vector3 fwd = transform.TransformDirection((p2.transform.position - theSun.transform.position));
        RaycastHit hit;
        if (Physics.Raycast(fwd,p1.position, out hit, 1000f))
        {
            Debug.DrawRay(p1.position, fwd * 100f, Color.red);

            if (hit.transform.gameObject.tag == "Land")
            {
                shadow.SetActive(true);
                Debug.Log("You hit a ray" + hit.point);
                Vector3 targetDir = hit.point - theSun.transform.position;
                float angleBetween = Vector3.Angle(transform.forward, targetDir);
                float offset = (underCube.transform.position - hit.point).magnitude;
                if (longitudeAngle > 90) angleBetween = -angleBetween;
                shadow.transform.localScale = new Vector3(shadow.transform.localScale.x, offset, shadow.transform.localScale.z);
                shadow.transform.eulerAngles = new Vector3(90f, 0, angleBetween);

                float SunToHitPoin = (theSun.transform.position - hit.point).magnitude;
                float SunToTopCube = (theSun.transform.position - topCube.transform.position).magnitude;

                if (SunToHitPoin < SunToTopCube) Debug.Log("Duoi");
                else Debug.Log("Tren");

                /*line.positionCount = 2;
                line.SetPosition(0, underCube.transform.position);
                line.SetPosition(1, hit.point);*/

            }
            else shadow.SetActive(false);
            
        }

    }
}
