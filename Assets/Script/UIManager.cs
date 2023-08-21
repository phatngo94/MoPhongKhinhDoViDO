using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float latitudeAngle;
    public float longitudeAngle;
    public bool north = true;
    public bool south = false;
    public bool east = true;
    public bool west = false;

    public InputField InputLatitude;
    public InputField InputLongtitude;
    public Toggle TgNorth;
    public Toggle TgSouth;
    public Toggle TgEast;
    public Toggle TgWest;
    public Button btnOK;


    private void Start()
    {
        AddEvent();
    }
    private void AddEvent()
    {
        InputLongtitude.onEndEdit.AddListener(delegate { GetInputLongitude(); }) ;
        InputLatitude.onEndEdit.AddListener(delegate { GetInputLaitude(); }) ;
        TgNorth.onValueChanged.AddListener(delegate { GetNorthDirection(); });
        TgSouth.onValueChanged.AddListener(delegate { GetSouthDirection(); });
        TgEast.onValueChanged.AddListener(delegate { GetEastDirection(); });
        TgWest.onValueChanged.AddListener(delegate { GetWestDirection(); });
        btnOK.onClick.AddListener(delegate { OnChangePositionTheSun(); });
    }

    private void GetInputLongitude()
    {
        string input = InputLongtitude.text;
        float angle = float.Parse(input, CultureInfo.InvariantCulture);
        if (input == "") longitudeAngle = 0f;
        else
        {
            if (angle <= 180f && angle >= 0f) longitudeAngle = angle;
            else if (angle > 180f)
            {
                longitudeAngle = 180f;
                InputLongtitude.text = "180";
            }
            else if (angle < 0f)
            {
                longitudeAngle = 0f;
                InputLongtitude.text = "0";
            }
        }
        
    }

    private void GetInputLaitude()
    {
        string input = InputLatitude.text;
        float angle = float.Parse(input, CultureInfo.InvariantCulture);
        if (input == "") latitudeAngle = 0f;
        else
        {
            if (angle <= 90f && angle >= 0f) latitudeAngle = angle;
            else if (angle > 90f)
            {
                latitudeAngle = 90f;
                InputLatitude.text = "90";
            }
            else if (angle < 0f)
            { 
                latitudeAngle = 0f;
                InputLatitude.text = "0";
            }
        }
        
    }

    private void GetNorthDirection()
    {
        if (TgNorth.isOn) north = true;
        else north = false;
    }

    private void GetSouthDirection()
    {
        if (TgSouth.isOn) south = true;
        else south = false;
    }

    private void GetEastDirection()
    {
        if (TgEast.isOn) east = true;
        else east = false;
    }

    private void GetWestDirection()
    {
        if (TgWest.isOn) west = true;
        else west = false;
    }

    private void OnChangePositionTheSun()
    {      
        TheSun.Instance.PositionTheSun(latitudeAngle,longitudeAngle,north,east);
    }
}
