#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
using MessagePack;
using System.Diagnostics.CodeAnalysis;
using MPIgnore = MessagePack.IgnoreMemberAttribute;
using N_JsonIgnore = Newtonsoft.Json.JsonIgnoreAttribute;
using NotNullAttribute = System.Diagnostics.CodeAnalysis.NotNullAttribute;
using S_JsonIgnore = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace System.Application.Models
{
    /// <inheritdoc cref="IGAPAuthenticatorDTO"/>
    [MessagePackObject(keyAsPropertyName: true)]
    public sealed partial class GAPAuthenticatorDTO : IGAPAuthenticatorDTO, IExplicitHasValue
    {
        [MPIgnore, N_JsonIgnore, S_JsonIgnore]
        public ushort Id { get; set; }

        public int Index { get; set; }

        [NotNull, DisallowNull] // C# 8 not null
        public string? Name { get; set; }

        [MPIgnore, N_JsonIgnore, S_JsonIgnore]
        public GamePlatform Platform => Value.Platform;

        public Guid? ServerId { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset LastUpdate { get; set; }

        [NotNull, DisallowNull] // C# 8 not null
        public IGAPAuthenticatorValueDTO? Value { get; set; }

        bool IExplicitHasValue.ExplicitHasValue()
        {
            return !string.IsNullOrEmpty(Name) && Value != null;
        }
    }
}
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。