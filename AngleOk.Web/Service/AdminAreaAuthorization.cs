using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace AngleOk.Web.Service
{
    public class AdminAreaAuthorization:IControllerModelConvention
    {
        private readonly string _area;
        private readonly string _policy;

        public AdminAreaAuthorization(string area, string policy)
        {
            _area = area;
            _policy=policy;
        }
        public void Apply(ControllerModel model)
        {
            if(model.Attributes.Any(a=>a is AreaAttribute && (a as AreaAttribute).RouteValue.Equals(_area, StringComparison.OrdinalIgnoreCase))
                ||model.RouteValues.Any(r=>r.Key.Equals("area", StringComparison.OrdinalIgnoreCase)))
            {
                model.Filters.Add(new AuthorizeFilter(_policy));
            }
        }
    }
}
