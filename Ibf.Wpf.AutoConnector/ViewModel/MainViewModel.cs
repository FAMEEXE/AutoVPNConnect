using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using System.Windows.Input;
using Ibf.Wpf.AutoConnector.Service;

namespace Ibf.Wpf.AutoConnector.ViewModel;

public class MainViewModel : BindableBase
{
    private readonly IRegistrySettingService registrySettingService;

    private string userName;
    private string password;

    public MainViewModel(IRegistrySettingService registrySettingService)
    {
        this.registrySettingService = registrySettingService;

        SaveCommand = new BaseCommand(SaveAsync);

        UserName = registrySettingService.CurrentSettings.UserName;
        Password = registrySettingService.CurrentSettings.Password;
    }

    public BaseCommand SaveCommand { get; }

    public string UserName
    {
        get => userName;
        set => SetField(ref userName, value);
    }

    public string Password
    {
        get => password;
        set => SetField(ref password, value);
    }

    private async Task SaveAsync()
    {
        registrySettingService.CurrentSettings.UserName = UserName;
        registrySettingService.CurrentSettings.Password = password;

        await registrySettingService.Save();
    }
}