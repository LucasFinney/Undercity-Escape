using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   Rigidbody rb;
   [SerializeField] float thrust = 1.0f;
   [SerializeField] float rotateSpeed = 1.0f;
   AudioSource audio;

Vector2 inVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       ProcessInput(); 
    }

    void ProcessInput()
    {
      inVector.x = Input.GetAxisRaw("Horizontal");
      inVector.y = Input.GetAxisRaw("Jump");

       if (inVector.y >0)
        {
            ApplyThrust();
        }else{
          audio.Stop();
        }
        if (inVector.x<0)
        {
            Debug.Log("Pressed Left");
            ApplyRotation(inVector);
        }
        else if(inVector.x>0)
       {
        Debug.Log("pressed right");
         ApplyRotation(inVector);
      }
    }

    private void ApplyThrust()
    {
        Debug.Log("pressed space");
        rb.AddRelativeForce(0, thrust * Time.deltaTime, 0);
        if (!audio.isPlaying){
          audio.Play();
        }
 
    }

    public void ApplyRotation(Vector3 _inVector)
    {
      //rb.constraints=RigidbodyConstraints.FreezeRotationZ; //Freeze rotation to manually rotate
      //transform.Rotate(Vector3.forward * Time.deltaTime *_inVector.x*rotateSpeed*-1 );
      //rb.AddTorque();
      rb.AddRelativeTorque(Vector3.forward * Time.deltaTime *_inVector.x*rotateSpeed*-1);
      //rb.constraints = RigidbodyConstraints.None;
      //rb.constraints=RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY; //Unfreeze to let phys system take over
    
    }
}
