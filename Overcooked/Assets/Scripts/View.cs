using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Controller present;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        present.obs.slider.value = present.obs.count;
    }

    private void FixedUpdate()
    {
        present.StateManager();
        present.FinishState();
        present.CountDown();
    }

}
