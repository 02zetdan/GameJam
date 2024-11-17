using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHitRegister : MonoBehaviour
{
    PlayerMainScript pmScript;
    public GameObject AudioManager;

    float stunTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        pmScript = GetComponent<PlayerMainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stunTimer <  0)
        {
            pmScript.isStunned = false;
        }
        stunTimer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("weapon"))
        {
            return;
        }

        RotatingFallingObject rfo = collision.gameObject.GetComponent<RotatingFallingObject>();

        if (rfo.pickup == Pickup.FryingPan)
        {
            FindObjectOfType<AudioManager>().Play("FryingPanHit");
            stunTimer = 1.5f;
            pmScript.isStunned = true;
        }
        else if (rfo.pickup == Pickup.RollingPin)
        {
            FindObjectOfType<AudioManager>().Play("RollingPinHit");
            stunTimer = 1f;
            pmScript.isStunned = true;
        }



    }
}
