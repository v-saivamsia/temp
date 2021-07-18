﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tambola.Services;

namespace Tambola.Pages
{
    public partial class Test
    {
        private bool isModalVisible = false;
        private bool showTickets = false;
        private bool isPlayersSelected = true;
        private bool isWinnersSelected = false;
        private PlayerTickets PlayerTickets;
        private Winners winners;
        [Inject]
        public NotificationService notificationService { get; set; }
        [Inject]
        public ILocalStorageService localStorage { get; set; }
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        public void statehaschanged() { StateHasChanged(); }
        private void btnClicked()
        {
            showTickets = true;
            Console.WriteLine("btn clicked");
        }
        private void closeButtonInChildClicked(bool isClosed)
        {
            if (isClosed)
            {
                showTickets = false;
                StateHasChanged();
            }
        }
        private void playersSelected()
        {
            isPlayersSelected = true;
            isWinnersSelected = false;
        }
        private void winnersSelected()
        {
            isWinnersSelected = true;
            isPlayersSelected = false;
        }
        private async Task clear()
        {
            await localStorage.ClearAsync();
            await notificationService.Update();
            closeModal();
        }
        private void showModal() { isModalVisible = true; }
        private void closeModal() { isModalVisible = false; }
        public void publicshowModal() { isModalVisible = true; }
    }
}
