using System.Collections.Generic;
using System.Linq;
using SecretSanta.Core.Model;

namespace SecretSanta.Core
{
	public static class Lottery
	{
		public static Dictionary<User, User> Run(IEnumerable<Group> groups)
		{
		    var result = new Dictionary<User, User>();

		    var grps = groups as IList<Group> ?? groups.ToList();
		    for (var g = 0; g < grps.Count(); g++)
		    {
		        var grp = grps.ToArray()[g];
		        
		        foreach (var user in grp.Users)
		        {
		        	var cpt = NextGroupIndex(g, grps.Count());
		        	while (!grps.ToArray()[cpt].Users.Except(result.Values).Any() || cpt == g+1) {
		        		cpt = NextGroupIndex(cpt,grps.Count());
		        	}
		        	var resultUser = grps.ToArray()[cpt].Users.Except(result.Values).First();
		        			            
		            result.Add(user, resultUser);
		        }
		    }
		
		    return result;
		}
			
		private static int NextGroupIndex(int compteur, int max)
		{
			var r = compteur+1;
			return r >= max ? 0 : r;
		}
	}
}