using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace LogApiReflection.Domain
{
    public enum Category
    {
        Romance = 1,
        Thriller = 2,
        Action = 3,
        Drama = 4,
        Horror = 5,
        Kids = 6
    }
}