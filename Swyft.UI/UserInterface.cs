﻿using Swyft.Core.Authentication;
using Swyft.Helpers;
using System;
using System.Globalization;
using System.Threading;
using static System.Console;

namespace Swyft.UI
{
    public class UserInterface
    {
        private readonly IAuthView _authView;
        private readonly IAccountView _accountView;

        public UserInterface(IAuthView authView, IAccountView accountView )
        {
            _authView = authView;
            _accountView = accountView;
        }
    
        /// <summary>
        /// Start the application
        /// </summary>
        public void Run()
        {
            // set console output encoding to accept unicode
            OutputEncoding = System.Text.Encoding.UTF8;

            // change current culture to english-Nigeria
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-NG", false);

            //Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "\u20A6"; // set currency symbol to naira (already works)

            // skip authentication and bank account creation stages
            //Faker.Initiate();

            while (true)
            {
                while (Auth.CurrentUser == null)
                {
                    Print.PrintLogo();
                    _authView.DisplayAuthMenu();
                }

                _accountView.DisplayDashboard();
            }
        }
    }
}
