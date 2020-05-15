using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Variables {

    #region Cat Controller

    [System.NonSerialized]
    public float speed = 1.8f;
    [System.NonSerialized]
    public float rigiValue = 15;
    [System.NonSerialized]
    public float speedRotation = 100;

    [System.NonSerialized]
    public bool mouseButtonDown;
    [System.NonSerialized]
    public bool playing;
    [System.NonSerialized]
    public float rayDistance = 2;
    [System.NonSerialized]
    public bool onTriggerBackground;


    [System.NonSerialized]
    public string stepOne = "StepOne";
    [System.NonSerialized]
    public string stepTwo = "StepTwo";
    [System.NonSerialized]
    public string stepThree = "StepThree";
    [System.NonSerialized]
    public string fallBackStepTwo = "FallBackStepTwo";
    [System.NonSerialized]
    public string fallBackStepThree = "FallBackStepThree";
    [System.NonSerialized]
    public string fallTowardStepOne = "FallTowardStepOne";
    [System.NonSerialized]
    public string fallTowardStepTwo = "FallTowardStepTwo";
    [System.NonSerialized]
    public string fallTowardStepThree = "FallTowardStepThree";
    #endregion


    #region Checking Object
    [System.NonSerialized]
    public float range = 3.3f;
    #endregion


    #region Check Point
    [System.NonSerialized]
    public bool hitCheckPoint;
    [System.NonSerialized]
    public bool hitStrawberry;
    #endregion


    #region Fall Back Checking
    [System.NonSerialized]
    public float distanceOfRaycast_B = 4.65f;
    [System.NonSerialized]
    public bool falling_B;
    [System.NonSerialized]
    public bool hitGround_B;
    [System.NonSerialized]
    public bool hitEdge_B;
    #endregion

    #region Fall Toward Checking
    [System.NonSerialized]
    public float distanceOfRaycast_T = 4.65f;
    [System.NonSerialized]
    public bool falling_T;
    [System.NonSerialized]
    public bool hitGround_T;
    [System.NonSerialized]
    public bool hitEdge_T;
    #endregion


    #region Grounded Check
    [System.NonSerialized]
    public float maxDistance = 0.4f;
    [System.NonSerialized]
    public bool onAir;
    #endregion


    #region Camera Controller
    [System.NonSerialized]
    public float smoothSpeed = 2;
    #endregion

    #region Game Controller
    [System.NonSerialized]
    public int scoreValue = 0;
    [System.NonSerialized]
    public int medalScoreValue = 0;
    [System.NonSerialized]
    public int strawberryScoreValue = 0;

    [System.NonSerialized]
    public bool gameBegin;
    #endregion


    #region Background Control
    [System.NonSerialized]
    public float startX_B = -10;
    #endregion
}
