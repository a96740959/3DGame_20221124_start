using System.Collections;
using UnityEngine;

namespace Alex
{
    public class DisableObject : MonoBehaviour
    {
        public GameObject Obj;
        public float activeTime;
        public bool triggerbased;

        void FixedUpdate()
        {
            if (triggerbased == false)
            {
                if (Obj.active == true)
                {
                    StartCoroutine(Disableobj());
                }
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Obj.SetActive(false);
                this.GetComponent<BoxCollider>().enabled = false;
            }
        }
        IEnumerator Disableobj()
        {
            yield return new WaitForSeconds(activeTime);
            Obj.SetActive(false);
        }
    }

}
