using UnityEngine;
using Vastav.Player.EventsData;
using Vastav.Player.Switch;


namespace Vastav.Player
{
    public class GrabPutManager : MonoBehaviour
    {

        [SerializeField] private LayerMask switchMask;
        [SerializeField] private LayerMask holderMask;
        [SerializeField] private float radius = 1;

        [Space, Header("Switch")]
        [SerializeField] private Transform holdPoint;

        private SwitchManager curruntSwitch;
        private HolderManager curruntHolder;


        private void OnEnable()
        {
            Player_EventManager.OnInteractSwitch += ManagePutGrab;
        }

        private void OnDisable()
        {
            Player_EventManager.OnInteractSwitch -= ManagePutGrab;
        }

        private void ManagePutGrab()
        {
            if (curruntSwitch != null)
            {
                PutSwitch();
            }
            else
            {
                GetSwitch();
            }
        }

        private void PutSwitch()
        {
            AudioManager.Instance.PlayEffect(SoundType.Pop);

            if (GetHolder())
            {
                return;
            }
            curruntSwitch.transform.parent = null;
            Rigidbody2D rb = curruntSwitch.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            rb.gravityScale = 1;
            curruntSwitch.transform.position = transform.position + Vector3.up + transform.right;
            curruntSwitch = null;
        }

        private void GetSwitch()
        {
            Collider2D switchData = CanGetNearestSwitch();

            if (switchData != null)
            {
                AudioManager.Instance.PlayEffect(SoundType.Pop);
                curruntSwitch = switchData.GetComponent<SwitchManager>();

                Rigidbody2D rb = curruntSwitch.GetComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;

                curruntSwitch.transform.position = holdPoint.position;

                curruntSwitch.transform.parent = transform;
            }
        }

        private bool GetHolder()
        {
            Collider2D holder = CanGetNearestHolder();
            if (holder != null)
            {
                curruntHolder = holder.GetComponent<HolderManager>();
                Rigidbody2D rb = curruntSwitch.GetComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;

                curruntSwitch.transform.position = curruntHolder.switchHolder.position;

                curruntSwitch.transform.parent = curruntHolder.transform;
                curruntHolder.curruntState = Enums.SwitchState.filled;

                curruntSwitch = null;


                return true;
            }
            return false;
        }


        private Collider2D CanGetNearestHolder()
        {
            Collider2D canDo = Physics2D.OverlapCircle(transform.position, radius, holderMask);
            return canDo;
        }


        private Collider2D CanGetNearestSwitch()
        {
            Collider2D canDo = Physics2D.OverlapCircle(transform.position, radius, switchMask);
            return canDo;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}


