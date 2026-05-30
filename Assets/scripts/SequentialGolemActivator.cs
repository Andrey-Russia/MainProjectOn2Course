using UnityEngine;
using UnityEngine.AI;

public class SequentialGolemActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] golems;
    [SerializeField] private Transform playerTarget;

    private int currentGolemIndex = 0;

    private void Start()
    {
        if (golems.Length > 0)
            ActivateCurrentGolem();
        else
            Debug.LogError("No golems assigned!");
    }

    public void OnGolemDestroyed(GameObject destroyedGolem)
    {
        if (IsValidGolem(destroyedGolem))
            AdvanceToNextGolem();
        else
            Debug.LogWarning($"Invalid golem destroyed: {destroyedGolem.name}. Current index: {currentGolemIndex}");
    }

    private bool IsValidGolem(GameObject destroyedGolem)
    {
        if (currentGolemIndex >= golems.Length || currentGolemIndex < 0)
        {
            Debug.LogError("Golem index out of range!");
            return false;
        }

        if (destroyedGolem == null)
        {
            Debug.LogError("Null golem reference!");
            return false;
        }

        if (destroyedGolem != golems[currentGolemIndex])
        {
            Debug.LogWarning($"Wrong golem destroyed: Expected {golems[currentGolemIndex].name}, but got {destroyedGolem.name}");
            return false;
        }

        return true;
    }

    private void AdvanceToNextGolem()
    {
        currentGolemIndex++;

        if (currentGolemIndex < golems.Length)
            ActivateCurrentGolem();
        else
            Debug.Log("All golems defeated!");
    }

    private void ActivateCurrentGolem()
    {
        foreach (var golem in golems)
        {
            if (golem != null)
                golem.SetActive(false);
            else
                Debug.LogWarning("Null golem detected!");
        }

        if (currentGolemIndex < golems.Length)
        {
            if (golems[currentGolemIndex] != null)
            {
                golems[currentGolemIndex].SetActive(true);

                GolemController controller = golems[currentGolemIndex].GetComponent<GolemController>();
                if (controller != null)
                    controller.Initialize(playerTarget);
                else
                    Debug.LogWarning("Missing GolemController component!");
            }
            else
                Debug.LogError("Null golem at index!");
        }
    }
}