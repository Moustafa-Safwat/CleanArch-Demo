using System.Reflection;

namespace CleanArchDemo.Application.Mapping
{
    public static class ObjectMapper
    {
        public static TDest MapObjects<TSrc, TDest>(this TSrc source) where TSrc : class where TDest : class, new()
        {
            var destObject = new TDest();

            Type srcType = typeof(TSrc);
            Type destType = typeof(TDest);

            PropertyInfo[] srcProperties = srcType.GetProperties();
            PropertyInfo[] destProperties = destType.GetProperties();

            foreach (PropertyInfo srcProperty in srcProperties)
            {
                PropertyInfo destProperty = destProperties.FirstOrDefault(p => p.Name == srcProperty.Name && p.PropertyType == srcProperty.PropertyType)!;

                if (destProperty != null)
                {
                    object value = srcProperty.GetValue(source)!;
                    destProperty.SetValue(destObject, value);
                }
            }

            return destObject;
        }
    }
}
