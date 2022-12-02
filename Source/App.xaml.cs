using Autofac;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Source.Models;
using Source.Repositories.Abstract;
using Source.Repositories.Concretes;
using Source.Repositories.Contexts;
using Source.Stores;
using Source.VeiwModels;
using Source.Veiws;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Source;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
/// 
public partial class App : Application
{


    public static IContainer? Container { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {

        NavigationStore navigationStore = new();
        var builder = new ContainerBuilder();
        builder.RegisterType<MainVeiwModel>();

        builder.RegisterInstance(navigationStore)
            .SingleInstance();

        builder.RegisterType<FakeUserRepository>()
            .As<IUserRepository>()
            .SingleInstance();

        builder.RegisterType<SingInUserVeiwModel>();
        Container = builder.Build();
        navigationStore.CurrentViewModel = Container.Resolve<SingInUserVeiwModel>();
        MainVeiw mainView = new();
        mainView.DataContext = Container.Resolve<MainVeiwModel>();
        mainView.Show();
    }
}
