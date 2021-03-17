using System.Drawing;
using System.Timers;
using System.Threading;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timeText;
    private float startTime;
    private bool finnished=false;
   // private float speedMax;

    // Start is called before the first frame update
    void Start()
    {
        startTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(finnished)
            return;
        float t=Time.time-startTime;
        
        string minutes = ((int) t/60).ToString();
        string seconds=(t%60).ToString("f2");
        timeText.text=minutes +" : "+ seconds;
    }
    public void Finnish()
    {
        finnished= true;
        timeText.color=Color.green;
    }
}
