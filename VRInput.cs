using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public enum EM_ControllerButton{
    None = -1,
    System = 14,
    Menu = 1,

    Pad = 2,
    Grip = 3,
    Trigger = 4,

    PadUp = 5,
    PadDown = 6,
    PadLeft = 7,
    PadRight = 8,
}


public enum EM_ControllerPadPos {
    PadUp = 1,
    PadDown = 2,
    PadLeft = 3,
    PadRight = 4,
}



/// <summary>
/// 簡易 SteamVR 2.0 的按鍵接口
/// </summary>
public static class VRInput {

    /// <summary>
    /// 按住
    /// </summary>
    /// <param name="inputSource"> 輸入源 </param>
    /// <param name="_button"    > 哪個鍵 </param>
    /// <returns></returns>
    public static bool GetPress(SteamVR_Input_Sources inputSource, EM_ControllerButton _button) {
        switch (_button) {

            case EM_ControllerButton.Pad:
                if (SteamVR_Input._default.inActions.Teleport.GetState(inputSource))  {
                    return true;
                }
                break;

            case EM_ControllerButton.Grip:
                if (SteamVR_Input._default.inActions.GrabGrip.GetState(inputSource)) {
                    return true;
                }
                break;

            case EM_ControllerButton.Trigger:
                if (SteamVR_Input._default.inActions.GrabPinch.GetState(inputSource)) {
                    return true;
                }
                break;


            case EM_ControllerButton.PadUp:
                if (SteamVR_Input._default.inActions.Teleport.GetState(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadDown:
                if (SteamVR_Input._default.inActions.Teleport.GetState(inputSource))  {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadLeft:
                if (SteamVR_Input._default.inActions.Teleport.GetState(inputSource))  {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadRight:
                if (SteamVR_Input._default.inActions.Teleport.GetState(inputSource))  {
                    return CheckPadPos(inputSource, _button);
                }
                break;

        }

        return false;
    }



    /// <summary>
    /// 按下
    /// </summary>
    /// <param name="inputSource"> 輸入源 </param>
    /// <param name="_button"    > 哪個鍵 </param>
    /// <returns></returns>
    public static bool GetPressDown(SteamVR_Input_Sources inputSource, EM_ControllerButton _button) {
        switch (_button)  {

            case EM_ControllerButton.Pad:
                if (SteamVR_Input._default.inActions.Teleport.GetStateDown(inputSource))  {
                    return true;
                }
                break;

            case EM_ControllerButton.Grip:
                if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(inputSource)) {
                    return true;
                }
                break;

            case EM_ControllerButton.Trigger:
                if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(inputSource)) {
                    return true;
                }
                break;


            case EM_ControllerButton.PadUp:
                if (SteamVR_Input._default.inActions.Teleport.GetStateDown(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadDown:
                if (SteamVR_Input._default.inActions.Teleport.GetStateDown(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadLeft:
                if (SteamVR_Input._default.inActions.Teleport.GetStateDown(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadRight:
                if (SteamVR_Input._default.inActions.Teleport.GetStateDown(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;


        }

        return false;

    }


    /// <summary>
    /// 放開
    /// </summary>
    /// <param name="inputSource"> 輸入源 </param>
    /// <param name="_button"    > 哪個鍵 </param>
    /// <returns></returns>
    public static bool GetPressUp(SteamVR_Input_Sources inputSource, EM_ControllerButton _button) {
        switch (_button) {

            case EM_ControllerButton.Pad:
                if (SteamVR_Input._default.inActions.Teleport.GetStateUp(inputSource)) {
                    return true;
                }
                break;

            case EM_ControllerButton.Grip:
                if (SteamVR_Input._default.inActions.GrabGrip.GetStateUp(inputSource)) {
                    return true;
                }
                break;

            case EM_ControllerButton.Trigger:
                if (SteamVR_Input._default.inActions.GrabPinch.GetStateUp(inputSource))  {
                    return true;
                }
                break;


            case EM_ControllerButton.PadUp:
                if (SteamVR_Input._default.inActions.Teleport.GetStateUp(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadDown:
                if (SteamVR_Input._default.inActions.Teleport.GetStateUp(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadLeft:
                if (SteamVR_Input._default.inActions.Teleport.GetStateUp(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;

            case EM_ControllerButton.PadRight:
                if (SteamVR_Input._default.inActions.Teleport.GetStateUp(inputSource)) {
                    return CheckPadPos(inputSource, _button);
                }
                break;

        }
        return false;
    }



    /// <summary>
    /// 取得手在圓盤鍵的位置 (注意：使用此功能需要先找個物件掛上 SteamVR_ActivateActionSetOnLoad.cs 激活 platformer動作集)
    /// </summary>
    /// <param name="inputSource"> 輸入源 </param>
    /// <returns></returns>
    public static Vector2 GetPadAxis(SteamVR_Input_Sources inputSource) {
        return SteamVR_Input.platformer.inActions.Move.GetAxis(inputSource);
    }



    /// <summary>
    /// 確認圓盤鍵觸碰的位置  (注意：使用此功能需要先找個物件掛上 SteamVR_ActivateActionSetOnLoad.cs 激活 platformer動作集，因為使用到了 GetPadAxis的部分)
    /// </summary>
    /// <param name="tmp"> 手把圓盤按下的位置結果 </param>
    private static bool CheckPadPos(SteamVR_Input_Sources inputSource, EM_ControllerButton _button) {
        float angle = VectorAngle(new Vector2(1, 0), GetPadAxis(inputSource));
        switch (_button) {
            case EM_ControllerButton.PadUp:
                if (angle < -45 && angle > -135) {
                    return true;
                }
                break;
            case EM_ControllerButton.PadDown:
                if (angle > 45 && angle < 135) {
                    return true;
                }
                break;
            case EM_ControllerButton.PadLeft:
                if ((angle < 180 && angle > 135) || (angle < -135 && angle > -180)) {
                    return true;
                }
                break;
            case EM_ControllerButton.PadRight:
                if ((angle > 0 && angle < 45) || (angle > -45 && angle < 0)) {
                    return true;
                }
                break;
        }
        return false;
    }


    /// <summary>
    /// 根據在圓盤才按下的位置，返回一個角度值
    /// </summary>
    private static float VectorAngle(Vector2 from, Vector2 to) {
        float angle;
        Vector3 cross = Vector3.Cross(from, to);
        angle = Vector2.Angle(from, to);
        return cross.z > 0 ? -angle : angle;   //如果 cross.z > 0，傳回 -angle，否則傳 angle
    }



}
