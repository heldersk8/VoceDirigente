using System.Web.Mvc;

namespace RecrutaZero.WebApp.Helpers.ModelBinders
{
    public class StringModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var modelState = new ModelState { Value = valueResult };

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);

            return valueResult == null ? null : valueResult.AttemptedValue.ToUpper().Trim();
        }
    }
}