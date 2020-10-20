using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource rocketSound;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
        
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
            // make some noiiiiise
            if (!rocketSound.isPlaying){
                rocketSound.Play();
            }
        } else {
            rocketSound.Stop();
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
            print("A pressed!");
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
            print("D pressed!");
        }

    }
}
