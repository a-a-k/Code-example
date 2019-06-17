using System;

namespace DTO.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ShortModelMemberAttribute : Attribute
    {
        public ShortModelMemberAttribute()
        {
        }
    }
}