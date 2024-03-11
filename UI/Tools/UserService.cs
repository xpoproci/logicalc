using Blazored.LocalStorage;
using Business.DTOs;
using Business.Facades;
using Data.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace UI.Tools
{
    public static class AuthorizationConstants
    {
        public static string AuthKey => "_45s6Ad4U231d654T2s3dH5s6d";

    }

    public class AuthorizationTools
    {
        private UserFacade _userFacade;
        private ILocalStorageService _storage;
        public AuthorizationTools(UserFacade userFacade, ILocalStorageService storageService)
        {
            _userFacade = userFacade;
            _storage = storageService;
        }


        public async Task<bool> RegisterUserAsync(UserLoginDto user)
        {
            try
            {
                if (!await _userFacade.UserExistsAsync(user.UserName))
                {
                    var userdto = await _userFacade.RegisterUserAsync(user);

                    await LoginAsync(userdto);

                    return true;
                }
            }
            catch (Exception)
            {
                //log error
            }

            return false;
        }

        public async Task<bool> LoginUserAsync(UserLoginDto user)
        {
            var userDto = await _userFacade.LoginUserAsync(user);
            if (userDto != null)
            {
                await LoginAsync(userDto);
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _storage.RemoveItemAsync(AuthorizationConstants.AuthKey);
        }

        public async Task<UserDto?> GetLoggedUser()
        {
            var str = await _storage.GetItemAsync<string>(AuthorizationConstants.AuthKey);
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            return (new UserDto()).FromEncryptedString(str);
        }

        private async Task LoginAsync(UserDto user)
        {
            await _storage.SetItemAsync<string>(AuthorizationConstants.AuthKey, user.ToEncryptedString());
        }
    }

    public class UserAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _service;

        public UserAuthenticationStateProvider(ILocalStorageService storageService)
        {
            _service = storageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var claimsIdentity = new ClaimsIdentity();
            var user = new UserDto();

            var str = await _service.GetItemAsync<string>(AuthorizationConstants.AuthKey);
            claimsIdentity = await CreateClaims(claimsIdentity, user, str);

            var logged = new ClaimsPrincipal(claimsIdentity);

            return await Task.FromResult(new AuthenticationState(logged));
        }

        private async Task<ClaimsIdentity> CreateClaims(ClaimsIdentity claimsIdentity, UserDto user, string str)
        {
            if (str != null)
            {
                user = user.FromEncryptedString(str);

                var claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                };
                claimsIdentity = new ClaimsIdentity(claims, "user-login");
            }

            return claimsIdentity;
        }
    }
}
