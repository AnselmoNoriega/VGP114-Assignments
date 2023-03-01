using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewSlider : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    public bool IsRunnning;

    void Start()
    {
        slider.maxValue = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        IsRunnning= false;
    }
    public void OnClick()
    {
        IsRunnning = true;
    }
}
