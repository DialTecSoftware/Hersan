using Hersan.Negocio.Demo;
using Hersan.Resolver;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hersan.Negocio.Resolver
{
    [Export(typeof(IComponent))]
    class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUsuariosBP, IUsuariosBP>();
        }
    }
}
