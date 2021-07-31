using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrows : MonoBehaviour
{
    GameObject cursor;
    float lookingAngle = 0;

    float turningSpeed = 3;
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
       cursor = GameObject.FindGameObjectWithTag("Player");
    }



    // Update is called once per frame
    void Update()
    {        
        // turn immidiately 
        //lookAt2D(cursor);
 

        // turn incremental
        turnToTarget(cursor.transform.position);

        if (Input.GetMouseButton(0) == true)
        {
            drawLine();//from arrow to cursor
        }
        //move Forward
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    void lookAt2D(GameObject target)
    {
        lookAt2D(target.transform);
    }

    void lookAt2D(Transform target)
    {
        lookAt2D(target.position);
    }
    void lookAt2D(Vector3 target)
    {
        Vector3 diff = (target - transform.position).normalized;
        float rot_z = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) + 360 ;

        transform.rotation = Quaternion.Euler(0f, 0f, rot_z );
    }

    void lookAt2D(float zAngle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);
    }

    float calcAngle(Vector3 directionVector)
    {
        float rot_z = (Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg);

        //Atan2 returns the angle between -180...180 degrees starting on the positive x asis
        // this code converts to 0...360 starting on the positive y axis 
        if (rot_z < 0)
        {

            rot_z = 270 - Mathf.Abs(rot_z);
        }
        else
        {
            // postive angle 0...180, starts on xAxis, anti clockwise
            rot_z = 270 + rot_z;
            if(rot_z >= 360)rot_z -=360; 
        }
        return rot_z;
    }


    void turnToTarget(Vector3 target)
    {       
        var direction = (target - transform.position).normalized;
        var targetAngle = calcAngle(direction);
        
        int turningDirection = 1;
        //determine turning direction
        if(targetAngle > lookingAngle)
        {
            // target is ahead
            if((targetAngle-lookingAngle) > 180)
            {
                //target is far ahead, go backwards
                turningDirection = -1;
            }
        }
        else
        {
            // target is back
            turningDirection = -1;
            if ((lookingAngle - targetAngle) > 180)
            {
                //target is far back , go forward
                turningDirection = 1;
            }

        }

        //check if target angle is nearly reached  and if yes, lock to it 
        if ((targetAngle - turningSpeed/2 - 0.5) < lookingAngle && lookingAngle < (targetAngle + turningSpeed/2 + 0.5))
        {
            lookingAngle = targetAngle;
        }
        else
        {
            //boundary check
            if(lookingAngle >= 360)
            {
                lookingAngle -= 360;
            }
            if (lookingAngle < 0)
            {
                lookingAngle += 360;
            }
            // update lookingAngle and perform turn
            lookingAngle = lookingAngle + (turningDirection * turningSpeed);
            lookAt2D(lookingAngle);

        }
    }

    
    void drawLine()
    {
        var start = transform.position;
        var end = cursor.transform.position;

        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(Color.black, Color.black);
        lr.SetWidth(0.01f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, .1f);
    }

}
