using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objecttransporter : MonoBehaviour
{
    //public Transform player;
    public Transform receiver;
    public Transform cube; 

    //private bool playerIsOverlapping = false;
    private bool cubeIsOverLapping = false;

    // Update is called once per frame
    void Update()
    { 
        /*if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                //Teleport
                float rotationDiff = Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff,0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                Debug.Log(player.position);
                playerIsOverlapping = false;

            }
        }*/
        
        if(cubeIsOverLapping){
            Vector3 portalTocube = cube.position - transform.position;
            float dotProduct2 = Vector3.Dot(transform.up, portalTocube);
            //cube.position.z += 0.1; 
            if(dotProduct2 < 0f){
                float rotationDiff2 = Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff2 += 180;
                cube.Rotate(Vector3.up, rotationDiff2);

                Vector3 positionOffset2 = Quaternion.Euler(0f, rotationDiff2, 0f) * portalTocube;
                cube.position = receiver.position + positionOffset2;

                cubeIsOverLapping = false;
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cube") 
        {
            //playerIsOverlapping = true;
            cubeIsOverLapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "cube") {
            
            //playerIsOverlapping = false;
            cubeIsOverLapping = false;
            
        }
    }
}
