using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSlider : MonoBehaviour
{
    public ModelSlider model;
    public ViewSlider view;

    void Start()
    {
        view.slider.value = view.slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsRunnning)
        {
            model.state = States.Running;
        }
    }

    private void FixedUpdate()
    {
        if(model.state == States.Running) 
        {
            model.fill.color = model.gradient.Evaluate(view.slider.value / view.slider.maxValue);
            view.slider.value -= 1 * Time.deltaTime;
        }
    }
}
