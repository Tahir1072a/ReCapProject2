using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Burda car validator ın bir öreneğini oluşturuyoruz yani reflection yapıyoruz. Uygulama çalışırken newliyoruz
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // Car Validatorın base typenı bul. Yani sen ne ile çalıştığını söyle bana diyor
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //  ve burdada invocationun(kullanılan metodun(mesela: add)) argumentslerinden yani parametrelerine bak, where ile neye göre
            // bakacağını söylüyoruz. Where(bu parametrelerin tipini al ve bizim kullandığımız tip ile aynı tipte olan parametreyi entitiese at)
            // demiş oluyoruz. Neden where kullanıyoruz çünkü farklı türlerde parametreler girilmiş olabilir.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                // Validation toolu kullanarak doğrula diyoruz en sonda..
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
