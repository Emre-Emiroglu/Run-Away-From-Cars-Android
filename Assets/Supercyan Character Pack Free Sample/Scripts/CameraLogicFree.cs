using UnityEngine;
using System.Collections.Generic;

public class CameraLogicFree : MonoBehaviour {

    private Transform m_currentTarget;
    private float m_distance = 2f;
    private float m_height = 1;
    private float m_lookAtAroundAngle = 0;
    private float eğim = -15.0f;
    [SerializeField] private List<Transform> m_targets;
    private int m_currentIndex;

	private void Start () {
        if(m_targets.Count > 0)
        {
            m_currentIndex = 0;
            m_currentTarget = m_targets[m_currentIndex];
        }
	}
    private void LateUpdate()
    {
        if(m_currentTarget == null) { return; }

        float targetHeight = m_currentTarget.position.y + m_height;
        float currentRotationAngle = m_lookAtAroundAngle;

        Quaternion currentRotation = Quaternion.Euler(eğim, currentRotationAngle, 0);
        Vector3 position = m_currentTarget.position;
        position -= currentRotation * Vector3.forward * m_distance;
        position.y = targetHeight;

        transform.position = position;
        transform.LookAt(m_currentTarget.position + new Vector3(0, m_height, 0));
       
    }
}
