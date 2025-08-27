using System;
using System.Collections;
using System.Threading.Tasks;

namespace Survivors
{
    public static class TaskExtensions
    {
        public static IEnumerator AsCoroutine(this Task task, Action complete = null)
        {
            while (!task.IsCompleted || !task.IsCanceled || !task.IsFaulted)
            {
                yield return null;
            }

            complete?.Invoke();
        }
        
        public static IEnumerator AsCoroutine<T>(this Task<T> task, Action<T> complete = null)
        {
            while (!task.IsCompleted || !task.IsCanceled || !task.IsFaulted)
            {
                yield return null;
            }

            complete?.Invoke(task.Result);
        }
    }
}