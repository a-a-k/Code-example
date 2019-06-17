using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DTO
{
    public class ShouldSerializeContractResolver : BaseContractResolver
    {
        private readonly Type[] _models;

        public ShouldSerializeContractResolver(Type[] models)
        {
            _models = models;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (!_models.Contains(member.DeclaringType))
            {
                property.ShouldSerialize = p => true;
            }
            else
            {
                property.ShouldSerialize =
                    p =>
                        property
                            .AttributeProvider
                            .GetAttributes(typeof(ShortModelMemberAttribute), false)
                            .Any()
                        ||
                        property
                            .PropertyType
                            .GetProperties()
                            .Any(np => np.GetCustomAttributes(typeof(ShortModelMemberAttribute), false).Any())
                        ||
                        (property.PropertyType.IsGenericType
                         && property.PropertyType.GenericTypeArguments.Any(a => a.GetProperties().Any(gp => gp.GetCustomAttributes(typeof(ShortModelMemberAttribute)).Any())));
            }

            return property;
        }
    }
}