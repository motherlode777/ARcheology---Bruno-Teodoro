using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetController : MonoBehaviour
{
    [SerializeField] private List<SpotController> spots;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            TryToPutOnCabinet(collision.gameObject);
        }
    }

    private void TryToPutOnCabinet(GameObject obj)
    {
        if (GetClosestAvailableSpot(obj.transform.position) is SpotController availableSpot)
        {
            obj.transform.SetParent(availableSpot.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = true; 
            }
        }
    }

    private SpotController GetClosestAvailableSpot(Vector3 referencePosition)
    {
        SpotController closestSpot = null;
        float minDistance = float.MaxValue;

        foreach (SpotController spot in spots)
        {
            if (!spot.IsOccupied())
            {
                float distance = Vector3.Distance(referencePosition, spot.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestSpot = spot;
                }
            }
        }

        return closestSpot; 
    }
}