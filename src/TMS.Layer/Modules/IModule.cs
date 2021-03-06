﻿namespace TMS.Layer.Modules
{
    /// <summary>
    /// To register all the internal types.
    /// </summary>
    public interface IModule
    {
        void Initialize(IModuleRegistrar registrar);
    }
}
