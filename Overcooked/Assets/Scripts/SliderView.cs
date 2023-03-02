using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderView : MonoBehaviour
{
    [HideInInspector]
    public bool IsClicked;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Onclick()
    {
        IsClicked = true;
    }
}
