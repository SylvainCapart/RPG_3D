using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float m_Radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, m_Radius);
    }
}
