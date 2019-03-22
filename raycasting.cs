using UnityEngine;
using System.Collections;


public class Collider2DHelper : MonoBehaviour
{
      float m_MaxDistance;
      float m_Speed;
      bool m_HitDetect;

      Collider m_Collider;
      RaycastHit m_Hit;
    // Use this for initialization
    void Start () {

      m_MaxDistance = 100.0f;
      m_Speed = 30.0f;
      m_Collider = GetComponent<Collider>();


      public event EventHandler<Collider2D> TriggerEntered2D;

      public event EventHandler<Collider2D> TriggerExited2D;

      public event EventHandler<Collider2D> TriggerStayed2D;

      public event EventHandler<Collision2D> CollisionEntered2D;

      public event EventHandler<Collision2D> CollisionExited2D;

      public event EventHandler<Collision2D> CollisionStayed2D;
      //Unity callback that are converted to events

    }

    // Update is called once per frame
    void Update () {

      #region Unity Callbacks
      private void OnTriggerEnter2D(Collider2D triggerCollider2D)
      {
          TriggerEntered2D?.Invoke(gameObject, triggerCollider2D);
      }
      private void OnTriggerExit2D(Collider2D triggerCollider2D)
      {
          TriggerExited2D?.Invoke(gameObject, triggerCollider2D);
      }
      private void OnTriggerStay2D(Collider2D triggerCollider2D)
      {
          TriggerStayed2D?.Invoke(gameObject, triggerCollider2D);
      }
      private void OnCollisionEnter2D(Collision2D collision2D)
      {
          CollisionEntered2D?.Invoke(gameObject, collision2D);
      }
      private void OnCollisionExit2D(Collision2D collision2D)
      {
          CollisionExited2D?.Invoke(gameObject, collision2D);
      }
      private void OnCollisionStay2D(Collision2D collision2D)
      {
          CollisionStayed2D?.Invoke(gameObject, collision2D);
      }
      #endregion


    }
}
