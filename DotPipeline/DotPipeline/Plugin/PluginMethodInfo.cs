using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotPipeline.Plugin
{
    internal class PluginMethodInfo
    {
        MethodInfo methodInfo;
        List<string> publishesFiles;

        public PluginMethodInfo(MethodInfo methodInfo)
        {
            this.methodInfo = methodInfo;
            publishesFiles = new List<string>();
            foreach (PluginPublishesAttribute pluginPublishes in methodInfo.GetCustomAttributes<PluginPublishesAttribute>())
            {
                publishesFiles.Add(pluginPublishes.FileName);
            }
        }

        public object Invoke(object obj, params object[] parameters)
        {
            return methodInfo.Invoke(obj, parameters);
        }

        public List<string> PublishesFiles { get => publishesFiles; set => publishesFiles = value; }

        internal bool CheckMethodParameterTypes(object[] args)
        {
            {
                int i = 0;
                ParameterInfo[] parameterInfos = methodInfo.GetParameters();

                if (parameterInfos.Length != args.Length)
                    return false;

                foreach (ParameterInfo parameterInfo in parameterInfos)
                {
                    if (parameterInfo.ParameterType != args[i].GetType())
                        return false;
                }

                return true;
            }
        }
    }
}