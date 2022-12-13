using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexSpecifically : Characters
{
    //Cool as fuck. B)


    public override void Start()
    {
        base.Start();
        allLines = new string[][] { new string[] { "", "Cool as fuck. B)", "hehehe" }, new string[] { "", "Cool as fuck. B)", "woah", "awesome" } , new string[] {"", "Have you heard about our lord and saviour, Pana? Well basically to summarize Pana is not exactly a being but instead something closer to an omnipotent, omniscient and omniprescent concept. Somethign that we as mortals fail to comprehend. You are a mortal and so you shall stay until you accept Pana into your heart. Are you a believer? Do you believe in gravity? Is Pana in your heart? Accept him. Accept him. Accept Him. Accept HIm. ASCEND! ASCEND! ASCCEND WITH PANA! And once you do you shall figure out the meaning of life. Nirvana. Something special above that. What use is there to reincarnation when you can live a finite life of hapiness, knowing fully that you have been blessed by THE Pana. The gospel of Pana starts when he was a young screw, who gradually evolved into bigger and bigger mechanisms. He has now realised his true potential and is taking the form as a human but remains as a concept. He blesses us with mathematical abilities, philosphy, the meaning of life, Xenoblade."} };

        progressTriggers[7, 2] = lineChangerString;
    }


    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.A))
        {
            UpdateProgress(7);
        }
    }

    public override int GetRow()
    {
        if (infoThingy.progress[7] - 48 == 2)
        {
            talkable = true;
            return 2;
        }
        else
        {
            return base.GetRow();
        }
    }

}
