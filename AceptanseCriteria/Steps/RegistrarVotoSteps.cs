using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteria.Steps
{
    [Binding]
    public class RegistrarVotoSteps
    {
        [Given(@"que el residente se encuentra en la vista ""(.*)""\.")]
        public void GivenQueElResidenteSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera registrar mi voto\.")]
        public void WhenQuieraRegistrarMiVoto_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera ver que su voto se registró con éxito\.")]
        public void WhenQuieraVerQueSuVotoSeRegistroConExito_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"al seleccionar una opción, la aplicación considerará como voto y lo registrará\.")]
        public void ThenAlSeleccionarUnaOpcionLaAplicacionConsideraraComoVotoYLoRegistrara_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrará la opción sombreada\.")]
        public void ThenSeMostraraLaOpcionSombreada_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
