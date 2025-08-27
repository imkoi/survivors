using System.Collections;
using System.Linq;
using UnityEngine;

namespace Survivors.Core.Loading
{
    public abstract class LoadingStep : MonoBehaviour
    {
        [SerializeField] private LoadingStep[] _sequentialLoadingSteps;
        [SerializeField] private LoadingStep[] _nextParallelSteps;
        
        public abstract IEnumerator Execute();

        public IEnumerator Schedule()
        {
            yield return StartCoroutine(Execute());
            
            StartCoroutine(WaitParallel());
            StartCoroutine(WaitSequentially());
        }

        private IEnumerator WaitParallel()
        {
            var parallelSteps = _nextParallelSteps.Select(step => step.Schedule()).ToList();
            
            while (parallelSteps.Any(c => c.MoveNext()))
            {
                yield return null;
            }
        }

        private IEnumerator WaitSequentially()
        {
            foreach (var loadingStep in _sequentialLoadingSteps)
            {
                yield return StartCoroutine(loadingStep.Schedule());
            }
        }
    }
}