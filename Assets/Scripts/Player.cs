using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField]  float mainThrust = 100f;
    [SerializeField]  float rotationThrust = 1f;
    
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame// movement keys !! each frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
           // Debug.Log("Engine enabled");
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Rotate left");
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        
        {
            Debug.Log("Rotate right");
            ApplyRotation(-rotationThrust);
            }
    }
    
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;//disables physics control of rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime); //rotate up, spins it
        rb.freezeRotation = false;//re-enables
    }
}
