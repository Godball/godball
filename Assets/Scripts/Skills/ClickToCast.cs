using UnityEngine;
using System.Collections;

public class ClickToCast : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SendMessage("Activate");
        }
    }
}
