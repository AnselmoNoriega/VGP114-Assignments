using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Model obs;
    public Model next;
    public TextMeshProUGUI text;
    public Button bColor;
    Model[] stopStates;

    public void OnButtonClick()
    {
        StateChange();
        Debug.Log("Button Clicked!");
    }

    public void CountDown()
    {

        if (obs.state == States.Running && obs.count >= 0)
        {
            obs.fill.color = obs.gradient.Evaluate(obs.slider.value / obs.slider.maxValue);
            obs.count -= 10 * Time.deltaTime;
        }

        
    }

    public void FinishState()
    {
        if (obs.count <= 0 && obs.state == States.Running && !obs.overCooked)
        {
            obs.state = States.Finished;
            OverCooked();
        }
        else if(obs.count <= 0 && obs.state == States.Running && obs.overCooked)
        {
            obs.state = States.Burned;
            text.text = "BURNED";
            bColor.GetComponent<Image>().color = Color.black;
        }
    }

    public void StateManager()
    {
        if (obs.state == States.Locked)
        {
            bColor.GetComponent<Image>().color = Color.gray;
        }
        else if (obs.state == States.Running && obs.overCooked && obs.tag == "CookTime")
        {
            bColor.GetComponent<Image>().color = Color.red;
        }
        //else if (obs.state == States.Running)
        //{
        //    I need Help with this line
        //    bColor.GetComponent<Image>().color = Color.yellow;
        //}
        else if(obs.state == States.Finished)
        {
            bColor.GetComponent<Image>().color = Color.white;
            text.text = "Finished";
        }
        else if (obs.state == States.Unlocked)
        {
            bColor.GetComponent<Image>().color = Color.green;
        }

    }

    void OverCooked()
    {
        if (obs.tag == "CookTime" && !obs.overCooked && obs.state == States.Finished)
        {
            obs.overCooked = true;
            obs.count = obs.MAXCOUNT;
            obs.state = States.Running;
            obs.gradient = obs.burnedGradient;
            text.text = "OverCooked";
        }
        else
        {
            next.state = States.Unlocked;
        }
    }

    void StopStates()
    {
       stopStates = FindObjectsOfType<Model>();

        foreach (Model item in stopStates)
        {
            if((item.tag == "WashTime" || item.tag == "CutTime") && item.state == States.Running)
            {
                item.state = States.Unlocked;
            }
        }
    }

    public void StateChange()
    {
        if(obs.state != States.Locked)
        {
            StopStates();
        }

        if (obs.state == States.Unlocked)
        {
            obs.state = States.Running;
        }
        if (obs.overCooked && obs.state == States.Running)
        {
            obs.state = States.Finished;
        }
        if (obs.state == States.Burned)
        {
            obs.overCooked = false; 
            obs.count = obs.MAXCOUNT;
            obs.state = States.Running;
            text.text = "Redo Cook";
            bColor.GetComponent<Image>().color = Color.yellow;
        }
    }


}
