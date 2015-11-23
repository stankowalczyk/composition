using System;

namespace Composition.Views
{
    /// <summary>
    /// Abstract View Class
    /// Used as the parent class for all other UI elements
    /// </summary>
    public abstract class View
    {
        public WidgetType WidgetType { get; set; }

        public abstract string CreateActivityLayoutXML(int indentationLevel);

        public abstract string CreateStyleXML(int indentationLevel);

        public abstract string CreateLayoutFileXML();
    }
}
