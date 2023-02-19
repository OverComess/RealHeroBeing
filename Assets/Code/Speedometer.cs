using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [SerializeField]
    CarController carController;

    [SerializeField]
    Text speedoMeter;
    void FixedUpdate()
    {
        speedoMeter.text = "kmph: " + ((int)+carController.move).ToString();
    }
}
