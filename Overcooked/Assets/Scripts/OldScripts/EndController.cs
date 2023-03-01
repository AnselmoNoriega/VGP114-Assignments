using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    public Model finishCook;
    public Button finishButton;

    // Start is called before the first frame update
    void Update()
    {
        if (finishCook.state == States.Finished || finishCook.state == States.None)
        {
            Vector3 pos = new Vector3(170f, -130f, 0f);

            Button newFC = Instantiate(finishButton, pos, transform.rotation);
            newFC.transform.SetParent(transform.parent, false);

            Destroy(this);
        }
    }
}
