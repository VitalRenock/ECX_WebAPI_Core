using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ECX_WebAPI_ClientClayer.Models;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ECX_WebAPI_Core.tools
{
	public class TokenManager : ITokenManager
	{
		// Clé pour décrypter le token quand on en a besoin
		public static string secret = "Les pokemons sont sur Saturne pendant que le volcan est en eruption";
		public static string issuer = "mysite.com";
		public static string audience = "mysite.com";

		// Un token peut contenir des informations sur l'utilisateur, des Validités (timing), sur comment validés le token, la clé crypté également...
		public UserClient GenerateToken(UserClient user)
		{
			if (user.Email is null)
				throw new ArgumentNullException();

			// On encode la clé secrète en tableau de byte UTF8
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
			// Ensuite on crypte la clé secrète
			SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			// Les 'Claim' sont des informations que l'on va intégrer au token
			// Attention: Les Claim ne peuvent être que des string.
			Claim[] claims = new[]
			{
				// Exemple de Claim personnalisé
				new Claim("UserId", user.Id.ToString()),
				// Exemples de Claim prédéfinis, (un peu plus sécure)
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, user.Role),
			};

			// Création et configuration du token
			JwtSecurityToken token = new JwtSecurityToken(
				// Ajout de nos claims
				claims: claims,
				// Ajout d'une date d'expiration du token
				expires: DateTime.Now.AddDays(1),
				// Ajout de notre credential
				signingCredentials: credentials,
				// Ajoute du Site qui héberge le token (doit être rendu disponible dans le fichier 'startup')
				issuer: issuer,
				// Site autorisé à lire l'API
				audience: audience
				);

			// On demande d'écrire le token dans le User
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			user.Token = handler.WriteToken(token);

			return user;
		}
	}
}
