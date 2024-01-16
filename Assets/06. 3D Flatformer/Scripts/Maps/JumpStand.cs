using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStand : Trap
{
    private Coroutine currentCo;
    [SerializeField] private GameObject jumpStand;
    private IEnumerator Animation(PlayerHp player)
    {
        Vector3 jump = transform.forward * 100 + transform.up * 10;
        player.gameObject.GetComponent<Rigidbody>().AddForce(jump, ForceMode.Impulse);

        int count = 0;
        while(count <= 30)
        {
            jumpStand.transform.Rotate(4, 0, 0);
            yield return new WaitForSeconds(0.01f);
            count++;
        }


        yield return new WaitForSeconds(0.1f);
        jumpStand.transform.rotation = Quaternion.Euler(0, 0, 0);
        currentCo = null;
        yield return null;
    }

    protected override void OnTrap(PlayerHp player)
    {
        if (currentCo == null)
            currentCo = StartCoroutine(Animation(player));
    }
}
