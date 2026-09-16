using UnityEngine;

public static class InputHandler
{
    // Keyboard/gamepad first; touch support can be added by wiring these to UI buttons
    public static float GetHorizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public static bool JumpPressed()
    {
        return Input.GetButtonDown("Jump");
    }

    public static bool FirePressed()
    {
        return Input.GetButton("Fire1");
    }

    public static bool CrouchHeld()
    {
        return Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S);
    }

    public static bool MountTogglePressed()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
