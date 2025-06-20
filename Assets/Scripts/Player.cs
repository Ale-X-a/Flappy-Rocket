using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngineSound;

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource= FindFirstObjectByType<AudioSource>(); //only if there is only one audiosources
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        float currentThrust = mainThrust;
        
        if (Input.GetKey(KeyCode.X))
        {
            currentThrust *= 0.10f;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * currentThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSound);
            }
        }
        else
        { 
            {
                audioSource.Stop();
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Vector3.forward * currentThrust * Time.deltaTime);
        }
    }
    

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(-rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(rotationThrust);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddRelativeForce(-Vector3.forward * mainThrust * Time.deltaTime);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    { 
        transform.Rotate(Vector3.up * rotationThisFrame * Time.deltaTime);
    
    }
    
}