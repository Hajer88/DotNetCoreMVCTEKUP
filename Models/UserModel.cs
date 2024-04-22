	using System;
	using System.ComponentModel.DataAnnotations;

	namespace Project.FirstMVC._2024.Models
	{
		public class UserModel : IValidatableObject
		{
			public UserModel()
			{
			}

		 public Guid Id { get; set; }

		//L'objectif est de fournir an email ou phone
		//C'est difficile de faire ça avec les annotations
		//On implémente IValidatableObject
		[EmailAddress]
			public string Email { get; set; }
			[Phone]
			public string PhoneNumber { get; set; }

		//Retourner une énumération de validationResult pour décrire
		//le problème--> complex business rule
			public IEnumerable<ValidationResult>
				Validate(ValidationContext valicontext)
			{
			//Vérifier si l'objet est valide
				if(string.IsNullOrEmpty(Email) && string
					.IsNullOrEmpty(PhoneNumber))
					{
					yield return new ValidationResult("You must " +
						"provide an Email or phone",
						new[]
						{nameof(Email), nameof(PhoneNumber)}
						);
				}
		
			}
				}
	}

