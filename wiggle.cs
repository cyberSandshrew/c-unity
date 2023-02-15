using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wiggle : MonoBehaviour
{

    float startTime;
    public float animDur = 1.0f;

    Vector3 startPos, endPos;
    public float posRange = 2.0f;
    public bool noZMove = true;

    Vector3 startRot, endRot;
    public float rotRange = 1.0f;
    public bool lockRotToZ = false;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        startRot = transform.eulerAngles;

        makeNewEnds();
    }

    float randomRange(float a, float b)
    {
        if (a > b)
        {
            return Random.Range(b, a);
        }
        else
        {
            return Random.Range(a, b);
        }
    }

    void makeNewEnds()
    {
        startTime = Time.time;

        endPos = new Vector3(
            randomRange(startPos.x - posRange, startPos.x + posRange),
            randomRange(startPos.y - posRange, startPos.y + posRange),
            noZMove ? 0 : randomRange(startPos.z - posRange, startPos.z + posRange)
        );

        endRot = new Vector3(
            lockRotToZ ? 0 : randomRange(startRot.x - rotRange, startRot.x + rotRange),
            lockRotToZ ? 0 : randomRange(startRot.y - rotRange, startRot.y + rotRange),
            randomRange(startRot.z - rotRange, startRot.z + rotRange)
        );
    }

    // Update is called once per frame
    void Update()
    {
        float timePassed = Time.time - startTime;
        float pctComplete = timePassed / animDur;

        if (pctComplete >= 1.0f)
        {
            makeNewEnds();
            return;
        }

        if (pctComplete < 0.5f)
        {
            transform.position = Vector3.Lerp(startPos, endPos, pctComplete * 2f);
            transform.eulerAngles = Vector3.Lerp(startRot, endRot, pctComplete * 2f);
        }
        else
        {
            // tween back
            float pct2 = (1.0f - pctComplete) * 2f;
            transform.position = Vector3.Lerp(startPos, endPos, pct2);
            transform.eulerAngles = Vector3.Lerp(startRot, endRot, pct2);
        }
    }
}
