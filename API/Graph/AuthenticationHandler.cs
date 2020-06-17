﻿using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using OneDrive_Cloud_Player.API.Authentication.InteractiveComponents;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OneDrive_Cloud_Player.API
{
    class AuthenticationHandler
    {

        public AuthenticationHandler() { }

        /// <summary>
        /// Tries to  silently retrieve the acces token without user interaction. If that fails it tries to retrieve the access token with an interactive login window.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccessToken()
        {
            AuthenticationResult LocalResult = null;
            try
            {
                var accounts = await App.Current.PublicClientApplication.GetAccountsAsync();
                LocalResult = await App.Current.PublicClientApplication.AcquireTokenSilent(App.Current.Scopes, accounts.FirstOrDefault())
                       .ExecuteAsync();

                if (LocalResult != null)
                {
                    Console.WriteLine(" + Silent Acquire successfull.");
                }
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilent.
                // This indicates you need to call AcquireTokenInteractive to acquire a token
                Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");
                try
                {
                    Console.WriteLine(" + Cannot do silent acquire. Trying interactive instead.");
                    LocalResult = await App.Current
                    .PublicClientApplication
                    .AcquireTokenInteractive(App.Current.Scopes)
                    .WithCustomWebUi(new EmbeddedBrowser(App.Current.MainWindow))
                    .ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                    Debug.WriteLine($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
                    Debug.WriteLine("\nLocalResult is NULL.\n");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
                Debug.WriteLine("\nLocalResult is NULL.\n");
                return null;
            }

            if (LocalResult != null)
            {
                // Return the newly Acquired access token
                return LocalResult.AccessToken;
            }

            //Return null when the method failed to acquire a token.
            Debug.WriteLine("\nLocalResult is NULL.\n");
            return null;
        }

        /// <summary>
        /// Tries to acquire the acces token by forcing to use an interactive window.
        /// </summary>
        public async Task GetAccessTokenForcedInteractive()
        {
            AuthenticationResult LocalResult;
            try
            {
                LocalResult = await App.Current
                .PublicClientApplication
                .AcquireTokenInteractive(App.Current.Scopes)
                .WithCustomWebUi(new EmbeddedBrowser(App.Current.MainWindow))
                .ExecuteAsync();
                if (LocalResult != null)
                {
                    Console.WriteLine("Logged in using interaction.");
                }
            }
            catch (MsalException msalex)
            {
                Console.WriteLine($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
                Debug.WriteLine("\nLocalResult is NULL.\n");
            }
        }

        /// <summary>
        /// Signs out a user. It removes the account from the token cache.
        /// </summary>
        public async void SignOut()
        {
            var accounts = await App.Current.PublicClientApplication.GetAccountsAsync();
            accounts = (System.Collections.Generic.IEnumerable<IAccount>)accounts.ElementAt(0);

            //Checks if any account is inside the token cache.
            if (accounts.Any())
            {
                try
                {
                    await App.Current.PublicClientApplication.RemoveAsync(accounts.FirstOrDefault());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error while trying to sign out: " + e);
                }
            }
        }
    }
}
