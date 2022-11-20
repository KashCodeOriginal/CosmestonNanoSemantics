using Zenject;
using KasherOriginal.Services.Input;
using KasherOriginal.AssetsAddressable;
using KasherOriginal.Factories.UIFactory;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindUIFactory();
        BindInputService();
        BindAssetsAddressable();
        BindEnvironmentFactory();
    }

    private void BindAssetsAddressable()
    {
        Container.BindInterfacesTo<AssetsAddressableService>().AsSingle();
    }
    
    private void BindInputService()
    {
        Container.Bind<StandaloneInputService>().AsSingle();
    }

    private void BindUIFactory()
    {
        Container.BindInterfacesTo<UIFactory>().AsSingle();
    }
    
    private void BindEnvironmentFactory()
    {
        Container.BindInterfacesTo<EnvironmentFactory>().AsSingle();
    }
}
