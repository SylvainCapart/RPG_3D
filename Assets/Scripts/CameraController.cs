using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_Target;

    public Vector3 m_Offset;

    private float m_CurrentZoom = 10f;
    private float m_CurrentYaw = 0f;

    public float m_ZoomSpeed = 4f;
    public float m_MinZoom = 5f;
    public float m_MaxZoom = 15f;

    public float m_YawSpeed = 100f;

    public float m_Pitch;

    private void Update()
    {
        m_CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * m_ZoomSpeed;
        m_CurrentZoom = Mathf.Clamp(m_CurrentZoom, m_MinZoom, m_MaxZoom);

        m_CurrentYaw -= Input.GetAxis("Horizontal") * m_YawSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.position = m_Target.position - m_Offset * m_CurrentZoom;
        transform.LookAt(m_Target.position + Vector3.up * m_Pitch);

        transform.RotateAround(m_Target.position, Vector3.up, m_CurrentYaw);
    }
}
