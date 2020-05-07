using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static rightHandPos;
using UnityEngine.VFX;
using static rightHandPos;
public class clapClose : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector palmPosL, palmPosR;
    public static bool leftO = false;
    
    LeapProvider provider;
    private VisualEffect ve;
    public GameObject portal;

    public void leftHandOpen(){
        leftO = true;
        rightHandPos.rightO = true;   
        //Debug.Log("left : " +leftO+" right "+rightO);      
    }
    /*public void rightHandOpen(){
        rightO = true; 
        Debug.Log("right " +rightO+" left "+leftO);       
    }*/
    
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        ve = GetComponent<VisualEffect>();
       // ve.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftO && rightHandPos.rightO){
            Frame frame = provider.CurrentFrame;
            Hand hand = frame.Hands[0];
            palmPosL = hand.PalmPosition * -1000;
            palmPosR = rightHandPos.Rpos * -1000;

            //Debug.Log("leftt hand position : " +palmPosL);
            //Debug.Log("right hand position : " +palmPosR);

            float distance = Mathf.Sqrt(Mathf.Pow((this.palmPosL.x - this.palmPosR.x),2) + Mathf.Pow((this.palmPosL.y - this.palmPosR.y),2));
            //Debug.Log("Distance = " +distance);

            if(distance <= 10){
               // ve.Stop();
                portal.SetActive(false);
                
            }
        }

        /*if(leftO == true && rightO == true){
            
            Frame frame = provider.CurrentFrame;
            
            Hand firstHand = frame.Hands[0];
            
            Hand secondHand = frame.Hands[1];
            

            palmPosL = firstHand.PalmPosition * 100;
            palmPosR = secondHand.PalmPosition * 100;
            Debug.Log("posL : " +palmPosL);
            Debug.Log("posR : " +palmPosR);
            float distance = Mathf.Sqrt(Mathf.Pow((this.palmPosL.x - this.palmPosR.x),2) + Mathf.Pow((this.palmPosL.y - this.palmPosR.y),2));
            Debug.Log("Distance = " +distance);

            if(distance < 5){
                portal.SetActive(false);
                //ve.Stop();
            }
        }*/
        
    }
}

  /*public float Interval = .1f; //seconds
  
  public UnityEvent OnClap;

  private LeapProvider provider = null;
  private bool velocityThresholdExceeded = false;

  public float Proximity = 0.1f; //meters
  public float VelocityThreshold = 0.1f; //meters/s
  public float PalmAngleLimit = 75; //degrees

  #if UNITY_EDITOR
  //Debugging variables --set Inspector to debug mode
  private float currentAngle = 0;
  private float currentVelocityVectorAngle = 0;
  private float currentDistance = 0;
  private float currentVelocity = 0;
  #endif

  void Start () {
    provider = GetComponentInParent<LeapServiceProvider>();
  }

  void Update(){
    Hand thisHand;
    Hand thatHand;
    Frame frame = provider.CurrentFrame;
    if(frame != null && frame.Hands.Count >= 2){
      thisHand = frame.Hands[0];
      thatHand = frame.Hands[1];
      if(thisHand != null && thatHand != null){
        Vector velocityDirection = thisHand.PalmVelocity.Normalized;
        Vector otherhandDirection = (thisHand.PalmPosition - thatHand.PalmPosition).Normalized;

        #if UNITY_EDITOR
        //for debugging
        Debug.DrawRay(thisHand.PalmPosition.ToVector3(), velocityDirection.ToVector3());
        Debug.DrawRay(thatHand.PalmPosition.ToVector3(), otherhandDirection.ToVector3());
        currentAngle = thisHand.PalmNormal.AngleTo(thatHand.PalmNormal) * Constants.RAD_TO_DEG;
        currentDistance = thisHand.PalmPosition.DistanceTo(thatHand.PalmPosition);
        currentVelocity = thisHand.PalmVelocity.MagnitudeSquared + thatHand.PalmVelocity.MagnitudeSquared;
        currentVelocityVectorAngle = velocityDirection.AngleTo(otherhandDirection) * Constants.RAD_TO_DEG;
        #endif

        if( thisHand.PalmVelocity.MagnitudeSquared + thatHand.PalmVelocity.MagnitudeSquared > VelocityThreshold &&
          velocityDirection.AngleTo(otherhandDirection) >= (180 - PalmAngleLimit) * Constants.DEG_TO_RAD){
          velocityThresholdExceeded = true;
        }
      }
    }
  }

  void OnEnable () {
    StartCoroutine(clapWatcher());
  }

  void OnDisable () {
    StopCoroutine(clapWatcher());
  }

  IEnumerator clapWatcher() {
    Hand thisHand;
    Hand thatHand;
    while(true){
      if(provider){
        Frame frame = provider.CurrentFrame;
        if(frame != null && frame.Hands.Count >= 2){
          thisHand = frame.Hands[0];
          thatHand = frame.Hands[1];
          if(thisHand != null && thatHand != null){
            //decide if clapped
            if(velocityThresholdExceeded && //went fast enough
                      thisHand.PalmPosition.DistanceTo(thatHand.PalmPosition) < Proximity && // and got close 
                      thisHand.PalmNormal.AngleTo(thatHand.PalmNormal) >= (180 - PalmAngleLimit) * Constants.DEG_TO_RAD) //while facing each other
            {
              OnClap.Invoke();
            } 
          }
        }
      }
      velocityThresholdExceeded = false;
      yield return new WaitForSeconds(Interval);
    }
  }*/