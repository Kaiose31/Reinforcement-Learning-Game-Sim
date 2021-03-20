using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    private List<CheckpointS> checkpointSList;
    private int nextCheckpointSIndex;
    private void Awake() {
        Transform checkpointsTransform = transform.Find("Checkpoints");
        checkpointSList = new List<CheckpointS>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform) {
            CheckpointS checkpointS = checkpointSingleTransform.GetComponent<CheckpointS>();
            checkpointS.SetTrackCheckpoints(this);
            checkpointSList.Add(checkpointS);
        }
        nextCheckpointSIndex = 0;
    }

    public void PlayerThroughCheckpoint(CheckpointS checkpointS) {
        //  Debug.Log(checkpointS.transform.name);
        if (checkpointSList.IndexOf(checkpointS) == nextCheckpointSIndex)
        {
            Debug.Log("Correct");
            nextCheckpointSIndex = (nextCheckpointSIndex +1 )% checkpointSList.Count;

        }
        else {

            Debug.Log("wrong");

        }


    }
    
}
