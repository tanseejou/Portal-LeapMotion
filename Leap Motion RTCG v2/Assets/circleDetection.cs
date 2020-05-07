using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using UnityEngine.VFX;
public class circleDetection : MonoBehaviour
{
    //private float yes, no = 0;
    //private bool center = false;
    //private float centerX = 0;
    //private float centerY = 0; 
    private float x, y = 0;
    //private float firstX, firstY = 0;    
    //private float distance = 0;
    //private float firstDistance = 0;
    //private float ppDistance = 0;
    //private float degree, totalDegree = 0;
    //private float beforeInv = 0;
    private VisualEffect ve;
    private int count = 0;
    private float degree1 = 0;
    public GameObject portal;
    LeapProvider provider;
    
    // Start is called before the first frame update
    void Start()
    {
       provider = FindObjectOfType<LeapProvider>() as LeapProvider;
       //portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {       
        Frame frame = provider.CurrentFrame;
        Hand hand = frame.Hands[0];
        Vector position = hand.PalmPosition;
        //position = -position * 1000;
        
        float dx = 0;
        float dy = 0;


        //Vector2 position = Input.mousePosition;
        dx = position.x - this.x;
        dy = position.y - this.y;
        this.x = position.x;
        this.y = position.y;

        float slope = dy / dx;
        float degree2 = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Debug.Log("degree 1 : "+degree1+ " 2 " +degree2);
        if (degree2 < 0)
        {
            degree2 = 360 + degree2;
        }

        if (degree2 < this.degree1)
        {
            count++;
        }
        else
        {
            if (count > 0)
            {
                count = count - 5;
            }

        }


        this.degree1 = degree2;
        Debug.Log("count : "+count);
        if (count >= 100)
        {
            portal.SetActive(true);
            Debug.Log("CIRCLE");
        }

    }
    /*if (Input.GetMouseButtonDown (0)) {
     //Debug.Log ("mouseDown = " + Input.mousePosition.x + " " + Input.mousePosition.y);
     this.centerX = Input.mousePosition.x;
     this.centerY = Input.mousePosition.y;
     center = true;
     //Debug.Log(center);
    }  

    if(center){
        //Vector2 position = Input.mousePosition;

        Debug.Log("hand position: " +position.x +" "+position.y);
        this.x = position.x;
        this.y = position.y;

        distance = Mathf.Sqrt(Mathf.Pow((centerX - this.x),2) + Mathf.Pow((centerY - this.y),2));
        Debug.Log("distance = " +distance);

        if(distance >= 2660 && distance <=2680){
            if(yes == 0){
                this.firstX = position.x;
                this.firstY = position.y;
                firstDistance = Mathf.Sqrt(Mathf.Pow((centerX - this.firstX),2) + Mathf.Pow((centerY - this.firstY),2));
                //Debug.Log("first point: " + firstX +" "+firstY);
            }
            yes++;

            ppDistance = Mathf.Sqrt(Mathf.Pow((this.x - this.firstX),2) + Mathf.Pow((this.y - this.firstY),2));
            Debug.Log("point -- point : " +ppDistance);
            beforeInv = (Mathf.Pow(distance,2) + Mathf.Pow(firstDistance,2) -Mathf.Pow(ppDistance,2)) / 
                (2 * distance * firstDistance);

            Debug.Log("value :" +beforeInv);
            degree = Mathf.Acos(beforeInv) * Mathf.Rad2Deg;
            //Debug.Log("degree : " +degree);

            if((beforeInv <= 1) && (beforeInv >=0) && (degree <= 90)){
                if((totalDegree >= 0) && (totalDegree <= 90)){
                    totalDegree = degree;
                }
                else if(totalDegree >= 100){
                    totalDegree = 180 + (180 - degree);
                }
            }
            else if((beforeInv >= -1) && (beforeInv <=0) && (degree >= 90)){
                if((totalDegree >= 80) && (totalDegree <= 150)){
                    totalDegree = degree;
                }
                else if(totalDegree >= 100){
                    totalDegree = 180 + (180 - degree);
                }
            }
            Debug.Log("total degree :" +totalDegree);

            if((totalDegree >= 355) && (totalDegree <= 360)){

                if((yes/(yes+no))>=0.5){
                    float percentage = yes/(yes+no);
                    Debug.Log("yeah " + percentage);
                    ve.Play();

                    //Debug.Log(yes);
                    //Debug.Log(no);
                }    
                totalDegree = 0;
                yes = 0;
                no = 0;                
            }
        }
        else if(yes != 0){
            no++;
        }   

        //if(yes == 50){
        //    ve.Play();
        //}

    }*/
}


/*float dx = 0;
        float dy = 0;


        //Vector2 position = Input.mousePosition;
        dx = position.x - this.x;
        dy = position.y - this.y;
        this.x = position.x;
        this.y = position.y;

        float slope = dy / dx;
        float degree2 = Mathf.Atan2(dy,dx) * Mathf.Rad2Deg;
        if(degree2 < 0)
        {
            degree2 = 360 + degree2;
        }

        if (degree2 > this.degree1)
        {
            count++;
        }
        else
        {
            if (count > 0)
            {
                count = count -3;
            }
            
        }


        this.degree1 = degree2;
        Debug.Log(count);
        if(count >= 100)
        {
            Debug.Log("CIRCLE");
        }
    
    }
*/