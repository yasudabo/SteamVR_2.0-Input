using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRInput_Test : MonoBehaviour {



    [Tooltip("此操作應適用的設備。 如果操作不是特定於設備，則為任何操作")]
    public SteamVR_Input_Sources inputSource;


    // Use this for initialization
    void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {

        Check_Trigger();
        Check_Grip();
        Check_Pad();
        Check_PadPos();
    }

    /// <summary>
    /// 檢查板機狀態
    /// </summary>
    private void Check_Trigger() {
        if (VRInput.GetPressDown(inputSource, EM_ControllerButton.Trigger)) {
            Debug.LogWarning("按下板機");
        }

        if (VRInput.GetPress(inputSource, EM_ControllerButton.Trigger)) {
            Debug.LogWarning("按住板機");
        }

        if (VRInput.GetPressUp(inputSource, EM_ControllerButton.Trigger)) {
            Debug.LogWarning("放開板機");
        }
    }


    /// <summary>
    /// 檢查握柄狀態
    /// </summary>
    private void Check_Grip() {
        if (VRInput.GetPressDown(inputSource, EM_ControllerButton.Grip))  {
            Debug.LogWarning("按下握柄");
        }

        if (VRInput.GetPress(inputSource, EM_ControllerButton.Grip)) {
            Debug.LogWarning("按住握柄");
        }

        if (VRInput.GetPressUp(inputSource, EM_ControllerButton.Grip)) {
            Debug.LogWarning("放開握柄");
        }
    }


    /// <summary>
    /// 檢查圓盤狀態
    /// </summary>
    private void Check_Pad() {
        if (VRInput.GetPressDown(inputSource, EM_ControllerButton.Pad)) {
            Debug.LogWarning("按下圓盤");
        }

        if (VRInput.GetPress(inputSource, EM_ControllerButton.Pad)) {
            Debug.LogWarning("按住圓盤");
        }

        if (VRInput.GetPressUp(inputSource, EM_ControllerButton.Pad)) {
            Debug.LogWarning("放開圓盤");
        }
    }


    /// <summary>
    /// 檢查圓盤四邊的狀態 
    /// 需要找個物件掛上 SteamVR_ActivateActionSetOnLoad.cs 激活 platformer動作集
    /// </summary>
    private void Check_PadPos() {

        //上
        if (VRInput.GetPressDown(inputSource, EM_ControllerButton.PadUp)) {
            Debug.LogWarning("按下圓盤-上");
        }
        if (VRInput.GetPress(inputSource, EM_ControllerButton.PadUp)) {
            Debug.LogWarning("按住圓盤-上");
        }
        if (VRInput.GetPressUp(inputSource, EM_ControllerButton.PadUp)) {
            Debug.LogWarning("放開圓盤-上");
        }

        //下
        if (VRInput.GetPressDown(inputSource, EM_ControllerButton.PadDown)) {
            Debug.LogWarning("按下圓盤-下");
        }
        if (VRInput.GetPress(inputSource, EM_ControllerButton.PadDown)) {
            Debug.LogWarning("按住圓盤-下");
        }
        if (VRInput.GetPressUp(inputSource, EM_ControllerButton.PadDown)) {
            Debug.LogWarning("放開圓盤-下");
        }
        
        
        //左
        if (VRInput.GetPressDown(inputSource, EM_ControllerButton.PadLeft)) {
            Debug.LogWarning("按下圓盤-左");
        }
        if (VRInput.GetPress(inputSource, EM_ControllerButton.PadLeft)) {
            Debug.LogWarning("按住圓盤-左");
        }
        if (VRInput.GetPressUp(inputSource, EM_ControllerButton.PadLeft))  {
            Debug.LogWarning("放開圓盤-左");
        }
        
        //右
        if (VRInput.GetPressDown(inputSource, EM_ControllerButton.PadRight)) {
            Debug.LogWarning("按下圓盤-右");
        }
        if (VRInput.GetPress(inputSource, EM_ControllerButton.PadRight)) {
            Debug.LogWarning("按住圓盤-右");
        }
        if (VRInput.GetPressUp(inputSource, EM_ControllerButton.PadRight)) {
            Debug.LogWarning("放開圓盤-右");
        }


    }






}
