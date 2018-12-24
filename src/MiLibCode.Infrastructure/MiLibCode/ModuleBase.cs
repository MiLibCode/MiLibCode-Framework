using ExtCore.Infrastructure;

namespace MiLibCode
{
    /// <summary>
    /// Implements the <see cref="IModule">IModule</see> interface and represents default extension behavior.
    /// </summary>
    public abstract class ModuleBase : ExtensionBase, IModule
    {
        public override string Authors => "Moses Ibiwoye";
    }
}
