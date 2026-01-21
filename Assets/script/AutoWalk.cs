using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class AutoWalk : MonoBehaviour
{
    public float moveSpeed = 3f;

    [Header("Footsteps")]
    public float stepInterval = 0.5f;
    public AudioClip[] footstepSounds;

    private CharacterController controller;
    private AudioSource audioSource;

    private float stepTimer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleMovement();
        HandleFootsteps();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.SimpleMove(move * moveSpeed);
    }

    void HandleFootsteps()
    {
        if (!controller.isGrounded)
            return;

        Vector3 horizontalVelocity = controller.velocity;
        horizontalVelocity.y = 0f;

        if (horizontalVelocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length == 0)
            return;

        int index = Random.Range(0, footstepSounds.Length);
        audioSource.PlayOneShot(footstepSounds[index]);
    }
}
