using UnityEngine;
using UnityEngine.AI;

public class SequentialGolemActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] golems;
    [SerializeField] private Transform playerTarget;

    private int currentGolemIndex = 0;

    private void Start()
    {
        ActivateCurrentGolem();
    }

    public void OnGolemDestroyed(GameObject destroyedGolem)
    {
        if (destroyedGolem == golems[currentGolemIndex])
        {
            currentGolemIndex++;
            if (currentGolemIndex < golems.Length)
                ActivateCurrentGolem();
        }
    }

    private void ActivateCurrentGolem()
    {
        foreach (var golem in golems)
            golem.SetActive(false);

        golems[currentGolemIndex].SetActive(true);

        GolemController controller = golems[currentGolemIndex].GetComponent<GolemController>();
        controller.Initialize(playerTarget);
    }
}