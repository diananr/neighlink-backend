Feature: Ver Novedades

A short summary of the feature

@R5
Scenario: El residente ha visualizado las novedades acerca de su condominio en la aplicación.
	Given que el residente está en la vista "Inicio".
	When quiera visualizar las novedades de su condominio.
	Then se mostrará una lista con las noticias ordenadas por fecha de publicación.
