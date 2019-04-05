using UnityEngine;
using System.Collections;
//publishing settings
//capability system,checkinternet client/private sever, spatial perception
//quality = fastest
//vsync is on

//  public static Enum EnumMaskField(Rect position, Enum value)
      //  {
      //      return OrderToEnumMask(EditorGUI.EnumMaskField(position, EnumToOrderMask(value, false)));
    //    }

//deleting main cameras and directional light

//drag cursor from holograms and go to layers (set layer as spatial mapping for last layer)
//save proj go to scenes
//go to spacialmapping from holotoolkit of prefabs drop to heiarchy
//add open scenes on build settings, swwitch platform, sdk universal 10, uwp is D3D, local machine and check unity C# projects build, build new folder = mapping
//app --> visual studio --> release, x86, remote machine, IP address,
//debug start without debugging
//window profiler add profile --> GPU
//spatialmappingobserver.cs under scripts
//under private void awak type trainglespercubicmeter = 1200, start without debugging
//delete line, rebuild to save data
//open to windows device portal
//go to update button of spatial mapping --> open folder and save as spatialmapping and drop to assets folder of planetarium
//drop the saved data to object surface observer (script) under inspector for room model


//processing
//spatialprocessing to hierachy
//surfacemeshestoplanes.cs in visual --> make places public void -->
//playfinding.meshdata --> specify the planes --> space collection objects --> copy playspacemanager.cs code, paste new code -->
//https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-230 processing


//wall for drawplanes -->placeable.cs --> replace and save all --> save to app

//occlusion
//spatialprocessing of planetarium --> secondary of play space manager --> occulusion
//find object (earth), go to occlusion rim from shader of rim --> replace code for planetocclusion.cs-->

//uses Collider2DHelper class
//class can also be BoxCollider class since collider2DHelper is for 2D gameplay

//physics.boxcast below and colliderehelper
public class ColliderHelper : MonoBehaviour
{
      float m_MaxDistance;
      float m_Speed;
      bool m_HitDetect;
      bool isTrigger;

      Collider m_Collider;
      RaycastHit m_Hit;
    // Use this for initialization
    void Start () {

      //set speed, distance, and collider component
      m_MaxDistance = 100.0f;
      m_Speed = 30.0f;
      m_Collider = GetComponent<Collider>();


      public event EventHandler<Collider> TriggerEntered;

      public event EventHandler<Collider> TriggerExited;

      public event EventHandler<Collider> TriggerStayed;

      public event EventHandler<Collision> CollisionEntered;

      public event EventHandler<Collision> CollisionExited;

      public event EventHandler<Collision> CollisionStayed;

      //box-casting dimensions
      m_MaxDistance = 300.0f;
      m_Speed = 50.0f;
      m_Collider = GetComponent<Collider>();


      //Unity callback that are converted to events



    // Update is called once per frame
    void Update () {

      #region Unity Callbacks
      private void OnTriggerEnter(Collider triggerCollider)
      {
          TriggerEntered?.Invoke(gameObject, triggerCollider);
      }
      private void OnTriggerExit(Collider triggerCollider)
      {
          TriggerExited?.Invoke(gameObject, triggerCollider);
      }
      private void OnTriggerStay(Collider triggerCollider)
      {
          TriggerStayed?.Invoke(gameObject, triggerCollider);
      }
      private void OnCollisionEnter(Collision collision)
      {
          CollisionEntered?.Invoke(gameObject, collision);
      }
      private void OnCollisionExit(Collision collision)
      {
          CollisionExited?.Invoke(gameObject, collision);
      }
      private void OnCollisionStay(Collision collision)
      {
          CollisionStayed?.Invoke(gameObject, collision);
      }
      #endregion

      //drawmesh, must update each frame
      Graphics.DrawMesh(insertmesh, Vector3.zero, Quaternion.identity, Vector3.one);
    }


    //box-cast movement in x and z axis

        float xAxis = Input.GetAxis("Horizontal") * m_Speed;
        float zAxis = Input.GetAxis("Vertical") * m_Speed;
        transform.Translate(new Vector3(xAxis, 0, zAxis));


}


//meshcollider can be used too
//make class for mesh, filter, meshrender

void FixedUpdate()
   {
       //Test to see if there is a hit using a BoxCast
       //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
       //Also fetch the hit data
       m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
       if (m_HitDetect)
       {
           //Output the name of the Collider your Box hit
           Debug.Log("Hit : " + m_Hit.collider.name);
       }
   }


