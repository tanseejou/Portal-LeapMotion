using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static clapClose;

public class rightHandPos : MonoBehaviour
{
    public static Vector Rpos;
    public static bool rightO = false;
    LeapProvider provider;

    
    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    // Update is called once per frame
    void Update()
    {
        
            Frame frame = provider.CurrentFrame;
            Hand hand = frame.Hands[1];
            Rpos = hand.PalmPosition;
            //Debug.Log("right hand position : " +Rpos);
        
    }
}
