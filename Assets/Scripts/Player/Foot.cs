using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(TagsConsts.GROUND))
        {
            Player player = gameObject.transform.root.GetComponent<Player>();
            Platform p = collision.transform.root.GetComponent<Platform>();

            if (player.Jumped)
            {
                player.Jumped = false;

                if (player.Anim)
                {
                    player.Anim.SetBool("Jumped", false);
                }
                if (player.Rb)
                {
                    player.Rb.velocity = Vector3.zero;
                }
                player.jumpForce = Vector3.zero;

                player.CurPowerBarVal = 0;
                GameGUIManager.Ins.UpdatePowerBar(player.CurPowerBarVal, 1);
            }

            if (p && p.id != player.lastPlatformId)
            {
                GameManager.Ins.CreatePlatformAndLerp(transform.position.x);
                player.lastPlatformId = p.id;
                AudioController.Ins.PlaySound(AudioController.Ins.getScore);
                GameManager.Ins.AddScore();
            }
        }
    }
}
