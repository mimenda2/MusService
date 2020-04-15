using MusClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusCommon
{
    public static class ExecuteMethod
    {
        public static void ExecuteMethodNTimes(Func<bool> _func, int times)
        {
            for (int i = 0; i < times; i++)
            {
                try
                {
                    _func.DynamicInvoke();
                    break;
                }
                catch (Exception ex)
                {
                    TraceClientExtensions.TraceMessage(System.Diagnostics.TraceEventType.Error, 1, 
                        $"Error al ejecutar {_func.Method.Name}: {ex.ToString()}");
                }
            }
        }
             
    }
}
