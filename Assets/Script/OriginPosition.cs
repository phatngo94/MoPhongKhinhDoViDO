using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer line;
    public float radius=9;
    public bool check = true;
    void Start()
    {
        DrawCircle(check);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawCircle(bool Check)
    {
        line.loop = true;  // Cela ferme le cercle
        line.positionCount = 360;

        float angle = 10f;

        for (int i = 0; i < 360; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            if (Check) line.SetPosition(i, new Vector3(x, 0, y));  //Vi Do Goc
            else line.SetPosition(i, new Vector3(x, y, 0));       //Kinh DO Goc

            angle += 2f * Mathf.PI / 360;
        }
    }
}
