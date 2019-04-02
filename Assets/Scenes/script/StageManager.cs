﻿using System.Collections;
using System.Collections.Generic;
using System.IO;  //StreamWrite會用到

using UnityEngine;


public class StageManager : MonoBehaviour {

    public int currentStage =0;
    public GameObject[] stages;
    public PathAndActionRecorder recorder;

	// Use this for initialization
	void Start () {

        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        FileInfo[] allFiles = directoryInfo.GetFiles("playTime.txt");
        int playtime = int.Parse(allFiles[0].OpenText().ReadLine());
        stages[2].GetComponent<timer>().TotalTime = playtime;
        setStage(currentStage);
    }

    public void Next()
    {
        currentStage++;
        if (currentStage >= stages.Length)
            currentStage = 0;

        setStage(currentStage);

    }

    public void setStage(int i) {


        for (int index = 0; index < stages.Length; index++) {

            if (index == i)
            {
                stages[index].SetActive(true);
            }
            else {
                stages[index].SetActive(false);
            }

        }

        if (i == 1) {
           stages[i].GetComponent<Animator>().Play("fadeIn");
        }
        if (i == 2)
        {
            recorder.Stop();
            recorder.StartRecord();
        }
        else if (i == 3)
        {
            recorder.Stop();
            recorder.save();
            recorder.StartReplay();
        }

    }

    public void EndGame() {
        Application.Quit();
    }


}
