using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UI;

public class movement : MonoBehaviour
{
    [SerializeField] int score=0;
    public static movement instance { get; private set; }
    Playeraction action;
   public bool jumppressed;
    [SerializeField]
    float playerdistance = 2f;
    [SerializeField]LayerMask exlude;
    private CharacterController characterController;
    [SerializeField] private float playerspeed = 2.0f;
    [SerializeField] private float jumpheight = 1.0f;
   public  float gravityvalue = -9.18f;
    [SerializeField] private float rotationspeed = 4f;
    RaycastHit hit;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] Transform isground;
    bool isgrounded;
    bool jumpbutton;
  public   Vector3 playervelocity;
    private bool groundplayer;
    private Transform cameras;
    public bool running;

    const string run = "run";

    Animator animator;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameras = Camera.main.transform;
        animator = GetComponent<Animator>();
       
        
    }
    private void OnEnable()
    {

        action.controll.Enable();
       
    }

    private void OnDisable()
    {


        action.controll.Disable();

    }
    private void Awake()
    {
        instance = this;
        action = new Playeraction();
        action.controll.jump.started += jump;
        action.controll.jump.performed += jump;
        action.controll.jump.canceled += jump;
    }
    void jump(InputAction.CallbackContext callbackContext)
    {
        jumppressed = callbackContext.ReadValueAsButton();
    }
    void Update()
    {
      
        Vector2 movement = this.action.controll.move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);

        move = cameras.forward * move.z + cameras.right * move.x;
        move.y = 0;
        characterController.Move(move * Time.deltaTime * playerspeed);

        if (movement != Vector2.zero)
        {
            float targetangle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameras.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetangle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationspeed);

        }
       
       
        running = move != Vector3.zero;

        runanimation();
        jumpandfalling();
        raycasthits();
       
    }

     void runanimation()
    {

        bool isrun = animator.GetBool(run);
        if (running && !isrun)
        {
            animator.SetBool(run, true);
        }
        if (!running && isrun)
        {
            animator.SetBool(run, false);
        }

    }
    void jumpandfalling()
    {
        isgrounded = Physics.CheckSphere(isground.position, .2f, groundlayer);

        if (isgrounded)
        {
            if (jumppressed)
            {


                playervelocity.y = Mathf.Sqrt(jumpheight * 2 * -gravityvalue);
                jumppressed = false;


            }
            animator.SetBool("fall", false);
        }
        else
        {
            playervelocity.y += gravityvalue * Time.deltaTime;
          
            animator.SetBool("fall", true);
        }

        characterController.Move(playervelocity * Time.deltaTime);


       
    }
    void raycasthits()
    {
        if(Physics.SphereCast(transform.position,0.5f,transform.forward,out hit, 5, ~exlude))
        {
            if(Vector3.Distance(transform.position, hit.transform.position) > playerdistance)
            {
                if(hit.transform.gameObject.tag == "points")
                {
                    Destroy(hit.transform.gameObject);
                    score++;
                }
            }
        }
    }
    

  
    public int scores()
    {
        return score;
    }
}
