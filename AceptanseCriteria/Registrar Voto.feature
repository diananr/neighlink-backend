Feature: Registrar Voto

A short summary of the feature

@R3
Scenario: El residente ha registrado su voto para una encuesta determinada.
	Given que el residente se encuentra en la vista "Encuestas".
	When quiera registrar mi voto.
	Then al seleccionar una opción, la aplicación considerará como voto y lo registrará.
@R4
Scenario: El residente ha visualizado si su voto ha sido registrado en la aplicación.
	Given que el residente se encuentra en la vista "Encuestas".
	When quiera ver que su voto se registró con éxito.
	Then se mostrará la opción sombreada.
