using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float ViDo;
    public float KinhDo;
    public bool North;
    public bool South;
    public bool East;
    public bool West;

    public InputField InputLatitude;
    public InputField InputLongtitude;
    public Toggle TgNorth;
    public Toggle TgSouth;
    public Toggle TgEast;
    public Toggle TgWest;
    public Button OK;


    private void AddEvent()
    {
        InputLongtitude.onEndEdit.AddListener(delegate { GetInputLongitude(); }) ;
        InputLatitude.onEndEdit.AddListener(delegate { GetInputLaitude(); }) ;
        TgNorth.onValueChanged.AddListener(delegate { GetNorthDirection(); });
        TgSouth.onValueChanged.AddListener(delegate { GetSouthDirection(); });
        TgEast.onValueChanged.AddListener(delegate { GetEastDirection(); });
        TgWest.onValueChanged.AddListener(delegate { GetWestDirection(); });
    }

    private void GetInputLongitude()
    {
        string input = InputLongtitude.text;
        if (input == "") KinhDo = 0;
        else
        {
            if (float.Parse(input) > 90) KinhDo = 90;
            if (float.Parse(input) < 0) KinhDo = 0;
        }
    }

    private void GetInputLaitude()
    {
        string input = InputLatitude.text;
        if (input == "") ViDo = 0;
        else
        {
            if (float.Parse(input) > 180) ViDo = 180;
            if (float.Parse(input) < 0) ViDo = 0;
        }
    }

    private void GetNorthDirection()
    {
        if (TgNorth.isOn) North = true;
        else North = false;
    }

    private void GetSouthDirection()
    {
        if (TgSouth.isOn) South = true;
        else South = false;
    }

    private void GetEastDirection()
    {
        if (TgEast.isOn) East = true;
        else East = false;
    }

    private void GetWestDirection()
    {
        if (TgWest.isOn) West = true;
        else West = false;
    }
}
