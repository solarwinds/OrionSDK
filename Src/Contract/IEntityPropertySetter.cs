namespace SolarWinds.InformationService.Contract2
{

    /// <summary>
    /// This interface has a definition of method Add used by SWIS response parser
    /// </summary>
    public interface IEntityPropertySetter
    {
        /// <summary>
        /// Adds property name and value to collection of object properties
        /// </summary>
        /// <param name="name">property name</param>
        /// <param name="value">property value</param>
        void SetPropertyValue(string name, object value);
    }
}
