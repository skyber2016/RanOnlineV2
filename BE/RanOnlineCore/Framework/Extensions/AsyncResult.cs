using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extensions
{
    public static class AsyncResult
    {
        public static T WaitTask<T>(this Task<T> task)
        {
            if(task.Status == TaskStatus.WaitingForActivation)
                task.Wait();
            return task.Result;
        }
    }
}
