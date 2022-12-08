using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//i'm not using this script at the moment
public class KeyChanger : Button
{
    [SerializeField]
    int mine;

    bool setKey;

    public override void Do()
    {
        print("Current key: " + InfoToSave.keysInUse[mine]);
        StartCoroutine(SetKey());
    }

    IEnumerator SetKey()
    {
        print("Waiting...");
        yield return new WaitForSeconds(2);
        print("Set Key");
        setKey = true;
    }

    void OnGUI()
    {
        if (setKey && Input.GetKeyUp(Event.current.keyCode))
        {
            print("Key pressed: " + Event.current.keyCode);
            InfoToSave.keysInUse[mine] = Event.current.keyCode;
            print("New key: " + InfoToSave.keysInUse[mine]);
            setKey = false;
        }
    }
}