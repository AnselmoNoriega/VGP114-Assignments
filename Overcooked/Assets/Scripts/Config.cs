using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Config : MonoBehaviour
{
    public Model model;

    private void Start()
    {
        model = gameObject.AddComponent(typeof(Model)) as Model;
    }
}
