﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit() {
        WanderingAI enemyAI = GetComponent<WanderingAI>();

        if (enemyAI != null) { enemyAI.ChagneState(EnemyStates.dead); }

        StartCoroutine(Die());
    }

    private IEnumerator Die() {
        // Enemy falls over and dies after 2 seconds
        iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);

        yield return new WaitForSeconds(2);

        Destroy(this.gameObject);
    }
}
