using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum States
{
    None,
    Unlocked,
    Locked,
    Finished,
    Running,
    Burned
}

public class ModelSlider : MonoBehaviour
{
    public float count;
    public float MAXCOUNT;
    public Gradient gradient;
    public Gradient burnedGradient;
    public States state;
    public Image fill;
    public bool overCooked = false;

}
