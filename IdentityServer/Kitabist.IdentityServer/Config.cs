
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Kitabist.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
       {
           new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"} },
           new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
           new ApiResource("ResourceOrder"){Scopes={"OrderFullPermisson"}},
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
       };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile(),
          new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="KitabistVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("kitabistsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission","CatalogFullPermission"},
                AllowAccessTokensViaBrowser=true
            },

            //Manager
            new Client
            {
                ClientId="KitabistManagerId",
                ClientName="Kitabist Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("kitabistsecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission"}
            },

            //Admin
            new Client
            {
                ClientId="KitabistAdminId",
                ClientName="Kitabist Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("kitabistsecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermisson",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
            }
        };
    }
}