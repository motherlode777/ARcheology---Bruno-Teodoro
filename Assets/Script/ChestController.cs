using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    private Animator animator; 
    private bool isOpen = false;
    [SerializeField] GameObject objectInsideChest; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
        void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Key>(out Key key) && isOpen == false)
        {
            Debug.Log("Chave abriu!");
            isOpen = true;
            animator.SetTrigger("Open");

            var body = objectInsideChest.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.isKinematic = false;
            }
        }
    }

}
