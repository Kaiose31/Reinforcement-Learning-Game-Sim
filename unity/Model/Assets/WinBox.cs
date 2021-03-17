using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    // Start is called before the first frame update
    private void onTriggerEnter(Collider other)
    {
        GameObject.Find("Car").SendMessage("Finnish");
    }
}
