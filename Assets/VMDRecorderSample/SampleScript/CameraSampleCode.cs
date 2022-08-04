using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSampleCode : MonoBehaviour
{
    public string CameraVMDName = "testCameraVMD.vmd";

    public float StartRecordingTime = 0.5f;
    public float StopRecordingTime = 30f;

    string cameraVMDPath = "";
    // Start is called before the first frame update
    void Start()
    {
        cameraVMDPath = Application.dataPath + "/VMDRecorderSample/" + CameraVMDName;
        Invoke("StartRecording", StartRecordingTime);
        Invoke("SaveRecord", StopRecordingTime);
    }

    void StartRecording()
    {
        Camera.main.gameObject.GetComponent<UnityCameraVMDRecorder>().StartRecording();
    }

    void SaveRecord()
    {
        Camera.main.gameObject.GetComponent<UnityCameraVMDRecorder>().StopRecording();
        Camera.main.gameObject.GetComponent<UnityCameraVMDRecorder>().SaveVMD(cameraVMDPath);
    }
}
