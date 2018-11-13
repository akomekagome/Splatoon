using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//シングルトンにしてコントローラの参照元にします。

//注意
//ジョイコンを使う場合はヒエラルキーのジョイコンマネージャをアクティブにしてください


public class JoyconController : BestPracticeSingleton<JoyconController>
{
    private List<Joycon> joycons;

    public void Init()
    {
        joycons = JoyconManager.Instance.j;
        //Debug.Log("現在接続されているジョイコンの数は " + joycons.Count().ToString() + "です。");
    }

    public int GetJoyconLength() { return joycons.Count(); }

    //ジョイコンのジャイロの動きを送るためのメッソド
    public Vector3 GetGyro(int number)
    {
        return joycons[number - 1].GetGyro();
    }

    public float Horizontal(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetStick()[1];
        }
        //左の場合
        return joycons[number - 1].GetStick()[1] * -1f;
    }

    public float Vertical(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetStick()[0] * -1f;
        }
        //左の場合
        return joycons[number - 1].GetStick()[0];
    }



    public bool PusedRightButtonDownSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_UP);
        }
        //左の場合
        return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_DOWN);
    }

    public bool PusedLeftButtonDownSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_DOWN);
        }
        //左の場合
        return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_UP);
    }

    public bool PusedUpButtonDownSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_LEFT);
        }
        //左の場合
        return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_RIGHT);
    }

    public bool PusedDownButtonDownSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_RIGHT);
        }
        //左の場合
        return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_LEFT);
    }

    public bool PusedRightButtonSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButton(Joycon.Button.DPAD_UP);
        }
        //左の場合
        return joycons[number - 1].GetButton(Joycon.Button.DPAD_DOWN);
    }

    public bool PusedLeftButtonSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButton(Joycon.Button.DPAD_DOWN);
        }
        //左の場合
        return joycons[number - 1].GetButton(Joycon.Button.DPAD_UP);
    }

    public bool PusedUpButtonSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButton(Joycon.Button.DPAD_LEFT);
        }
        //左の場合
        return joycons[number - 1].GetButton(Joycon.Button.DPAD_RIGHT);
    }

    public bool PusedDownButtonSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButton(Joycon.Button.DPAD_RIGHT);
        }
        //左の場合
        return joycons[number - 1].GetButton(Joycon.Button.DPAD_LEFT);
    }

    public bool PusedRightButtonUpSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_UP);
        }
        //左の場合
        return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_DOWN);
    }

    public bool PusedLeftButtonUpSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_DOWN);
        }
        //左の場合
        return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_UP);
    }

    public bool PusedUpButtonUpSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_LEFT);
        }
        //左の場合
        return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_RIGHT);
    }

    public bool PusedDownButtonUpSide(int number)
    {
        if (!joycons[number - 1].isLeft)
        {
            //右の場合
            return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_RIGHT);
        }
        //左の場合
        return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_LEFT);
    }

    public bool PusedRightButtonDownLength(int number)
    {
        return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_RIGHT);
    }

    public bool PusedLeftButtonDownLength(int number)
    {
        return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_LEFT);
    }

    public bool PusedUpButtonDownLength(int number)
    {
        return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_UP);
    }

    public bool PusedDownButtonDownLength(int number)
    {
        return joycons[number - 1].GetButtonDown(Joycon.Button.DPAD_DOWN);
    }
    public bool PusedRightButtonLength(int number)
    {
        return joycons[number - 1].GetButton(Joycon.Button.DPAD_RIGHT);
    }

    public bool PusedLeftButtonLength(int number)
    {
        return joycons[number - 1].GetButton(Joycon.Button.DPAD_LEFT);
    }

    public bool PusedUpButtonLength(int number)
    {
        return joycons[number - 1].GetButton(Joycon.Button.DPAD_UP);
    }

    public bool PusedDownButtonLength(int number)
    {
        return joycons[number - 1].GetButton(Joycon.Button.DPAD_DOWN);
    }

    public bool PusedRightButtonUpLength(int number)
    {
        return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_RIGHT);
    }

    public bool PusedLeftButtonUpLength(int number)
    {
        return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_LEFT);
    }

    public bool PusedUpButtonUpLength(int number)
    {
        return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_UP);
    }

    public bool PusedDownButtonUpLength(int number)
    {
        return joycons[number - 1].GetButtonUp(Joycon.Button.DPAD_DOWN);
    }

    public Quaternion JoyconVector(int number)
    {
        return joycons[number - 1].GetVector();
    }

    public void SetVive(int number)
    {
        joycons[number - 1].SetRumble(10f, 320f, 0.6f, 200);
    }
}
