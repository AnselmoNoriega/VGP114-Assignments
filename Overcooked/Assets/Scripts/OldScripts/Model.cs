using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum sStates
{
    None,
    Unlocked,
    Locked,
    Finished,
    Running,
    Burned
}

public class Model : MonoBehaviour
{
    public Slider slider;
    public float count;
    public float MAXCOUNT;
    public Gradient gradient;
    public Gradient burnedGradient;
    public States state;
    public Image fill;
    public bool overCooked = false;

    void Start()
    {
        count = MAXCOUNT;
        slider.maxValue = MAXCOUNT;
        slider.value = MAXCOUNT;
        fill.color = gradient.Evaluate(1f);
        if (tag == "MenuTime")
        {
            state = States.Running;
        }
        else if(tag == "WashTime")
        {
            state = States.Unlocked;
        }
        else
        {
            state = States.Locked;
        }
    }
   

}
