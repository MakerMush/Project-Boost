using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 300f;
    [SerializeField] float mainThrust = 1f;
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
        Thrust();
        Rotate();

    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {   // can thrust while rotating; hence a separate IF here
            
            // time to fly!
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            // make some noiiiiise
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }
        }
        else
        {
            rocketSound.Stop();
        }
    }

        private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of the rotation

        
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        
        rigidBody.freezeRotation = false; // resume normal physics

    }

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Friendly":
            // do nothing
                break;
            case "Fuel":
            // TODO: add fuel I guess
                break;
            default:
                print("DEAD");
                break;
        }
        
    }

}
