﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;
using WpaGhApp.Models;
using WpaGhApp.Services;

namespace WpaGhApp.ViewModels.Repository
{
    public class RepositoryCommitsViewModel : Screen, IRepositoryCommitsViewModelBindings, IViewModelWithRepositoryId
    {
        private readonly IResourceLoader _loader;
        private readonly IGitHubService _githubService;
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;

        public RepositoryCommitsViewModel(IResourceLoader loader, IGitHubService githubService,
            IMessageService messageService, INavigationService navigationService)
        {
            _loader = loader;
            _githubService = githubService;
            _messageService = messageService;
            _navigationService = navigationService;

            DisplayName = "commits";
        }

        public bool Working { get; set; }

        public IGitHubRepositoryIdentifiers RepositoryId { get; set; }

        public ObservableCollection<GhCommit> Commits { get; set; }
        protected async override void OnInitialize()
        {
            // Initialize only when not restoring (on refresh set Commits to null first)
            if (null == Commits)
            {
                await LoadCommitsAsync();
            }
        }

        async Task LoadCommitsAsync()
        {
            Working = true;
            var commits = await _githubService.GetCommitsAsync(RepositoryId);
            Working = false;

            if (null == commits)
            {
                await _messageService.ShowAsync("An error occured. " + _githubService.LastErrorMessage);
            }
            else
            {
                Commits = new ObservableCollection<GhCommit>(GhCommit.ToModel(commits));
            }
        }

        public void SelectCommit(ItemClickEventArgs eventArgs)
        {
            var ghCommit = eventArgs.ClickedItem as GhCommit;
            if (null == ghCommit) return;

            _navigationService.UriFor<HtmlUrlViewModel>()
                .WithParam(vm => vm.PageTitle, ghCommit.Message)
                .WithParam(vm => vm.HtmlUrl, ghCommit.HtmlUrl)
                .Navigate();
        }
    }
}
