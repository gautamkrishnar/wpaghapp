﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpaGhApp.Models;
using WpaGhApp.ViewModels.Repository;

namespace WpaGhApp.DesignViewModels
{
    public class RepositoryInfoViewModelDT : IRepositoryInfoViewModelBindings
    {
        public RepositoryInfoViewModelDT()
        {
            Repository = new GhRepository()
            {
                ForksCount = 0,
                OpenIssuesCount = 155,
                StargazersCount = 2,
            };
        }

        public GhRepository Repository { get; set; }
    }
}
