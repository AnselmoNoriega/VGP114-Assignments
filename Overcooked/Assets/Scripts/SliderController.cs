using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    private Config modelC;
    private SliderView sliderOn;
    public float time;

    private void Start()
    {
        modelC.model.MAXCOUNT = time;
    }

    private void Update()
    {
        modelC.model.MAXCOUNT = time;
        if (sliderOn)
        {
            modelC.model.state = States.Running;
            Debug.Log("Button Clicked!");
        }
    }

    private void FixedUpdate()
    {
        CountDown();
    }


    public void CountDown()
    {

        if (modelC.model.state == States.Running && modelC.model.count >= 0)
        {
            modelC.model.fill.color = modelC.model.gradient.Evaluate(modelC.model.slider.value / modelC.model.slider.maxValue);
            modelC.model.count -= 1 * Time.deltaTime;
        }


    }
}
