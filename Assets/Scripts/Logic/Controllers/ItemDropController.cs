using System.Collections;
using UnityEngine;

public class ItemDropController : MonoBehaviour
{
    [SerializeField] private float _rangeDrop;
    [SerializeField] private float _timeForStopKinematic;

    public void DropItems(Item item, int minCountDrops, int maxCountDrops)
    {
        float timeForStopKinematic = 1;

        int minimumPositionValueEachAxis = 0;
        
        for (int i = 0; i < Random.Range(minCountDrops, maxCountDrops + _timeForStopKinematic); i++)
        {
            Item itemObj = Instantiate(item, transform.position, transform.rotation);
            Vector3 randomPosition = new Vector3(
                Random.Range(minimumPositionValueEachAxis, _rangeDrop),
                Random.Range(minimumPositionValueEachAxis, _rangeDrop),
                Random.Range(minimumPositionValueEachAxis, _rangeDrop)
            );
            
            StartCoroutine(ChangeKinematic(itemObj.Rigidbody, randomPosition));
        }
    }

    private IEnumerator ChangeKinematic(Rigidbody itemRb, Vector3 randomPosition)
    {
        itemRb.AddForce(randomPosition, ForceMode.Impulse);
        yield return new WaitForSeconds(_timeForStopKinematic);

        itemRb.isKinematic = true;
    }
}
