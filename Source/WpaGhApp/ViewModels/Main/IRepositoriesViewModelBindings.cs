﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace WpaGhApp.ViewModels.Main
{
    public interface IRepositoriesViewModelBindings
    {
        ObservableCollection<Repository> Repositories { get; }
    }
}