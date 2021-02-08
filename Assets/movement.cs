using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    public float speed;
    private bool moving;
    private Rigidbody2D rigid;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    private int counter=0;
    public GameObject rollas;
    float eulerAnglesY;
     private Vector3 rotateValue;    

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
        
            
        if (Input.GetAxisRaw("Horizontal")>0f ) 
        {
            rigid.velocity=new Vector3(speed,rigid.velocity.y,0f);
            Debug.Log(transform.rotation.y+"CAN ROLLAS");
            if(transform.eulerAngles.y==180){
                transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
            }
            
            
        }
        else if (Input.GetAxisRaw("Horizontal")<0f) 
        {
            rigid.velocity=new Vector3(-1*speed,rigid.velocity.y,0f);
            float ankara1=rollas.transform.rotation.eulerAngles.y;
            Debug.Log(transform.rotation.y+"CAN ROLLAS");
            if(transform.eulerAngles.y==0){
                transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
            }
            
        }

            

        
        else{
            rigid.velocity=new Vector3(rigid.velocity.x*0.5f,rigid.velocity.y,0f);
        }
            
        if (Input.GetKeyDown("space") && isGrounded==true) 
        {
        
            Debug.Log("Key code Space algılandı!");
            rigid.velocity=new Vector3(rigid.velocity.x,20,0f);
            counter=1;
        }    
        else if (counter==1 && Input.GetKeyDown("space")){
            rigid.velocity=new Vector3(rigid.velocity.x,30,0f);
            counter=0;
        }    

            

                
                
        

    
        
        
        
    }
}
