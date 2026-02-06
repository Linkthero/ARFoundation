using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceJumpController : MonoBehaviour
{
    public ARFace face;
    public Rigidbody rb;
    public playerJump player;

    [Header("Jump Settings")]
    public float jumpForce = 8f;
    public float pitchThreshold = -15f;
    public float cooldown = 0.8f;

    private bool isGrounded = true;
    private float lastJumpTime;

    // Update is called once per frame
    void Update()
    {
        if (face == null || rb == null) return;

        Vector3 rotation = face.transform.localEulerAngles;
        float pitch = rotation.x;
        if(pitch > 180) pitch -= 360;

        if(pitch < pitchThreshold && player.isGrounded && Time.time - lastJumpTime > cooldown)
        {
            Jump();
        }

        void Jump()
        {
            //UIManager.Instance.MostrarMensaje("Jump");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            player.isGrounded = false;
            lastJumpTime = Time.time;
        }
    }
}
