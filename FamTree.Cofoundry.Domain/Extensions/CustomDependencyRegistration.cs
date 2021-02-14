using Cofoundry.Core.DependencyInjection;
using Cofoundry.Domain.Data;

namespace FamTree.Cofoundry.Domain.Extensions
{
    public class CustomDependencyRegistration: IDependencyRegistration
    {
        public void Register(IContainerRegister container)
        {
            if (!container.Configuration.GetValue<bool>("Cofoundry:Azure:Disabled"))
            {
                var overrideOptions = RegistrationOptions.Override();

                container
                    .Register<IFileStoreService, AzureBlobFileService>(overrideOptions);
            } 
        }
    }
}