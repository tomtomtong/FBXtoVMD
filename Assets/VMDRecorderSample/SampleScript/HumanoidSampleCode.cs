using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HumanoidSampleCode : MonoBehaviour
{
    public string ModelName;
    public string HumanoidVMDName;

    private float StartRecordingTime=0.1f;
   // public float StopRecordingTime = 30f;

    string humanoidVMDPath = "";
    // Start is called before the first frame update
    void Start()
    {
        humanoidVMDPath = Application.dataPath + "/VMDRecorderSample/" + HumanoidVMDName;
        Invoke("StartRecording", StartRecordingTime);

        Animator aniCtr = this.GetComponent<Animator>();
        float StopRecordingTime = aniCtr.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Debug.Log(StopRecordingTime);
        Invoke("SaveRecord", StopRecordingTime);
    }

    void StartRecording()
    {
        GetComponent<UnityHumanoidVMDRecorder>().StartRecording();
    }

    void SaveRecord()
    {
        GetComponent<UnityHumanoidVMDRecorder>().StopRecording();
        GetComponent<UnityHumanoidVMDRecorder>().SaveVMD(ModelName, humanoidVMDPath);
        Application.OpenURL(Application.dataPath + "/VMDRecorderSample/");
    }
}