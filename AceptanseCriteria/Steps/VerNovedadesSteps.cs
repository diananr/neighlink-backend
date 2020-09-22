using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteria.Steps
{
    [Binding]
    public class VerNovedadesSteps
    {
        [Given(@"que el residente está en la vista ""(.*)""\.")]
        public void GivenQueElResidenteEstaEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera visualizar las novedades de su condominio\.")]
        public void WhenQuieraVisualizarLasNovedadesDeSuCondominio_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrará una lista con las noticias ordenadas por fecha de publicación\.")]
        public void ThenSeMostraraUnaListaConLasNoticiasOrdenadasPorFechaDePublicacion_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
