using Application.Users.DTO.Role;
using Azure;
using deathmatch_micro.Application.Users.Commands;
using deathmatch_micro.Domain.Entities;
using Infrastructure.Common.Exceptions;
using Newtonsoft.Json;

namespace IntegrationTests;

public class UserControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    public UserControllerIntegrationTest(TestingWebAppFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task Users_GetAll_Success()
    {
        var response = await _client.GetAsync("/Users");
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("Mark", responseString);
        Assert.Contains("Evelin", responseString);
    }

    public static IEnumerable<object[]> UserCorrectEntities
    {
        get
        {
            return new[]
            {
                new object[] { new CreateUserCommand { Email = "totalit2803@gmail.com", Name = "totalit", Password = "123", RoleName = "User" } },
            };
        }
    }

    public static IEnumerable<object[]> UserEntitiesIncorrectRole
    {
        get
        {
            return new[]
            {
                new object[] { new CreateUserCommand { Email = "totalit2803@gmail.com", Name = "totalit", Password = "123", RoleName = "NotUser" } },
                new object[] { new CreateUserCommand { Email = "totalit2803@gmail.com", Name = "totalit", Password = "123", RoleName = "ff" } },
            };
        }
    }

    [Theory, MemberData(nameof(UserCorrectEntities))]
    public async Task CreateUser_Success(CreateUserCommand cmd)
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/User/CreateUser");

        var cmdDictionary = ToDictionary<string>(cmd);

        postRequest.Content = new FormUrlEncodedContent(cmdDictionary);

        var response = await _client.SendAsync(postRequest);

        response.EnsureSuccessStatusCode();
    }

    [Theory, MemberData(nameof(UserEntitiesIncorrectRole))]
    public async Task CreateUser_IncorrectRole(CreateUserCommand cmd)
    {
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/User/CreateUser");

        var cmdDictionary = ToDictionary<string>(cmd);

        postRequest.Content = new FormUrlEncodedContent(cmdDictionary);

        var response = await _client.SendAsync(postRequest);

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("ItemNotFoundException", responseString);      
    }

    private static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
        return dictionary;
    }
}
