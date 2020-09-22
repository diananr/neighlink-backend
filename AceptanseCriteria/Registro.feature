@automated
Feature: Registro

A short summary of the feature

@R1
Scenario: El usuario ingresa el codigo de su condominio
	Given  el usuario esta en la pantalla Registrate
	When el usuarioingrese el código de su condominio o edificio, la aplicación verificasi es válidoo no el código ingresado
	Then  si es válido, la aplicación redirige al usuarioal siguiente pasopara que éstecoloque sus credenciales;caso contrario le mostrará un mensajea dicho usuario diciendoque el código no es válido.
@R2
Scenario: El usuario ingresa su email y password
	Given  que el usuario está en el segundo paso de la sección “Regístrate”.
	When el usuario ingresa sus credenciales (email y password).
	Then  la aplicación validará que el email sea nuevo, es decir, que no exista un email igual ya registrado en la aplicación; si es así, se redirecciona a la vista principal, caso contrario se muestra un mensaje al usuario diciéndole que ya existe ese email.