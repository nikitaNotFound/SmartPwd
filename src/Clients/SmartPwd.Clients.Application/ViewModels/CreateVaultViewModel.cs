using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartPwd.Clients.Application.ViewModels;

public partial class CreateVaultViewModel : ObservableObject
{
    [ObservableProperty]
    private string _vaultName;

    [ObservableProperty]
    private List<string> _accessWords;

    [ObservableProperty]
    private string _masterPwd;
}