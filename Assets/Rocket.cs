using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)){   // can thrust while rotating; hence a separate IF here
            print("Thrusting");
            // time to fly!
            rigidBody.AddRelativeForce(Vector3.up);
            
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            print("A pressed!");
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            print("D pressed!");
        }

    }
}
