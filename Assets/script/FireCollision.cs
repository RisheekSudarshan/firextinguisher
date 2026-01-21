using UnityEngine;
using UnityEngine.UI;

public class FireCollision : MonoBehaviour
{
    public ParticleSystem system;
    public GameObject smoke;
    public Text scoreTxt;
    public GameObject water;

    private bool extinguished = false;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
        smoke.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (extinguished) return;

        if (other.CompareTag("Player") && GameLogic.inside)
        {
            ExtinguishFire();
        }
    }

    void ExtinguishFire()
{
    if (extinguished) return;

    extinguished = true;

    // Stop and CLEAR fire particles immediately
    if (system != null)
        system.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

    // Show smoke once
    if (smoke != null)
        smoke.SetActive(true);

    // Increase score ONCE
    GameLogic.score++;
    scoreTxt.text = "fire : " + GameLogic.score;

    // Stop water emission
    if (water != null)
        water.GetComponent<EllipsoidParticleEmitter>().emit = false;

    // Reset spray state so it doesn't restart
    GameLogic.inside = false;

    // Disable collider so it never triggers again
    if (col != null)
        col.enabled = false;

    // HARD VISUAL KILL SWITCH
    gameObject.SetActive(false);

    Debug.Log("Fire extinguished permanently");
}

}
