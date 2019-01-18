using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


/// <summary>
/// SteamVR 2.0 簡易功能實現
/// </summary>
public class SteamVrPlugin2_Example : MonoBehaviour {


    [Tooltip("此操作應適用的設備。 如果操作不是特定於設備，則為任何操作")]
    public SteamVR_Input_Sources inputSource;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Check_Pad();
        Check_Grip();
        Check_Trigger();
    }

    /// <summary>
    /// 偵測平板
    /// </summary>
    public void Check_Pad() {
        if (SteamVR_Input._default.inActions.Teleport.GetState(inputSource)) {
            //需要找個物件掛上 SteamVR_ActivateActionSetOnLoad.cs 激活同樣是預設的platformer動作集
            GetPadPos(SteamVR_Input.platformer.inActions.Move.GetAxis(SteamVR_Input_Sources.Any));
        }

        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(inputSource)) {
            Debug.LogWarning("觸控板按下");
        }

        if (SteamVR_Input._default.inActions.Teleport.GetStateUp(inputSource)) {
            Debug.LogWarning("觸控板放開");
        }

        //需要找個物件掛上 SteamVR_ActivateActionSetOnLoad.cs 激活同樣是預設的platformer動作集
        if (SteamVR_Input.platformer.inActions.Move.GetChanged(inputSource)) {
            Debug.LogWarning("觸控板觸控中");
        }

    }


    /// <summary>
    /// 偵測兩側鍵
    /// </summary>
    public void Check_Grip() {
        if (SteamVR_Input._default.inActions.GrabGrip.GetState(inputSource)) {
            Debug.LogWarning("握柄鍵按住");
        }

        if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(inputSource)) {
            Debug.LogWarning("握柄鍵按下");
        }

        if (SteamVR_Input._default.inActions.GrabGrip.GetStateUp(inputSource)) {
            Debug.LogWarning("握柄鍵放開");
        }
    }


    /// <summary>
    /// 偵測板機
    /// </summary>
    public void Check_Trigger() {
        if (SteamVR_Input._default.inActions.GrabPinch.GetState(inputSource)) {
            Debug.LogWarning("板機按住");
        }

        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(inputSource)) {
            Debug.LogWarning("板機按下");
        }

        if (SteamVR_Input._default.inActions.GrabPinch.GetStateUp(inputSource)) {
            Debug.LogWarning("板機放開");
        }
    }



    /// <summary>
    /// 取得觸控板位置
    /// </summary>
    /// <param name="tmp"> 手把圓盤按下的位置結果 </param>
    void GetPadPos(Vector2 tmp) {
        float angle = VectorAngle(new Vector2(1, 0), tmp);
        if (angle > 45 && angle < 135) {
            Debug.LogWarning("按住觸控板 - 下方");
        }    
        else if (angle < -45 && angle > -135) {
            Debug.LogWarning("按住觸控板 - 上方");
        }  
        else if ((angle < 180 && angle > 135) || (angle < -135 && angle > -180)) {
            Debug.LogWarning("按住觸控板 - 左方");
        }
        else if ((angle > 0 && angle < 45) || (angle > -45 && angle < 0)) {
            Debug.LogWarning("按住觸控板 - 右方");
        }

    }


    /// <summary>
    /// 根據在圓盤才按下的位置，返回一個角度值
    /// </summary>
    float VectorAngle(Vector2 from, Vector2 to) {
        float angle;
        Vector3 cross = Vector3.Cross(from, to);
        angle = Vector2.Angle(from, to);
        return cross.z > 0 ? -angle : angle;   //如果 cross.z > 0，傳回 -angle，否則傳 angle
    }


}
