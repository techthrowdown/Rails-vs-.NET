using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace ProductDevelopment.Web.Infrastructure
{
    public class InjectableFilterProvider : FilterAttributeFilterProvider
    {
        private readonly IKernel _kernel;

        public InjectableFilterProvider(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            foreach (var filter in filters)
            {
                _kernel.Inject(filter.Instance);
            }
            return filters;
        }
    }
}