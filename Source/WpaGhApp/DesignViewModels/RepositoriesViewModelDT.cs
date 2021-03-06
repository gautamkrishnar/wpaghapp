﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpaGhApp.Models;
using WpaGhApp.ViewModels.Main;

namespace WpaGhApp.DesignViewModels
{
    public class RepositoriesViewModelDT : IRepositoriesViewModelBindings
    {
        public RepositoriesViewModelDT()
        {
            Repositories = new ObservableCollection<GhRepository>(new List<GhRepository>
            {
                new GhRepository()
                {
                    Name = "wpaghapp",
                    Description = "Windows Phone Application for GitHub"
                },
                new GhRepository()
                {
                    Name = "viennarealtime",
                    Description = "City of Vienna public transport departure information"
                },
            });
        }

        public bool Working { get; set; }
        public ObservableCollection<GhRepository> Repositories { get; private set; }
    }
}
