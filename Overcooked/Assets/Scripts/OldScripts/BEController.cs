using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BEController : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        Destroy(GameObject.FindGameObjectWithTag("OrderSheet"));
    }
}