   //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
       void OnDrawGizmos()
       {
           Gizmos.color = Color.blue;

           //Check if there has been a hit yet
           if (m_HitDetect)
           {
               //Draw a Ray forward from GameObject toward the hit
               Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
               //Draw a cube that extends to where the hit exists
               Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
           }
           //If there hasn't been a hit yet, draw the ray at the maximum distance
           else
           {
               //Draw a Ray forward from GameObject toward the maximum distance
               Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
               //Draw a cube at the maximum distance
               Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
           }
       }
   }

//outputs messages
   void OnMouseDown()
  {
      //GameObject's Collider is now a trigger Collider when the GameObject is clicked. It now acts as a trigger
      m_ObjectCollider.isTrigger = true;
      //Output to console the GameObject’s trigger state
      Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
  }




public class ColliderEnabled : MonoBehaviour
  {
      Collider m_Collider;

      void Start()
      {
          //Fetch the GameObject's Collider (make sure it has a Collider component)
          m_Collider = GetComponent<Collider>();
      }

      void Update()
      {
          //spacebar to enable or disable (will start with disabled to prevent collision)
          if (Input.GetKeyDown(KeyCode.Space))
          {
              //Toggle the Collider on and off when pressing the space bar
              m_Collider.enabled = !m_Collider.enabled;

              //Output to console whether the Collider is on or not
              Debug.Log("Collider.disabled = " + !m_Collider.enabled);
          }
      }
  }

//to find the object
  public class FindObject : MonoBehaviour
{
  void Start()
  {
    meshobject = GameObject.Find("meshobject");
  }

  void Update()
{
  //can also just print out the object to notify user
  Debug.Log(gameObject.name);

}

}


//if object is clicked use to find name of object again part 2 (if clicked and triggerred instead)

public class Clickedobject : MonoBehaviour
{
    private GameObject[] cubes;

  //need void Awake for mesh

    void Update()
    {
        // Process a mouse button click.
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.BoxCast(ray, out hit))
            {
                // Visit each mesh and determine if it has been clicked.
                for (int i = 0; i < 3; i++)
                {
                  //if it hits mesh
                    if (hit.collider.gameObject == meshobject[i])
                    {
                        // mesh was clicked.
                        Debug.Log("Hit " + meshobject[i].name, cubes[i]);
                    }
                }
            }
        }
    }
}

//disabled collider to prevent collision among other colliders
using UnityEngine;

public class Example : MonoBehaviour
{
    Collider m_ObjectCollider;

    void Start()
    {

        //for messages on trigger
        //Fetch the GameObject's Collider (make sure they have a Collider component)
         m_Collider = GetComponent<Collider>();
         //Here the GameObject's Collider is not a trigger
         m_Collider.isTrigger = false;
         //Output whether the Collider is a trigger type Collider or not
         Debug.Log("Trigger On : " + m_Collider.isTrigger);

      }
    }


    void OnMouseDown()
    {
        //GameObject's Collider is now a trigger Collider when the GameObject is clicked. It now acts as a trigger
        m_ObjectCollider.isTrigger = true;
        //Output to console the GameObject’s trigger state
        Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
    }
}

//for boxcasting it is in the format of public static bool BoxCast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation = Quaternion.identity, float maxDistance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal);
//box cast max distance = Mathf.Infinity

private void Check()
   {
       m_PreviouslyGrounded = m_IsGrounded;

       if(Physics.BoxCast( new Vector3(transform.position.x , transform.position.y , transform.position.z ),
       //can replace with dimensions of box cast, box cast height = box height
                           new Vector3((m_Box.size.x * 0.9f), m_Box.size.y, (m_Box.size.z * 0.9f)) * 0.5f,
                           -Vector3.up,
                           out hitInfo,
                           m_Box.transform.rotation,
                           groundCheckDistance
                           ))
       {
           Debug.DrawRay(hitInfo.point, hitInfo.normal,Color.white,1.0f);
        }}
