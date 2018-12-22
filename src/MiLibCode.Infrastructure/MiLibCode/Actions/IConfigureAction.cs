namespace MiLibCode.Actions
{
    /// <summary>
    /// Describes an action that must be executed inside the Configure method of a web application's Startup class
    /// and might be used by the extensions to configure a web application's request pipeline.
    /// </summary>
    public interface IConfigureAction : ExtCore.Infrastructure.Actions.IConfigureAction
    {
    }
}
