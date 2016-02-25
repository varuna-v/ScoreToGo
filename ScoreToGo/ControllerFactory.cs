using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoreToGo
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                throw new ArgumentNullException("controllerType");

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format("Type requested is not a controller: {0}", controllerType.Name), "controllerType");

            return IoC.ResolveDependency(controllerType) as IController ;
        }

    }
}