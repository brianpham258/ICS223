using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit() {
        WanderingAI enemyAI = GetComponent<WanderingAI>();
        Animator enemyAnimator = GetComponent<Animator>();

        if (enemyAI != null) { enemyAI.ChagneState(EnemyStates.dead); }
        if (enemyAnimator != null) { enemyAnimator.SetTrigger("Die"); }
        //StartCoroutine(Die());
    }

    private void DeadEvent ()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator Die() {
        // Enemy falls over and dies after 2 seconds
        //iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);

        yield return new WaitForSeconds(2);

        Destroy(this.gameObject);
    }
}
