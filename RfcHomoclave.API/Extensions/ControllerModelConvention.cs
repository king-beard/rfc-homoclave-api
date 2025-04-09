using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace RfcHomoclave.API.Extensions
{
    public class ControllerModelConvention : IControllerModelConvention
    {
         public void Apply(ControllerModel controller)
        {
            #region Custom controller name

            if (controller == null)
                return;

            foreach (var attr in controller.Attributes)
            {
                if (attr.GetType() == typeof(RouteAttribute))
                {
                    var routeAttr = (RouteAttribute)attr;
                    if (!string.IsNullOrEmpty(routeAttr.Name))
                        controller.ControllerName = routeAttr.Name;
                }
            }

            #endregion

            #region versionamiento de api

            var namespaceController = controller.ControllerType.Namespace;
            var apiVersion = namespaceController.Split(".").Last().ToLower();
            controller.ApiExplorer.GroupName = apiVersion;
            #endregion
        }
    }
}
