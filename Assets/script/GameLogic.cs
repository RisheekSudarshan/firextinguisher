    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class GameLogic : MonoBehaviour {

        public GameObject water;
        public static bool inside;
        public static int score;
        public GameObject cong;
    
    //  public static int ins;

        //
        void Start () {

            score = 0;
        //  water.GetComponent<EllipsoidParticleEmitter>().emit = false;
        }
        
        // Update is called once per frame
        void Update()
{
    // HOLD to spray
    if (Input.GetButton("Fire1"))
    {
        inside = true;
        water.GetComponent<EllipsoidParticleEmitter>().emit = true;
    }
    else
    {
        water.GetComponent<EllipsoidParticleEmitter>().emit = false;
        inside = false;
    }

    if (score >= 20)
    {
        cong.SetActive(true);
        StartCoroutine(WaitAndPrint());
    }
}


        IEnumerator WaitAndPrint()
        {
            yield return new WaitForSeconds(15f);
            Application.Quit();
            //print("WaitAndPrint " + Time.time);
        }
    }
