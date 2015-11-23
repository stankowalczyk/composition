using System;

namespace CompositionTests.Views
{
    public abstract class View
    {
        public WidgetType WidgetType { get; set; }

        public abstract string CreateActivityLayoutXML(int indentationLevel);

        public abstract string CreateStyleXML(int indentationLevel);

        public abstract string CreateLayoutFileXML();
    }
}
