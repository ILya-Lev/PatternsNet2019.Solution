using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("StructuralDemos")]

namespace Structural.Composite
{
    internal interface IViewObject
    {
        /// <summary> shows the object to outer world </summary>
        string Draw();

        /// <summary> allows to add child object.
        /// do we really need it here?
        /// yeah, it's a compromise </summary>
        void Add(IViewObject obj);
    }

    /// <summary> leaf of the tree </summary>
    internal class LightView : IViewObject
    {
        private readonly string _message;

        public LightView(string message) => _message = message;

        public string Draw() => _message;

        public void Add(IViewObject obj)
        {
            //another approach - throw exception to notify client,
            //however, test it ! as anything runtime specific 
        }
    }

    /// <summary> either tree root or sub-root </summary>
    internal class GroupView : IViewObject
    {
        private readonly string _message;
        private readonly Func<IViewObject, bool> _viewFilter;
        private readonly HashSet<IViewObject> _branches = new HashSet<IViewObject>();

        public GroupView(string message, Func<IViewObject, bool> viewFilter)
        {
            _message = message;
            _viewFilter = viewFilter;
        }

        public string Draw()
        {
            var sb = new StringBuilder();

            sb.AppendLine(_message);
            foreach (var item in _branches.Where(_viewFilter))
            {
                var childMessage = item.Draw();
                sb.AppendLine(childMessage);
            }

            return sb.ToString();
        }

        public void Add(IViewObject obj)
        {
            if (obj is null || ReferenceEquals(this, obj) || _branches.Contains(obj))
                return;

            _branches.Add(obj);
        }
    }
}