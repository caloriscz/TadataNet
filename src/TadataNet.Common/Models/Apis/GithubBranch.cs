using System.Text.Json.Serialization;

namespace TadataNet.Common.Models.Apis;

public record GithubBranch(
    [property: JsonPropertyName("name")] string Name);