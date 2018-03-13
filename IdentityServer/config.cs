using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;


namespace IdentityServer
{
    public class Config
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                },
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:5001/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:28895/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:28895" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                },
                // resource owner password grant client
                 new Client
                    {
                        ClientId = "ro.client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "api1" }
                    }

            };
        }

        public static List<TestUser> GetUsers()
        {
                    return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }
    }
}
