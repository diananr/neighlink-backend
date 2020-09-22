Feature: Registro Pagos

A short summary of the feature

@tag1
Scenario: El residente ha registrado un nuevo pago sobre sus arbitrios.
	Given que el residente se encuentra en la vista "Mis pagos".
	When quiera registrar un nuevo pago.
	Then le aparecerá un formulario con los campos: categoría, fecha de pago, monto e imagen.
