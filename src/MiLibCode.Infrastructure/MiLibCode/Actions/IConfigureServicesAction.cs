namespace MiLibCode.Actions
{
    /// <summary>
    /// Describes an action that must be executed inside the ConfigureServices method of a web application's Startup class
    /// and might be used by the extensions to register any service inside the DI.
    /// </summary>
    public interface IConfigureServicesAction : ExtCore.Infrastructure.Actions.IConfigureServicesAction
    {
    }
}
