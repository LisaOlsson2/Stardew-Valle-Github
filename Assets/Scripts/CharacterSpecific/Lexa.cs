using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lexa : Characters
{
    float timer;
    float randomSecondsBeforeHerTailWaves;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        randomSecondsBeforeHerTailWaves = 5;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;

        if (timer > randomSecondsBeforeHerTailWaves)
        {
            animator.SetTrigger("idleTrigger");
            randomSecondsBeforeHerTailWaves = Random.Range(1f, 11f);
            timer = 0;
        }
    }
}