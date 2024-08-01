using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class hollowgram : MonoBehaviour
{
   Playeraction inputAction;

    bool showbutton;
    bool upbutton;
    bool leftbutton;
    bool rightbutton;
    
   [SerializeField] float offsetofy;
    [SerializeField]float offsetofx;
    [SerializeField]float offsetofnegativex;
    [SerializeField] float offsetyaxis;
    [SerializeField] Transform environment;
   public bool yrotation = false;


  [SerializeField]  Transform mainplayer;

    [SerializeField] GameObject hollwogram;
    void Start()
    {
        hollwogram.SetActive(false);
        inputAction.controll.leftclick.started += Leftclick_started;
        inputAction.controll.leftclick.performed += Leftclick_started;
        inputAction.controll.leftclick.canceled += Leftclick_started;
        inputAction.controll.uparrow.started += Uparrow_started;
        inputAction.controll.uparrow.performed += Uparrow_started;
        inputAction.controll.uparrow.canceled +=Uparrow_started;
        inputAction.controll.leftarrow.started += Leftarrow_started;
        inputAction.controll.leftarrow.performed += Leftarrow_started;
        inputAction.controll.leftarrow.canceled += Leftarrow_started;
        inputAction.controll.rightarrow.started += Rightarrow_started;
        inputAction.controll.rightarrow.performed +=Rightarrow_started;
        inputAction.controll.rightarrow.canceled += Rightarrow_started;

    }

    private void Rightarrow_started(InputAction.CallbackContext obj)
    {
        rightbutton = obj.ReadValueAsButton();
    }

    private void Leftarrow_started(InputAction.CallbackContext obj)
    {
        leftbutton = obj.ReadValueAsButton();
    }

    private void Uparrow_started(InputAction.CallbackContext obj)
    {
        upbutton = obj.ReadValueAsButton(); 
    }

    private void Leftclick_started(InputAction.CallbackContext obj)
    {
       showbutton= obj.ReadValueAsButton();
    }

    private void Awake()
    {
        inputAction = new Playeraction();
        
    }

    // Update is called once per frame
    void Update()
    {
        hollwogram.transform.position = mainplayer.transform.position;
        hollwogram.transform.rotation = mainplayer.transform.rotation;
        if (showbutton)
        {
            hollwogram.SetActive(true);
            if (upbutton)
            {
                Vector3 offsety =new Vector3(mainplayer.transform.position.x, mainplayer.transform.position.y + offsetofy,mainplayer.transform.position.z);
                hollwogram.transform.position = offsety;
                hollwogram.transform.rotation =Quaternion.Euler(180,0,0);

               
                    environment.transform.position = new Vector3(59.54908f, 21.87576f, -8.617163f);
                     environment.transform.rotation = Quaternion.Euler(environment.transform.rotation.x,environment.transform.rotation.y, -179.995f);




                movement.instance.playervelocity.y = 0.1f;
                movement.instance.gravityvalue = 0;
             
            }
           
            if (leftbutton)
            {
                Vector3 offsetnegativex = new Vector3(mainplayer.transform.position.x+offsetofnegativex, mainplayer.transform.position.y+offsetyaxis, mainplayer.transform.position.z);
                hollwogram.transform.position = offsetnegativex;

                hollwogram.transform.rotation = Quaternion.Euler(0, 180,90);
                environment.transform.position = new Vector3(20.58078f, 4, -8.617163f);
                environment.transform.rotation = Quaternion.Euler(0, 0, -360.221f);
                movement.instance.gravityvalue = 0;
                movement.instance.playervelocity.y = 0.1f;
            }
            if (rightbutton)
            {
                Vector3 offsetx = new Vector3(mainplayer.transform.position.x+offsetofx, mainplayer.transform.position.y+offsetyaxis, mainplayer.transform.position.z);
                hollwogram.transform.position = offsetx;
                hollwogram.transform.rotation = Quaternion.Euler(0, 180, -90);
                environment.transform.position = new Vector3(32.90837f, 34.0002f, -8.617163f);
                environment.transform.rotation = Quaternion.Euler(environment.transform.rotation.x, environment.transform.rotation.y, - 90.099f);
                movement.instance.gravityvalue = 0;
                movement.instance.playervelocity.y = 0.1f;

            }
            
        }
        else
        {
            hollwogram.SetActive(false);
        }
        if (!upbutton || !rightbutton || !leftbutton)
        {
            movement.instance.gravityvalue = -19;
            
        }
        
        
    }
    private void OnEnable()
    {
        inputAction.controll.Enable();
    }
    private void OnDisable()
    {
        inputAction.controll.Disable();
    }
}
